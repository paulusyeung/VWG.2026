using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EnvDTE;
using Gizmox.WebGUI.Common.Design.Skins.Properties;

namespace Gizmox.WebGUI.Common.Design.Skins;

internal class DocumentDesignerList : ListView
{
	private delegate void RedrawSelectedItemDelegate(string strFileName);

	private IComponent mobjSelectedComponent;

	private DocumentDesignerFrame mobjDocumentDesignerFrame;

	private List<object> mobjItems;

	private string mstrFilter = "ImageResource";

	private ImageList mobjSmallImages;

	private ImageList mobjLargeImages;

	private Dictionary<object, int> mobjLargeImageCache;

	private Dictionary<object, int> mobjMediumImageCache;

	private Dictionary<object, int> mobjSmallImageCache;

	private FileSystemWatcher mobjFileSystemWatcher;

	private SaveFileDialog mobjSaveDialog;

	private OpenFileDialog mobjOpenDialog;

	private ColumnHeader mobjColumnPresentation;

	private ColumnHeader mobjColumnEngine;

	private ColumnHeader mobjColumnRole;

	private ImageList mobjMediumImages;

	private ColumnHeader mobjColumnName;

	private ColumnHeader mobjColumnFilename;

	private ColumnHeader mobjColumnType;

	private ColumnHeader mobjColumnSize;

	private ColumnHeader mobjColumnComment;

	private bool SelectedComponentIsSkin
	{
		get
		{
			if (mobjDocumentDesignerFrame != null)
			{
				return mobjDocumentDesignerFrame.IsSkin(mobjSelectedComponent);
			}
			return false;
		}
	}

	private bool IsThemeDesigner
	{
		get
		{
			if (mobjDocumentDesignerFrame != null)
			{
				return mobjDocumentDesignerFrame.IsThemeDesigner;
			}
			return false;
		}
	}

	public string Filter => mstrFilter;

	internal INestedContainer NestedContainer => (INestedContainer)GetService(typeof(INestedContainer));

	internal IComponent SelectedComponent => mobjSelectedComponent;

	private Type FileResourceType => DocumentUtils.InvokeMethod(mobjSelectedComponent, "GetResourceType", "FileResource") as Type;

	public DocumentDesignerList()
	{
		InitializeComponent();
		mobjItems = new List<object>();
		base.VirtualListSize = 0;
		base.FullRowSelect = false;
		mobjLargeImageCache = new Dictionary<object, int>();
		mobjMediumImageCache = new Dictionary<object, int>();
		mobjSmallImageCache = new Dictionary<object, int>();
		mobjSmallImages = new ImageList();
		mobjSmallImages.ImageSize = new Size(16, 16);
		mobjSmallImages.ColorDepth = ColorDepth.Depth16Bit;
		base.SmallImageList = mobjSmallImages;
		mobjMediumImages = new ImageList();
		mobjMediumImages.ImageSize = new Size(20, 20);
		mobjMediumImages.ColorDepth = ColorDepth.Depth16Bit;
		mobjLargeImages = new ImageList();
		mobjLargeImages.ImageSize = new Size(99, 99);
		mobjLargeImages.ColorDepth = ColorDepth.Depth32Bit;
		base.LargeImageList = mobjLargeImages;
	}

	private void InitializeImages()
	{
		mobjLargeImageCache = new Dictionary<object, int>();
		mobjMediumImageCache = new Dictionary<object, int>();
		mobjSmallImageCache = new Dictionary<object, int>();
		mobjSmallImages.Images.Clear();
		mobjMediumImages.Images.Clear();
		mobjLargeImages.Images.Clear();
		mobjSmallImages.Images.Add(Resources.files);
		mobjMediumImages.Images.Add(CreateThumbnail(Resources.files, new Size(20, 20), blnDrawBorder: false, 0, 0, mobjMediumImages.TransparentColor, null));
		mobjLargeImages.Images.Add(CreateThumbnail(Resources.files, new Size(99, 99), blnDrawBorder: true, 1, 2, mobjLargeImages.TransparentColor, null));
	}

	internal void Initialize(DocumentDesignerFrame objDocumentDesignerFrame)
	{
		mobjDocumentDesignerFrame = objDocumentDesignerFrame;
	}

	internal void SetSelection(IComponent objSelectedComponent)
	{
		mobjSelectedComponent = objSelectedComponent;
		if (!string.IsNullOrEmpty(mstrFilter))
		{
			SetFilter(mstrFilter);
		}
	}

	protected override void OnRetrieveVirtualItem(RetrieveVirtualItemEventArgs e)
	{
		base.OnRetrieveVirtualItem(e);
		try
		{
			if (mobjItems.Count > e.ItemIndex)
			{
				e.Item = CreateListItem(mobjItems[e.ItemIndex], blnSelected: false);
			}
			else
			{
				e.Item = new ListViewItem();
			}
		}
		catch (Exception ex)
		{
			e.Item = new ListViewItem("Error");
			e.Item.ToolTipText = ex.Message;
		}
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		base.OnDoubleClick(e);
		if (base.SelectedIndices.Count > 0 && mobjItems.Count > base.SelectedIndices[0])
		{
			OnOpenResourceFile(mobjItems[base.SelectedIndices[0]]);
		}
	}

	private void OnOpenResourceFile(object objSkinResource)
	{
		if (objSkinResource == null)
		{
			return;
		}
		Type fileResourceType = FileResourceType;
		if (!(fileResourceType != null) || !fileResourceType.IsAssignableFrom(objSkinResource.GetType()) || !(DocumentUtils.GetPropertyValue(objSkinResource, "FileName") is string text))
		{
			return;
		}
		ProjectItem projectItem = (ProjectItem)GetService(typeof(ProjectItem));
		if (projectItem == null)
		{
			return;
		}
		bool flag = false;
		foreach (ProjectItem projectItem4 in projectItem.ProjectItems)
		{
			if (Path.GetFileName(projectItem4.get_FileNames((short)0)) == text)
			{
				flag = true;
				OpenProjectItem(projectItem4);
				break;
			}
		}
		if (flag)
		{
			return;
		}
		if (projectItem.ContainingProject != null)
		{
			foreach (ProjectItem projectItem5 in projectItem.ContainingProject.ProjectItems)
			{
				if (Path.GetFileName(projectItem5.get_FileNames((short)0)) == text)
				{
					flag = true;
					OpenProjectItem(projectItem5);
					break;
				}
			}
		}
		if (!flag)
		{
			OnOpenResourceFileForViewing(objSkinResource);
		}
	}

	private void OpenProjectItem(ProjectItem objProjectItem)
	{
		if (objProjectItem == null)
		{
			return;
		}
		Window window = objProjectItem.Open();
		if (window != null)
		{
			window.Activate();
		}
		else if (mobjFileSystemWatcher == null)
		{
			FileInfo fileInfo = new FileInfo(objProjectItem.get_FileNames((short)0));
			if (fileInfo != null)
			{
				InitializeFileSystemWatcher(fileInfo.DirectoryName);
			}
		}
	}

	private void InitializeFileSystemWatcher(string strDirectoryPath)
	{
		if (mobjFileSystemWatcher == null && !string.IsNullOrEmpty(strDirectoryPath))
		{
			mobjFileSystemWatcher = new FileSystemWatcher();
			mobjFileSystemWatcher.Path = strDirectoryPath;
			mobjFileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
			mobjFileSystemWatcher.IncludeSubdirectories = false;
			mobjFileSystemWatcher.EnableRaisingEvents = true;
			mobjFileSystemWatcher.Changed += FileSystemWatcherChanged;
		}
	}

	private void FileSystemWatcherChanged(object sender, FileSystemEventArgs e)
	{
		System.Threading.Thread.Sleep(1000);
		if (e.ChangeType == WatcherChangeTypes.Changed)
		{
			RedrawSelectedItemDelegate method = RedrawSelectedItem;
			if (base.InvokeRequired)
			{
				Invoke(method, e.Name);
			}
		}
	}

	private string GetFileResourceInTempFile(object objSkinResource, bool blnIsReadOnly)
	{
		string result = null;
		if ((ProjectItem)GetService(typeof(ProjectItem)) != null)
		{
			string text = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			string path = (string)DocumentUtils.GetPropertyValue(objSkinResource, "FileName");
			string text2 = Path.Combine(text, path);
			Stream stream = (Stream)DocumentUtils.GetPropertyValue(objSkinResource, "ContentStream");
			if (stream != null)
			{
				Directory.CreateDirectory(text);
				if (File.Exists(text2))
				{
					File.SetAttributes(text2, FileAttributes.Normal);
					File.Delete(text2);
				}
				byte[] array = new byte[stream.Length];
				stream.Position = 0L;
				stream.Read(array, 0, array.Length);
				File.WriteAllBytes(text2, array);
				File.SetAttributes(text2, FileAttributes.ReadOnly);
				result = text2;
			}
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && mobjFileSystemWatcher != null)
		{
			mobjFileSystemWatcher.Changed -= FileSystemWatcherChanged;
			mobjFileSystemWatcher.Dispose();
		}
		base.Dispose(disposing);
	}

	private void OnOpenResourceFileForViewing(object objSkinResource)
	{
		ProjectItem projectItem = (ProjectItem)GetService(typeof(ProjectItem));
		if (projectItem == null)
		{
			return;
		}
		string fileResourceInTempFile = GetFileResourceInTempFile(objSkinResource, blnIsReadOnly: true);
		if (!string.IsNullOrEmpty(fileResourceInTempFile))
		{
			Window window = projectItem.DTE.ItemOperations.OpenFile(fileResourceInTempFile);
			if (window != null)
			{
				window.Document.ReadOnly = true;
				window.Activate();
			}
		}
		else
		{
			MessageBox.Show("Could not retrive resource for view.", "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void OnResourceAdded(object objInstance)
	{
		if (objInstance is IComponent component)
		{
			IContainer nestedContainer = NestedContainer;
			nestedContainer?.Add(component, DocumentUtils.GetComponentName(component, nestedContainer.Components));
		}
	}

	private void OnResourceRemove(object objResource)
	{
		UnregisteredResource(objResource);
		if (mobjItems.Contains(objResource))
		{
			mobjItems.Remove(objResource);
			base.VirtualListSize = mobjItems.Count;
		}
	}

	private void RemoveSkinOverridenValueResources(object objRemovedResource)
	{
		if (IsThemeDesigner || !SelectedComponentIsSkin || !(mobjSelectedComponent is IDictionary dictionary) || !(DocumentUtils.GetPropertyValue(mobjSelectedComponent, "ValueResources") is IEnumerable enumerable))
		{
			return;
		}
		string resourceName = DocumentUtils.GetResourceName(mobjSelectedComponent, objRemovedResource);
		ArrayList arrayList = new ArrayList();
		foreach (object item in enumerable)
		{
			object propertyValue = DocumentUtils.GetPropertyValue(item, "Value");
			if (propertyValue == null)
			{
				continue;
			}
			object propertyValue2 = DocumentUtils.GetPropertyValue(propertyValue, "Value");
			if (propertyValue2 != null && DocumentUtils.GetPropertyValue(propertyValue2, "ResourceName") as string == resourceName)
			{
				object propertyValue3 = DocumentUtils.GetPropertyValue(item, "Key");
				if (propertyValue3 != null)
				{
					arrayList.Add(propertyValue3);
				}
			}
		}
		foreach (object item2 in arrayList)
		{
			dictionary.Remove(item2);
		}
	}

	public void OnResourceRenaming(object objResource, string strNewName)
	{
		if (string.IsNullOrEmpty(strNewName))
		{
			return;
		}
		string resourceName = DocumentUtils.GetResourceName(mobjSelectedComponent, objResource);
		bool flag = FileResourceType.IsAssignableFrom(objResource.GetType());
		try
		{
			if (flag)
			{
				string extension = Path.GetExtension(DocumentUtils.GetPropertyValue(objResource, "FileName", ""));
				strNewName = (strNewName.EndsWith(extension) ? strNewName : (strNewName + extension));
			}
			DocumentUtils.SetResourceName(mobjSelectedComponent, objResource, strNewName);
			if (flag)
			{
				string propertyValue = DocumentUtils.GetPropertyValue(objResource, "FileName", "");
				ProjectItem projectItem = (ProjectItem)GetService(typeof(ProjectItem));
				if (projectItem != null)
				{
					foreach (ProjectItem projectItem2 in projectItem.ProjectItems)
					{
						if (projectItem2.Name == propertyValue)
						{
							byte[] arrContent = File.ReadAllBytes(projectItem2.get_FileNames((short)0));
							Type propertyValue2 = DocumentUtils.GetPropertyValue(objResource, "FilterType", typeof(string));
							ResXFileRef resXFileRef = CreateResourceProjectItem($"{GetResourcePrefix(mobjSelectedComponent)}.{strNewName}", arrContent, propertyValue2);
							if (resXFileRef != null)
							{
								DocumentUtils.SetPropertyValue(objResource, "Content", resXFileRef);
								DocumentUtils.SetPropertyValue(objResource, "FileName", Path.GetFileName(resXFileRef.FileName));
							}
							projectItem2.Delete();
							break;
						}
					}
				}
			}
			OnComponentChanged();
		}
		catch (Exception)
		{
			DocumentUtils.SetResourceName(mobjSelectedComponent, objResource, resourceName);
			throw;
		}
	}

	protected override void OnBeforeLabelEdit(LabelEditEventArgs e)
	{
		base.OnBeforeLabelEdit(e);
		mobjDocumentDesignerFrame.EnableDeleteResourcesVerb(blnEnable: false);
	}

	protected override void OnAfterLabelEdit(LabelEditEventArgs e)
	{
		base.OnAfterLabelEdit(e);
		if (mobjItems.Count > e.Item)
		{
			try
			{
				object obj = mobjItems[e.Item];
				if (obj != null)
				{
					if (!DocumentUtils.IsInherited(mobjSelectedComponent, obj))
					{
						OnResourceRenaming(obj, e.Label);
					}
					else
					{
						MessageBox.Show("The resource cannot be edited.", "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						e.CancelEdit = true;
					}
				}
			}
			catch (Exception ex)
			{
				e.CancelEdit = true;
				MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else
		{
			e.CancelEdit = true;
		}
		mobjDocumentDesignerFrame.EnableDeleteResourcesVerb(blnEnable: true);
	}

	private void OnComponentChanged()
	{
		mobjDocumentDesignerFrame.OnComponentChanged();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		base.OnLostFocus(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		SetSelection();
	}

	protected override void OnVirtualItemsSelectionRangeChanged(ListViewVirtualItemsSelectionRangeChangedEventArgs e)
	{
		base.OnVirtualItemsSelectionRangeChanged(e);
		SetSelection();
	}

	protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
	{
		base.OnItemSelectionChanged(e);
		SetSelection();
	}

	private void SetSelection()
	{
		ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		if (selectionService == null)
		{
			return;
		}
		List<object> list = new List<object>();
		bool enabled = true;
		foreach (int selectedIndex in base.SelectedIndices)
		{
			if (mobjItems.Count > selectedIndex)
			{
				object obj = mobjItems[selectedIndex];
				if (obj != null)
				{
					list.Add(obj);
				}
			}
		}
		if (list.Count > 0)
		{
			selectionService.SetSelectedComponents(list, SelectionTypes.Replace);
		}
		else
		{
			selectionService.SetSelectedComponents(new object[1] { mobjSelectedComponent }, SelectionTypes.Replace);
			enabled = false;
		}
		mobjDocumentDesignerFrame.RemoveResourceButton.Enabled = enabled;
	}

	private void InitializeComponent()
	{
		this.mobjColumnName = new System.Windows.Forms.ColumnHeader();
		this.mobjColumnFilename = new System.Windows.Forms.ColumnHeader();
		this.mobjColumnType = new System.Windows.Forms.ColumnHeader();
		this.mobjColumnSize = new System.Windows.Forms.ColumnHeader();
		this.mobjColumnComment = new System.Windows.Forms.ColumnHeader();
		this.mobjSaveDialog = new System.Windows.Forms.SaveFileDialog();
		this.mobjOpenDialog = new System.Windows.Forms.OpenFileDialog();
		this.mobjColumnPresentation = new System.Windows.Forms.ColumnHeader();
		this.mobjColumnEngine = new System.Windows.Forms.ColumnHeader();
		this.mobjColumnRole = new System.Windows.Forms.ColumnHeader();
		base.SuspendLayout();
		this.mobjColumnName.Text = "Name";
		this.mobjColumnName.Width = 250;
		this.mobjColumnFilename.Text = "Filename";
		this.mobjColumnFilename.Width = 0;
		this.mobjColumnType.Text = "Type";
		this.mobjColumnType.Width = 100;
		this.mobjColumnSize.Text = "Size";
		this.mobjColumnSize.Width = 0;
		this.mobjColumnComment.Text = "Comment";
		this.mobjColumnComment.Width = 150;
		this.mobjOpenDialog.FileName = string.Empty;
		this.mobjColumnPresentation.Text = "Presentation";
		this.mobjColumnEngine.Text = "Engine";
		this.mobjColumnRole.Text = "Role";
		this.AllowDrop = true;
		base.Columns.AddRange(new System.Windows.Forms.ColumnHeader[8] { this.mobjColumnName, this.mobjColumnPresentation, this.mobjColumnEngine, this.mobjColumnRole, this.mobjColumnFilename, this.mobjColumnType, this.mobjColumnSize, this.mobjColumnComment });
		base.VirtualMode = true;
		base.ResumeLayout(false);
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 123)
		{
			mobjDocumentDesignerFrame.ShowContextMenu();
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	protected override object GetService(Type service)
	{
		if (mobjDocumentDesignerFrame != null)
		{
			object serviceInternal = mobjDocumentDesignerFrame.GetServiceInternal(service);
			if (serviceInternal != null)
			{
				return serviceInternal;
			}
		}
		return base.GetService(service);
	}

	private ResXFileRef CreateResourceProjectItem(string strFileName, string strContent, Type objContentType)
	{
		return CreateResourceProjectItem(strFileName, Encoding.UTF8.GetBytes(strFileName), objContentType);
	}

	private ResXFileRef CreateResourceProjectItem(string strFileName, byte[] arrContent, Type objContentType)
	{
		ProjectItem projectItem = (ProjectItem)GetService(typeof(ProjectItem));
		if (projectItem != null)
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Guid.NewGuid().ToString("P"));
			string text2 = Path.Combine(text, strFileName);
			try
			{
				Directory.CreateDirectory(text);
				File.WriteAllBytes(text2, arrContent);
				foreach (ProjectItem projectItem4 in projectItem.ProjectItems)
				{
					if (projectItem4.Name == strFileName)
					{
						projectItem4.Delete();
						break;
					}
				}
				string path = Path.Combine(Path.GetDirectoryName(projectItem.get_FileNames((short)0)), strFileName);
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				ProjectItem projectItem3 = projectItem.ProjectItems.AddFromFileCopy(text2);
				if (projectItem3 != null)
				{
					string typeName = string.Join(",", objContentType.AssemblyQualifiedName.Split(','), 0, 2);
					return new ResXFileRef(projectItem3.get_FileNames((short)0), typeName);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				Directory.Delete(text, recursive: true);
			}
		}
		return null;
	}

	internal void SetView(string strViewName)
	{
		InitializeImages();
		switch (strViewName)
		{
		case "ViewInList":
			base.SmallImageList = mobjMediumImages;
			base.View = View.List;
			break;
		case "ViewDetails":
			base.SmallImageList = mobjSmallImages;
			base.View = View.Details;
			break;
		case "ViewAsThumbnails":
			base.LargeImageList = mobjLargeImages;
			base.View = View.LargeIcon;
			break;
		}
	}

	internal void SetFilter(string strResourceTypeName)
	{
		try
		{
			mstrFilter = strResourceTypeName;
			UnregisteredResources(mobjItems);
			mobjItems = new List<object>();
			InitializeImages();
			base.VirtualListSize = 0;
			if (mobjSelectedComponent == null || !(DocumentUtils.GetPropertyValue(mobjSelectedComponent, "InheritedResources") is IEnumerable enumerable))
			{
				return;
			}
			SortedList<string, object> sortedList = new SortedList<string, object>();
			foreach (object item in enumerable)
			{
				if (item == null)
				{
					continue;
				}
				Type type = item.GetType();
				PropertyInfo property = type.GetProperty("Value");
				if (!(property != null))
				{
					continue;
				}
				object value = property.GetValue(item, new object[0]);
				if (value == null || !DocumentUtils.IsVisible(value) || !(value.GetType().Name == strResourceTypeName))
				{
					continue;
				}
				PropertyInfo property2 = type.GetProperty("Key");
				if (property2 != null)
				{
					object value2 = property2.GetValue(item, new object[0]);
					if (value2 != null && value2 is string)
					{
						sortedList.Add(Convert.ToString(value2), value);
					}
				}
			}
			mobjItems.AddRange(sortedList.Values);
			base.VirtualListSize = mobjItems.Count;
			RegisteredResources(mobjItems);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void RegisteredResource(object objResource)
	{
		IContainer nestedContainer = NestedContainer;
		if (nestedContainer != null && objResource is IComponent { Site: null } component)
		{
			nestedContainer.Add(component, DocumentUtils.GetComponentName(component, nestedContainer.Components));
		}
	}

	private void RegisteredResources(ICollection objSkinResources)
	{
		SuspendDesignerNotifications();
		foreach (object objSkinResource in objSkinResources)
		{
			RegisteredResource(objSkinResource);
		}
		ResumeDesignerNotifications();
	}

	private void UnregisteredResource(object objResource)
	{
		SuspendDesignerNotifications();
		if (objResource is IComponent { Site: not null } component)
		{
			NestedContainer?.Remove(component);
		}
		ResumeDesignerNotifications();
	}

	private void UnregisteredResources(ICollection objSkinResources)
	{
		foreach (object objSkinResource in objSkinResources)
		{
			UnregisteredResource(objSkinResource);
		}
	}

	private ListViewItem CreateListItem(object objSkinResource, bool blnSelected)
	{
		return new ListViewItem(DocumentUtils.GetResourceName(mobjSelectedComponent, objSkinResource))
		{
			SubItems = 
			{
				DocumentUtils.GetPropertyValue(objSkinResource, "Presentation", string.Empty),
				DocumentUtils.GetPropertyValue(objSkinResource, "PresentationEngine", string.Empty),
				DocumentUtils.GetPropertyValue(objSkinResource, "PresentationRole", string.Empty),
				DocumentUtils.GetPropertyValue(objSkinResource, "FileName", string.Empty),
				DocumentUtils.GetPropertyValue(objSkinResource, "Type", string.Empty),
				DocumentUtils.GetPropertyValue(objSkinResource, "Size", string.Empty),
				DocumentUtils.GetPropertyValue(objSkinResource, "Comment", string.Empty)
			},
			ImageIndex = GetListItemImageIndex(objSkinResource, blnSelected),
			ToolTipText = DocumentUtils.GetPropertyValue(objSkinResource, "Comment", string.Empty)
		};
	}

	private int GetListItemImageIndex(object objSkinResource, bool blnSelected)
	{
		try
		{
			int num = 0;
			Dictionary<object, int> viewImageCache = GetViewImageCache();
			if (objSkinResource != null)
			{
				if (viewImageCache.ContainsKey(objSkinResource))
				{
					num = viewImageCache[objSkinResource];
				}
				else
				{
					Type type = objSkinResource.GetType();
					if (FileResourceType.IsAssignableFrom(type))
					{
						Bitmap bitmap = null;
						if (type.Name == "ImageResource")
						{
							string propertyValue = DocumentUtils.GetPropertyValue(objSkinResource, "FileName", string.Empty);
							if (!string.IsNullOrEmpty(propertyValue))
							{
								ProjectItem projectItem = (ProjectItem)GetService(typeof(ProjectItem));
								if (projectItem != null)
								{
									string text = string.Empty;
									foreach (ProjectItem projectItem2 in projectItem.ProjectItems)
									{
										if (projectItem2.Name == propertyValue && projectItem2.FileCount > 0)
										{
											text = projectItem2.get_FileNames((short)0);
											break;
										}
									}
									if (!string.IsNullOrEmpty(text) && File.Exists(text))
									{
										bitmap = new Bitmap(text);
									}
								}
							}
							if (bitmap == null)
							{
								object propertyValue2 = DocumentUtils.GetPropertyValue(objSkinResource, "Value");
								if (propertyValue2 is Bitmap)
								{
									bitmap = propertyValue2 as Bitmap;
								}
							}
						}
						if (bitmap == null)
						{
							string propertyValue3 = DocumentUtils.GetPropertyValue(objSkinResource, "FileExtension", ".unknown");
							if (Resources.ResourceManager.GetObject(propertyValue3.Replace(".", "FT_")) is Icon icon)
							{
								bitmap = icon.ToBitmap();
							}
						}
						if (bitmap != null)
						{
							switch (base.View)
							{
							case View.LargeIcon:
								mobjLargeImages.Images.Add(CreateThumbnail(bitmap, new Size(99, 99), blnDrawBorder: true, 1, 2, mobjLargeImages.TransparentColor, GetStateImage(objSkinResource, base.View)));
								num = mobjLargeImages.Images.Count - 1;
								break;
							case View.List:
								mobjMediumImages.Images.Add(CreateThumbnail(bitmap, new Size(20, 20), blnDrawBorder: false, 0, 0, mobjMediumImages.TransparentColor, GetStateImage(objSkinResource, base.View)));
								num = mobjMediumImages.Images.Count - 1;
								break;
							case View.Details:
								mobjSmallImages.Images.Add(CreateThumbnail(bitmap, new Size(16, 16), blnDrawBorder: false, 0, 0, mobjSmallImages.TransparentColor, GetStateImage(objSkinResource, base.View)));
								num = mobjSmallImages.Images.Count - 1;
								break;
							default:
								num = 0;
								break;
							}
						}
					}
					viewImageCache[objSkinResource] = num;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return 0;
		}
	}

	private Bitmap GetStateImage(object objSkinResource, View objView)
	{
		if (DocumentUtils.IsInherited(mobjSelectedComponent, objSkinResource))
		{
			if (objView == View.LargeIcon)
			{
				return Resources.shortcut;
			}
			return Resources.shortcut_small;
		}
		return null;
	}

	internal void AddNewFile()
	{
		if (!(mobjSelectedComponent is IDictionary dictionary))
		{
			return;
		}
		Type type = DocumentUtils.InvokeMethod(mobjSelectedComponent, "GetResourceType", Filter) as Type;
		if (!(type != null) || (ProjectItem)GetService(typeof(ProjectItem)) == null)
		{
			return;
		}
		string resourceKey = GetResourceKey(dictionary, type, blnKeepUnique: true);
		if (string.IsNullOrEmpty(resourceKey))
		{
			return;
		}
		object obj = Activator.CreateInstance(type);
		if (obj == null)
		{
			return;
		}
		string propertyValue = DocumentUtils.GetPropertyValue(obj, "NewFileExtension", string.Empty);
		if (string.IsNullOrEmpty(propertyValue))
		{
			return;
		}
		Type type2 = (Type)DocumentUtils.GetPropertyValue(obj, "CompilerContentType");
		if (!(type2 != null))
		{
			return;
		}
		byte[] templateStream = GetTemplateStream(propertyValue);
		if (templateStream != null)
		{
			string arg = $"{resourceKey}.{propertyValue}";
			ResXFileRef resXFileRef = CreateResourceProjectItem($"{GetResourcePrefix(mobjSelectedComponent)}.{arg}", templateStream, type2);
			if (resXFileRef == null)
			{
				throw new Exception("Could not resolve comipler content type for resource.");
			}
			DocumentUtils.SetPropertyValue(obj, "Content", resXFileRef);
			DocumentUtils.SetPropertyValue(obj, "FileName", Path.GetFileName(resXFileRef.FileName));
			dictionary[resourceKey] = obj;
			OnResourceAdded(obj);
			mobjItems.Add(obj);
			base.VirtualListSize = mobjItems.Count;
			OnComponentChanged();
		}
	}

	private byte[] GetTemplateStream(string strNewFileExtenstion)
	{
		object obj = Resources.ResourceManager.GetObject($"{strNewFileExtenstion}_Template");
		if (obj != null)
		{
			if (obj is byte[])
			{
				return obj as byte[];
			}
			if (obj is Bitmap)
			{
				if (obj is Bitmap bitmap)
				{
					MemoryStream memoryStream = new MemoryStream();
					bitmap.Save(memoryStream, ImageFormat.Gif);
					if (memoryStream != null && memoryStream.Length > 0)
					{
						return memoryStream.ToArray();
					}
				}
			}
			else if (obj is string)
			{
				string text = obj as string;
				if (!string.IsNullOrEmpty(text))
				{
					return Encoding.UTF8.GetBytes(text);
				}
			}
		}
		return new byte[0];
	}

	internal void DeleteResources()
	{
		try
		{
			List<object> list = new List<object>();
			bool flag = false;
			foreach (int selectedIndex in base.SelectedIndices)
			{
				if (mobjItems.Count > selectedIndex)
				{
					list.Add(mobjItems[selectedIndex]);
				}
			}
			if (list.Count > 0 && ConfirmResourceRemoval(list))
			{
				foreach (object item in list)
				{
					RemoveSkinOverridenValueResources(item);
					DeleteResource(item);
					if (DeleteFile(item))
					{
						mobjItems.Remove(item);
						OnResourceRemove(item);
						flag = true;
					}
				}
			}
			if (flag)
			{
				base.VirtualListSize = mobjItems.Count;
				OnComponentChanged();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DeleteResource(object objResource)
	{
		string skinKey = GetSkinKey(DocumentUtils.GetResourceName(mobjSelectedComponent, objResource));
		DocumentUtils.InvokeMethod(mobjSelectedComponent, "Delete", objResource);
		ReplaceResource(objResource, GetResourceByKey(skinKey));
	}

	private object GetResourceByKey(string strResourceKey)
	{
		if (DocumentUtils.GetPropertyValue(mobjSelectedComponent, "Resources") is IEnumerable enumerable)
		{
			foreach (object item in enumerable)
			{
				if (item == null)
				{
					continue;
				}
				Type type = item.GetType();
				PropertyInfo property = type.GetProperty("Key");
				if (property != null && (string)property.GetValue(item, new object[0]) == strResourceKey)
				{
					PropertyInfo property2 = type.GetProperty("Value");
					if (property2 != null)
					{
						return property2.GetValue(item, new object[0]);
					}
				}
			}
		}
		return null;
	}

	private bool ConfirmResourceRemoval(List<object> objSelectedItems)
	{
		bool result = false;
		if (objSelectedItems != null && objSelectedItems.Count > 0)
		{
			result = ((objSelectedItems.Count != 1) ? (MessageBox.Show($"Are you sure you want to delete selected '{objSelectedItems.Count.ToString()}' items?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes) : (MessageBox.Show($"Are you sure you want to delete '{DocumentUtils.GetResourceName(mobjSelectedComponent, objSelectedItems[0])}'?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes));
		}
		return result;
	}

	private bool DeleteFile(object objFileResource)
	{
		try
		{
			bool result = false;
			ProjectItem projectItem = (ProjectItem)GetService(typeof(ProjectItem));
			if (projectItem != null)
			{
				foreach (ProjectItem projectItem2 in projectItem.ProjectItems)
				{
					if (projectItem2.Name == DocumentUtils.GetPropertyValue(objFileResource, "FileName", ""))
					{
						projectItem2.Delete();
						result = true;
						break;
					}
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}
	}

	private string GetSkinKey(string strResourceName)
	{
		if (strResourceName.Contains(":"))
		{
			string[] array = strResourceName.Split(':');
			return array[array.Length - 1];
		}
		return strResourceName;
	}

	internal void OnResourceOverride(object objOverridenResource)
	{
		try
		{
			if (!DocumentUtils.IsInherited(mobjSelectedComponent, objOverridenResource) || !(objOverridenResource is ICloneable cloneable))
			{
				return;
			}
			object obj = cloneable.Clone();
			if (mobjSelectedComponent is IDictionary dictionary)
			{
				dictionary[DocumentUtils.GetResourceName(mobjSelectedComponent, objOverridenResource)] = obj;
				ReplaceResource(objOverridenResource, obj);
				if ((ProjectItem)GetService(typeof(ProjectItem)) != null)
				{
					string fileResourceInTempFile = GetFileResourceInTempFile(objOverridenResource, blnIsReadOnly: false);
					if (!string.IsNullOrEmpty(fileResourceInTempFile))
					{
						byte[] arrContent = File.ReadAllBytes(fileResourceInTempFile);
						Type type = (Type)DocumentUtils.GetPropertyValue(objOverridenResource, "CompilerContentType");
						if (type != null)
						{
							string resourceName = DocumentUtils.GetResourceName(mobjSelectedComponent, objOverridenResource);
							ResXFileRef resXFileRef = CreateResourceProjectItem($"{GetResourcePrefix(mobjSelectedComponent)}.{resourceName}", arrContent, type);
							if (resXFileRef != null)
							{
								DocumentUtils.SetPropertyValue(obj, "Content", resXFileRef);
								DocumentUtils.SetPropertyValue(obj, "FileName", Path.GetFileName(resXFileRef.FileName));
								RedrawSelectedItem(Path.GetFileName(resXFileRef.FileName));
								OverrideSkinValueResources(dictionary, resourceName);
							}
						}
					}
				}
			}
			OnComponentChanged();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void OverrideSkinValueResources(IDictionary objDictionary, string strOverridenResourceKey)
	{
		if (!SelectedComponentIsSkin || !(DocumentUtils.GetPropertyValue(mobjSelectedComponent, "ParentsValueResources") is IEnumerable enumerable))
		{
			return;
		}
		foreach (object item in enumerable)
		{
			object propertyValue = DocumentUtils.GetPropertyValue(item, "Value");
			if (propertyValue == null)
			{
				continue;
			}
			object propertyValue2 = DocumentUtils.GetPropertyValue(propertyValue, "Value");
			if (propertyValue2 == null)
			{
				continue;
			}
			string text = DocumentUtils.GetPropertyValue(propertyValue2, "ResourceName") as string;
			if (!(text == strOverridenResourceKey))
			{
				continue;
			}
			Type type = propertyValue2.GetType();
			if (!IsSubclassOf(type, "SkinResourceReference"))
			{
				continue;
			}
			Type type2 = (IsThemeDesigner ? mobjSelectedComponent.GetType() : DocumentUtils.GetSkinDesignType(mobjSelectedComponent));
			if (type2 != null)
			{
				object obj = Activator.CreateInstance(type, type2.FullName, text);
				if (obj != null)
				{
					objDictionary[DocumentUtils.GetResourceName(mobjSelectedComponent, propertyValue)] = obj;
				}
			}
		}
	}

	private bool IsSubclassOf(Type objType, string strBaseName)
	{
		bool result = false;
		if (objType != null && !string.IsNullOrEmpty(strBaseName))
		{
			while (objType != null)
			{
				if (objType.Name == strBaseName)
				{
					result = true;
					break;
				}
				objType = objType.BaseType;
			}
		}
		return result;
	}

	private void ReplaceResource(object objOldResource, object objNewResource)
	{
		Dictionary<object, int> viewImageCache = GetViewImageCache();
		if (viewImageCache.ContainsKey(objOldResource))
		{
			viewImageCache.Remove(objOldResource);
		}
		if (mobjItems.Contains(objOldResource))
		{
			int index = mobjItems.IndexOf(objOldResource);
			mobjItems.Remove(objOldResource);
			if (objNewResource != null)
			{
				mobjItems.Insert(index, objNewResource);
			}
		}
		else if (objNewResource != null)
		{
			mobjItems.Add(objNewResource);
		}
		UnregisteredResource(objOldResource);
		if (objNewResource != null)
		{
			RegisteredResource(objNewResource);
		}
		Invalidate();
	}

	private void RedrawSelectedItem(string strFileName)
	{
		try
		{
			if (mobjItems != null && !string.IsNullOrEmpty(strFileName))
			{
				object obj = mobjItems.Find((object objResource) => DocumentUtils.GetPropertyValue(objResource, "FileName", string.Empty) == strFileName);
				if (obj != null)
				{
					int num = mobjItems.IndexOf(obj);
					GetViewImageCache().Remove(obj);
					RedrawItems(num, num, invalidateOnly: false);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private Dictionary<object, int> GetViewImageCache()
	{
		Dictionary<object, int> result = mobjMediumImageCache;
		switch (base.View)
		{
		case View.LargeIcon:
			result = mobjLargeImageCache;
			break;
		case View.List:
			result = mobjMediumImageCache;
			break;
		case View.Details:
			result = mobjSmallImageCache;
			break;
		}
		return result;
	}

	internal void AddExistingFile()
	{
		try
		{
			if (!(mobjSelectedComponent is IDictionary dictionary))
			{
				return;
			}
			Type type = DocumentUtils.InvokeMethod(mobjSelectedComponent, "GetResourceType", Filter) as Type;
			if (!(type != null))
			{
				return;
			}
			object obj = Activator.CreateInstance(type);
			if (obj == null)
			{
				return;
			}
			if (FileResourceType.IsAssignableFrom(type))
			{
				mobjOpenDialog.Filter = DocumentUtils.GetPropertyValue(obj, "Filter", "All Files(*.*)|*.*");
				mobjOpenDialog.Multiselect = true;
				if (mobjOpenDialog.ShowDialog() == DialogResult.OK)
				{
					AddExistingFiles(mobjOpenDialog.FileNames, type, dictionary);
				}
				return;
			}
			string resourceKey = GetResourceKey(dictionary, type, blnKeepUnique: false);
			if (!string.IsNullOrEmpty(resourceKey))
			{
				dictionary[resourceKey] = obj;
				mobjItems.Add(obj);
				base.VirtualListSize = mobjItems.Count;
				OnComponentChanged();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void AddExistingFiles(string[] arrFiles, Type objFilterType, IDictionary objDictionary)
	{
		foreach (string text in arrFiles)
		{
			FileInfo fileInfo = new FileInfo(text);
			if (fileInfo == null)
			{
				continue;
			}
			object obj = Activator.CreateInstance(objFilterType);
			if (obj == null)
			{
				continue;
			}
			string text2 = DocumentUtils.GetPropertyValue(obj, "Filter") as string;
			if (!string.IsNullOrEmpty(text2) && !text2.Contains($"*{fileInfo.Extension}"))
			{
				continue;
			}
			string resourceKey = GetResourceKey(objDictionary, Path.GetFileNameWithoutExtension(text), Path.GetExtension(text), blnKeepUnique: false);
			if (!string.IsNullOrEmpty(resourceKey))
			{
				byte[] arrContent = File.ReadAllBytes(text);
				Type type = (Type)DocumentUtils.GetPropertyValue(obj, "CompilerContentType");
				if (!(type != null))
				{
					throw new Exception("Could not resolve comipler content type for resource.");
				}
				ResXFileRef resXFileRef = CreateResourceProjectItem($"{GetResourcePrefix(mobjSelectedComponent)}.{resourceKey}", arrContent, type);
				if (resXFileRef != null)
				{
					DocumentUtils.SetPropertyValue(obj, "Content", resXFileRef);
					DocumentUtils.SetPropertyValue(obj, "FileName", Path.GetFileName(resXFileRef.FileName));
				}
			}
			if (objDictionary.Contains(resourceKey))
			{
				object obj2 = objDictionary[resourceKey];
				if (obj2 != null)
				{
					OnResourceRemove(obj2);
				}
			}
			objDictionary[resourceKey] = obj;
			OnResourceAdded(obj);
			mobjItems.Add(obj);
			base.VirtualListSize = mobjItems.Count;
		}
		OnComponentChanged();
	}

	protected override void OnDragEnter(DragEventArgs drgevent)
	{
		drgevent.Effect = DragDropEffects.Copy;
		base.OnDragEnter(drgevent);
	}

	protected override void OnDragDrop(DragEventArgs objArgs)
	{
		try
		{
			if (!objArgs.Data.GetDataPresent("FileDrop") || !(mobjSelectedComponent is IDictionary objDictionary))
			{
				return;
			}
			Type type = DocumentUtils.InvokeMethod(mobjSelectedComponent, "GetResourceType", Filter) as Type;
			if (type != null)
			{
				string[] array = FilterInvalidFiles((string[])objArgs.Data.GetData("FileDrop"));
				if (array.Length != 0)
				{
					AddExistingFiles(array, type, objDictionary);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private string[] FilterInvalidFiles(string[] arrFiles)
	{
		return arrFiles;
	}

	private string GetResourcePrefix(IComponent objSelected)
	{
		ThemeDocumentDesigner themeDocumentDesigner = (ThemeDocumentDesigner)GetService(typeof(ThemeDocumentDesigner));
		if (themeDocumentDesigner != null)
		{
			if (objSelected == themeDocumentDesigner.Component)
			{
				return objSelected.Site.Name;
			}
			return $"{themeDocumentDesigner.Component.Site.Name}.{objSelected.Site.Name}";
		}
		return objSelected.Site.Name;
	}

	private string GetResourceKey(IDictionary objDictionary, Type objType, bool blnKeepUnique)
	{
		return GetResourceKey(objDictionary, objType.Name.ToLowerInvariant(), "", 1, blnKeepUnique);
	}

	private string GetResourceKey(IDictionary objDictionary, string strName, bool blnKeepUnique)
	{
		return GetResourceKey(objDictionary, strName, "", 0, blnKeepUnique);
	}

	private string GetResourceKey(IDictionary objDictionary, string strName, string strExtension, bool blnKeepUnique)
	{
		return GetResourceKey(objDictionary, strName, strExtension, 0, blnKeepUnique);
	}

	private string GetResourceKey(IDictionary objDictionary, string strName, string strExtension, int intIndex, bool blnKeepUnique)
	{
		string text = ((intIndex <= 0) ? $"{strName}{strExtension}" : $"{strName}{intIndex}{strExtension}");
		if (objDictionary.Contains(text) && blnKeepUnique)
		{
			return GetResourceKey(objDictionary, strName, strExtension, intIndex + 1, blnKeepUnique);
		}
		return text;
	}

	private static Bitmap CreateThumbnail(Image objSourceImage, Size objThumbnailSize, bool blnDrawBorder, int intBorderWidth, int intSelectionBorderWidth, Color objImageListTransparentColor, Image objStateImage)
	{
		if (objSourceImage == null)
		{
			return null;
		}
		Bitmap bitmap = new Bitmap(objThumbnailSize.Width, objThumbnailSize.Height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		if (objSourceImage.Size.Width > objThumbnailSize.Width || objSourceImage.Height > objThumbnailSize.Height)
		{
			graphics.InterpolationMode = InterpolationMode.High;
		}
		Rectangle rect = new Rectangle(0, 0, objThumbnailSize.Width, objThumbnailSize.Height);
		if (blnDrawBorder)
		{
			Color color = ((objImageListTransparentColor.R <= 128) ? Color.FromArgb(objImageListTransparentColor.R + 1, objImageListTransparentColor.G, objImageListTransparentColor.B) : Color.FromArgb(objImageListTransparentColor.R - 1, objImageListTransparentColor.G, objImageListTransparentColor.B));
			graphics.FillRectangle(new SolidBrush(color), rect);
			Rectangle rect2 = new Rectangle(intSelectionBorderWidth, intSelectionBorderWidth, objThumbnailSize.Width - 2 * intSelectionBorderWidth, objThumbnailSize.Height - 2 * intSelectionBorderWidth);
			graphics.DrawRectangle(SystemPens.ButtonFace, rect2);
			rect.X += intBorderWidth + intSelectionBorderWidth;
			rect.Y += intBorderWidth + intSelectionBorderWidth;
			rect.Width -= 2 * (intBorderWidth + intSelectionBorderWidth);
			rect.Height -= 2 * (intBorderWidth + intSelectionBorderWidth);
		}
		graphics.FillRectangle(SystemBrushes.Window, rect);
		Size size = ScaleSizeProportionally(objSourceImage.Size, rect.Size, blnOnlyScaleDownward: true);
		Rectangle rect3 = new Rectangle(rect.X + (rect.Width - size.Width) / 2, rect.Y + (rect.Height - size.Height) / 2, size.Width, size.Height);
		graphics.DrawImage(objSourceImage, rect3);
		if (objStateImage != null)
		{
			graphics.DrawImage(objStateImage, intBorderWidth + intSelectionBorderWidth, objThumbnailSize.Height - objStateImage.Height - (intBorderWidth + intSelectionBorderWidth));
		}
		return bitmap;
	}

	private static Size ScaleSizeProportionally(Size objOriginalSize, Size objMaxScaledSize, bool blnOnlyScaleDownward)
	{
		double val = (double)objMaxScaledSize.Width / (double)objOriginalSize.Width;
		double val2 = (double)objMaxScaledSize.Height / (double)objOriginalSize.Height;
		double num = Math.Min(val, val2);
		if (blnOnlyScaleDownward)
		{
			num = Math.Min(num, 1.0);
		}
		return new Size((int)Math.Round(Math.Floor((double)objOriginalSize.Width * num)), (int)Math.Round(Math.Floor((double)objOriginalSize.Height * num)));
	}

	internal void OnDeleteResource(object objResource)
	{
		try
		{
			if (objResource != null)
			{
				List<object> list = new List<object>();
				list.Add(objResource);
				if (ConfirmResourceRemoval(list))
				{
					DeleteResource(objResource);
					DeleteFile(objResource);
				}
				OnResourceRemove(objResource);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Designer Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	internal bool ResetSkinDefinitions(bool blnResetProperties, bool blnResetResources)
	{
		bool result = false;
		if (mobjSelectedComponent != null)
		{
			List<object> list = null;
			if (blnResetResources)
			{
				list = DocumentUtils.InvokeMethod(mobjSelectedComponent, "GetOverridedFileResources") as List<object>;
			}
			if (blnResetProperties)
			{
				result = Convert.ToBoolean(DocumentUtils.InvokeMethod(mobjSelectedComponent, "RemoveOverridedValueResources"));
			}
			if (list != null && list.Count > 0)
			{
				foreach (object item in list)
				{
					DeleteResource(item);
					DeleteFile(item);
					OnResourceRemove(item);
				}
			}
		}
		return result;
	}

	internal void ResetSelection()
	{
		SetSelection();
	}

	public void SuspendDesignerNotifications()
	{
		if (mobjDocumentDesignerFrame != null)
		{
			mobjDocumentDesignerFrame.SuspendDesignerNotifications();
		}
	}

	public void ResumeDesignerNotifications()
	{
		if (mobjDocumentDesignerFrame != null)
		{
			mobjDocumentDesignerFrame.ResumeDesignerNotifications();
		}
	}

	private Stream GetCompositeDocumentStream()
	{
		if (mobjSelectedComponent is IDictionary dictionary)
		{
			object obj = dictionary["Composite.dat"];
			if (obj != null)
			{
				return (Stream)DocumentUtils.GetPropertyValue(obj, "ContentStream");
			}
		}
		return null;
	}
}

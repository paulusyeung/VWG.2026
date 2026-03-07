using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Client.Forms;
using Gizmox.WebGUI.Client.Providers;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Client.Controllers
{
	public abstract class ObjectCollectionController : ObjectController
	{
		private IList mobjWebObjects = null;

		private IList mobjWinObjects = null;

		private IContext mobjContext = null;

		private ArrayList mobjControllers = null;

		public new IContext Context => mobjContext;

		protected virtual bool OverrideExistWinObjects => false;

		public IList WebObjects => mobjWebObjects;

		public IObservableList WebObservedList => WebObjects as IObservableList;

		public IList WinObjects => mobjWinObjects;

		public ObjectCollectionController(IContext objContext, object objWebObject, IList objWebObjects, object objWinObject, IList objWinObjects)
			: base(objContext, objWebObject, objWinObject)
		{
			mobjControllers = new ArrayList();
			mobjWebObjects = objWebObjects;
			mobjWinObjects = objWinObjects;
			mobjContext = objContext;
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			foreach (ObjectController mobjController in mobjControllers)
			{
				mobjController.UpdateSource();
			}
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			foreach (ObjectController mobjController in mobjControllers)
			{
				mobjController.UpdateTarget();
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			if (!WinObjects.IsReadOnly)
			{
				try
				{
					SuspendNotifications();
					InitializeWinObjects();
				}
				finally
				{
					ResumeNotifications();
				}
			}
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			if (WebObservedList != null && !base.DesignMode)
			{
				WebObservedList.ObservableItemAdded += WebObservedList_ObservableItemAdded;
				WebObservedList.ObservableItemRemoved += WebObservedList_ObservableItemRemoved;
				WebObservedList.ObservableListCleared += WebObservedList_ObservableListCleared;
			}
		}

		private void WebObservedList_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
		{
			if (GetControllerByWebObject(objArgs.Item) == null)
			{
				((IContextNotifications)Context).NotifyListItemAdded(this, objArgs.Item);
			}
		}

		private void WebObservedList_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
		{
			((IContextNotifications)Context).NotifyListItemRemoved(this, objArgs.Item);
		}

		private void WebObservedList_ObservableListCleared(object sender, EventArgs e)
		{
			((IContextNotifications)Context).NotifyListCleared(this);
		}

		public virtual void FireObservableListItemAdded(object objItem)
		{
			OnWebObjectAdded(objItem);
		}

		public virtual void FireObservableListItemRemoved(object objItem)
		{
			OnWebObjectRemoved(objItem);
		}

		public virtual void FireObservableListCleared()
		{
			ClearWinObjects();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			if (WebObservedList != null && !base.DesignMode)
			{
				WebObservedList.ObservableItemAdded -= WebObservedList_ObservableItemAdded;
				WebObservedList.ObservableItemRemoved -= WebObservedList_ObservableItemRemoved;
				WebObservedList.ObservableListCleared -= WebObservedList_ObservableListCleared;
			}
		}

		protected virtual void InitializeWinObjects()
		{
			if (WebObjects == null || WinObjects == null)
			{
				return;
			}
			ClearWinObjects();
			int count = WinObjects.Count;
			int num = 0;
			foreach (object webObject in WebObjects)
			{
				ObjectController objectController = CreateObjectControlerBySourceObject(webObject);
				if (objectController != null && objectController.TargetObject != null)
				{
					object targetObject = objectController.TargetObject;
					mobjControllers.Add(objectController);
					if (objectController != null)
					{
						RegisterController(objectController);
					}
					if (OverrideExistWinObjects && num < count)
					{
						WinObjects[num] = targetObject;
						num++;
					}
					else
					{
						AddWinObject(targetObject);
					}
					objectController?.Initialize();
					objectController?.Load();
				}
			}
		}

		protected virtual ObjectController CreateObjectControlerBySourceObject(object objSoureceObject)
		{
			return new ObjectController(Context, objSoureceObject);
		}

		protected virtual ObjectController CreateObjectControlerByTargetObject(object objTargetObject)
		{
			return new ObjectController(Context, null, objTargetObject);
		}

		public override void Clear()
		{
			base.Clear();
			ClearControllers();
			if (WinObjects == null || base.DesignServices == null)
			{
				return;
			}
			foreach (object winObject in WinObjects)
			{
				if (winObject is IComponent objWinComponent)
				{
					base.DesignServices.UnregisterWinComponent(objWinComponent);
				}
			}
		}

		protected virtual void ClearWinObjects()
		{
			ClearControllers();
			if (WinObjects == null)
			{
				return;
			}
			if (base.DesignMode)
			{
				foreach (object winObject in WinObjects)
				{
					if (winObject is IComponent objWinComponent)
					{
						base.DesignServices.UnregisterWinComponent(objWinComponent);
					}
				}
			}
			WinObjects.Clear();
		}

		protected virtual void ClearControllers()
		{
			foreach (ObjectController mobjController in mobjControllers)
			{
				mobjController.Clear();
				mobjController.Terminate();
				UnregisterControllerByWinObject(mobjController.TargetObject);
			}
			mobjControllers.Clear();
		}

		protected virtual int AddWinObject(object objWinObject)
		{
			if (WinObjects != null && objWinObject != null)
			{
				if (base.DesignMode && objWinObject is IComponent objWinComponent)
				{
					string strName = null;
					ObjectController controllerByWinObject = GetControllerByWinObject(objWinObject);
					if (controllerByWinObject != null && controllerByWinObject.SourceObject is IComponent { Site: not null } component)
					{
						strName = component.Site.Name;
					}
					base.DesignServices.RegisterWinComponent(objWinComponent, strName);
				}
				return WinObjects.Add(objWinObject);
			}
			return -1;
		}

		internal void SetWebObjectObjects()
		{
			if (WebObjects == null || WinObjects == null)
			{
				return;
			}
			try
			{
				SuspendNotifications();
				ArrayList arrayList = new ArrayList(WebObjects);
				WebObjects.Clear();
				foreach (object winObject in WinObjects)
				{
					ObjectController objectController = ((IContextServices)Context).GetControllerByWinObject(winObject) as ObjectController;
					if (objectController == null)
					{
						objectController = CreateObjectControlerByTargetObject(winObject);
						if (objectController != null)
						{
							objectController.Initialize(base.DesignMode);
							((IContextServices)Context).RegisterController(objectController);
						}
					}
					else
					{
						objectController.UpdateSource();
					}
					if (objectController != null)
					{
						WebObjects.Add(objectController.SourceObject);
						if (arrayList.Contains(objectController.SourceObject))
						{
							arrayList.Remove(objectController.SourceObject);
						}
					}
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}

		internal void SetWinObjectObjects()
		{
			if (WinObjects == null || WebObjects == null)
			{
				return;
			}
			try
			{
				SuspendNotifications();
				ArrayList arrayList = new ArrayList(WinObjects);
				WinObjectsClear();
				foreach (object webObject in WebObjects)
				{
					ObjectController objectController = ((IContextServices)Context).GetControllerByWebObject(webObject) as ObjectController;
					if (objectController == null)
					{
						objectController = CreateObjectControlerBySourceObject(webObject);
						objectController.Initialize(base.DesignMode);
						((IContextServices)Context).RegisterController(objectController);
					}
					else
					{
						objectController.UpdateTarget();
					}
					if (objectController != null)
					{
						WinObjects.Add(objectController.TargetObject);
						if (arrayList.Contains(objectController.TargetObject))
						{
							arrayList.Remove(objectController.TargetObject);
						}
					}
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected internal virtual void WinObjectsClear()
		{
			WinObjects.Clear();
		}

		protected virtual int OnWebObjectAdded(object objWebObject)
		{
			int result = -1;
			ObjectController objectController = CreateObjectControlerBySourceObject(objWebObject);
			if (objectController.TargetObject != null)
			{
				object targetObject = objectController.TargetObject;
				mobjControllers.Add(objectController);
				if (objectController != null)
				{
					RegisterController(objectController);
				}
				objectController?.Initialize();
				result = AddWinObject(targetObject);
				objectController?.Load();
			}
			return result;
		}

		protected virtual void OnWebObjectRemoved(object objWebObject)
		{
			ObjectController controllerByWebObject = GetControllerByWebObject(objWebObject);
			if (controllerByWebObject != null)
			{
				controllerByWebObject.Clear();
				if (mobjControllers.Contains(controllerByWebObject))
				{
					mobjControllers.Remove(controllerByWebObject);
				}
				object targetObject = controllerByWebObject.TargetObject;
				RemoveWinObject(targetObject);
				UnregisterControllerByWebObject(objWebObject);
				controllerByWebObject.Terminate();
			}
		}

		protected virtual void InsertWinObject(int intIndex, object objWinObject)
		{
			if (WinObjects != null && objWinObject != null)
			{
				WinObjects.Insert(intIndex, objWinObject);
			}
		}

		protected virtual void RemoveWinObject(object objWinObject)
		{
			if (WinObjects != null && objWinObject != null)
			{
				WinObjects.Remove(objWinObject);
				if (base.DesignMode && objWinObject is IComponent objWinComponent)
				{
					base.DesignServices.UnregisterWinComponent(objWinComponent);
				}
			}
		}
	}
}

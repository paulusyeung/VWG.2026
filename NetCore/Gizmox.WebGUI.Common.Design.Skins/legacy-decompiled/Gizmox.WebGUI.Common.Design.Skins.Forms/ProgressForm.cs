using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Common.Design.Skins.Forms;

public class ProgressForm : Form, IWorkerItemContainer
{
	private delegate void SetValueDelegate(object objControl, object objValue, object[] arrIndex);

	private delegate void CloseDelegate();

	private class WorkerItem : IDisposable
	{
		private string[] marrResourceTypes;

		private ThemeDocumentDesigner mobjThemeDocumentDesigner;

		private string mstrPath = string.Empty;

		private IWorkerItemContainer mobjParentContainer;

		internal event ProgressChangedDelegate ProgressChanged;

		public WorkerItem(IWorkerItemContainer objParentContainer, ThemeDocumentDesigner objThemeDocumentDesigner, string strPath)
		{
			mobjThemeDocumentDesigner = objThemeDocumentDesigner;
			mstrPath = strPath;
			mobjParentContainer = objParentContainer;
			if (mobjThemeDocumentDesigner != null)
			{
				mobjThemeDocumentDesigner.ProgressChanged += ThemeDocumentDesignerProgressChanged;
				mobjThemeDocumentDesigner.ProcessCompleted += ThemeDocumentDesignerProcessCompleted;
			}
		}

		private void ThemeDocumentDesignerProcessCompleted(object sender, ProcessCompletedArgs e)
		{
			if (mobjParentContainer.IsHandleCreated)
			{
				ProcessCompletedDelegate method = mobjParentContainer.WorkerItemProcessCompleted;
				mobjParentContainer.Invoke(method, this, e);
			}
		}

		private void ThemeDocumentDesignerProgressChanged(object sender, ProgressChangedArgs e)
		{
			if (this.ProgressChanged != null)
			{
				this.ProgressChanged(this, e);
			}
		}

		public WorkerItem(IWorkerItemContainer objParentContainer, ThemeDocumentDesigner objThemeDocumentDesigner, string strPath, string[] arrResourceTypes)
			: this(objParentContainer, objThemeDocumentDesigner, strPath)
		{
			marrResourceTypes = arrResourceTypes;
		}

		public void ProcessExport()
		{
			if (mobjThemeDocumentDesigner != null && !string.IsNullOrEmpty(mstrPath) && marrResourceTypes != null)
			{
				mobjThemeDocumentDesigner.ExportResources(mstrPath, marrResourceTypes);
			}
		}

		public void ProcessImport()
		{
			if (mobjThemeDocumentDesigner != null && !string.IsNullOrEmpty(mstrPath))
			{
				mobjThemeDocumentDesigner.ImportResources(mstrPath);
			}
		}

		public void Dispose()
		{
			if (mobjThemeDocumentDesigner != null)
			{
				mobjThemeDocumentDesigner.Dispose();
			}
		}
	}

	private string[] marrResourceTypes;

	private ThemeDocumentDesigner mobjThemeDocumentDesigner;

	private WorkerItem mobjWorkerItem;

	private string mstrPath = string.Empty;

	private Thread mobjWorkerItemThread;

	private IContainer components = null;

	private Button mobjCancelButton;

	private ProgressBar mobjProgressBar;

	public ProgressForm(ThemeDocumentDesigner objThemeDocumentDesigner, string strPath, string[] arrResourceTypes)
		: this(objThemeDocumentDesigner, strPath)
	{
		marrResourceTypes = arrResourceTypes;
	}

	public ProgressForm(ThemeDocumentDesigner objThemeDocumentDesigner, string strPath)
		: this()
	{
		mobjThemeDocumentDesigner = objThemeDocumentDesigner;
		mstrPath = strPath;
	}

	public ProgressForm()
	{
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (mobjWorkerItem != null)
			{
				mobjWorkerItem.Dispose();
				mobjWorkerItem = null;
			}
			if (components != null)
			{
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	private void mobjCancelButton_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		base.OnClosing(e);
	}

	private void ProgressForm_Load(object sender, EventArgs e)
	{
		if (mobjThemeDocumentDesigner != null && !string.IsNullOrEmpty(mstrPath))
		{
			if (marrResourceTypes != null)
			{
				Text = "Exporting files...";
				mobjWorkerItem = new WorkerItem(this, mobjThemeDocumentDesigner, mstrPath, marrResourceTypes);
				mobjWorkerItemThread = new Thread(mobjWorkerItem.ProcessExport);
			}
			else
			{
				Text = "Importing files...";
				mobjWorkerItem = new WorkerItem(this, mobjThemeDocumentDesigner, mstrPath);
				mobjWorkerItemThread = new Thread(mobjWorkerItem.ProcessImport);
			}
			mobjWorkerItemThread.IsBackground = true;
			mobjWorkerItem.ProgressChanged += WorkerItemProgressChanged;
			mobjWorkerItemThread.Start();
		}
	}

	public void WorkerItemProcessCompleted(object sender, ProcessCompletedArgs e)
	{
		if (base.IsHandleCreated)
		{
			SetControlProperty(this, "DialogResult", e.ChangesApplied ? DialogResult.OK : DialogResult.Cancel);
		}
	}

	private void WorkerItemProgressChanged(object sender, ProgressChangedArgs e)
	{
		if (!base.IsHandleCreated)
		{
			return;
		}
		lock (mobjProgressBar)
		{
			if (e.Minimum >= 0 && e.Maximum >= 0)
			{
				SetControlProperty(mobjProgressBar, "Minimum", e.Minimum);
				SetControlProperty(mobjProgressBar, "Maximum", e.Maximum);
			}
			SetControlProperty(mobjProgressBar, "Value", e.Value);
			Application.DoEvents();
		}
	}

	public void SetControlProperty(Control objControl, string strPropertyName, object objValue)
	{
		Delegate method = new SetValueDelegate(objControl.GetType().GetProperty(strPropertyName).SetValue);
		objControl.Invoke(method, objControl, objValue, null);
	}

	private void InitializeComponent()
	{
		this.mobjCancelButton = new System.Windows.Forms.Button();
		this.mobjProgressBar = new System.Windows.Forms.ProgressBar();
		base.SuspendLayout();
		this.mobjCancelButton.Location = new System.Drawing.Point(138, 58);
		this.mobjCancelButton.Name = "mobjCancelButton";
		this.mobjCancelButton.Size = new System.Drawing.Size(75, 23);
		this.mobjCancelButton.TabIndex = 0;
		this.mobjCancelButton.Text = "Cancel";
		this.mobjCancelButton.UseVisualStyleBackColor = true;
		this.mobjCancelButton.Click += new System.EventHandler(mobjCancelButton_Click);
		this.mobjProgressBar.Location = new System.Drawing.Point(12, 29);
		this.mobjProgressBar.Maximum = 0;
		this.mobjProgressBar.Name = "mobjProgressBar";
		this.mobjProgressBar.Size = new System.Drawing.Size(330, 15);
		this.mobjProgressBar.TabIndex = 1;
		base.CancelButton = this.mobjCancelButton;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(348, 95);
		base.Controls.Add(this.mobjProgressBar);
		base.Controls.Add(this.mobjCancelButton);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ProgressForm";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		base.Load += new System.EventHandler(ProgressForm_Load);
		base.ResumeLayout(false);
	}

	bool IWorkerItemContainer.IsHandleCreated => base.IsHandleCreated;

	object IWorkerItemContainer.Invoke(Delegate method)
	{
		return Invoke(method);
	}
}

#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace Gizmox.WebGUI.Forms.CompanionKit.Engine
{
	public partial class CodeViewer : Form
	{
		public CodeViewer()
		{
			InitializeComponent();
		}

		public string Url
		{
			get
			{ 
				return objCodeBox.Url;
			}
			set
			{
				objCodeBox.Url = value;
				objCodeBox.Update();
			}
		}

	}
}
using System;
using System.Text;
using System.Drawing.Design;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Design
{
    
	public class CursorEditor : UITypeEditor
    {
        private System.Drawing.Design.CursorEditor objWinCursorEditor;

        public CursorEditor()
            : base()
		{
            objWinCursorEditor = new System.Drawing.Design.CursorEditor();
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{

            WinForms.Cursor objWinCursor = (WinForms.Cursor)objWinCursorEditor.EditValue(context, provider, CursorEditor.ConvertCursor((WebForms.Cursor)value));
            return CursorEditor.ConvertCursor(objWinCursor);
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

        /// <summary>
        /// Converts the anchoring.
        /// </summary>
        /// <param name="enmWGAnchor">WG anchor.</param>
        /// <returns></returns>
        public static WinForms.Cursor ConvertCursor(WebForms.Cursor objWebCursor)
        {
            if (WebForms.Cursors.Arrow == objWebCursor)
            {
                return WinForms.Cursors.Arrow;
            }
            if (WebForms.Cursors.Cross == objWebCursor)
            {
                return WinForms.Cursors.Cross;
            }
            if (WebForms.Cursors.AppStarting == objWebCursor)
            {
                return WinForms.Cursors.AppStarting;
            }
            if (WebForms.Cursors.Hand == objWebCursor)
            {
                return WinForms.Cursors.Hand;
            }
            if (WebForms.Cursors.Help == objWebCursor)
            {
                return WinForms.Cursors.Help;
            }
            if (WebForms.Cursors.HSplit == objWebCursor)
            {
                return WinForms.Cursors.HSplit;
            }
            if (WebForms.Cursors.IBeam == objWebCursor)
            {
                return WinForms.Cursors.IBeam;
            }
            if (WebForms.Cursors.No == objWebCursor)
            {
                return WinForms.Cursors.No;
            }
            if (WebForms.Cursors.NoMove2D == objWebCursor)
            {
                return WinForms.Cursors.NoMove2D;
            }
            if (WebForms.Cursors.NoMoveHoriz == objWebCursor)
            {
                return WinForms.Cursors.NoMoveHoriz;
            }
            if (WebForms.Cursors.NoMoveVert == objWebCursor)
            {
                return WinForms.Cursors.NoMoveVert;
            }
            if (WebForms.Cursors.PanEast == objWebCursor)
            {
                return WinForms.Cursors.PanEast;
            }
            if (WebForms.Cursors.PanNE == objWebCursor)
            {
                return WinForms.Cursors.PanNE;
            }
            if (WebForms.Cursors.PanNorth == objWebCursor)
            {
                return WinForms.Cursors.PanNorth;
            }
            if (WebForms.Cursors.PanSE == objWebCursor)
            {
                return WinForms.Cursors.PanSE;
            }
            if (WebForms.Cursors.PanSouth == objWebCursor)
            {
                return WinForms.Cursors.PanSouth;
            }
            if (WebForms.Cursors.PanSW == objWebCursor)
            {
                return WinForms.Cursors.PanSW;
            }
            if (WebForms.Cursors.PanWest == objWebCursor)
            {
                return WinForms.Cursors.PanWest;
            }
            if (WebForms.Cursors.SizeAll == objWebCursor)
            {
                return WinForms.Cursors.SizeAll;
            }
            if (WebForms.Cursors.SizeNESW == objWebCursor)
            {
                return WinForms.Cursors.SizeNESW;
            }
            if (WebForms.Cursors.SizeNS == objWebCursor)
            {
                return WinForms.Cursors.SizeNS;
            }
            if (WebForms.Cursors.SizeNWSE == objWebCursor)
            {
                return WinForms.Cursors.SizeNWSE;
            }
            if (WebForms.Cursors.SizeWE == objWebCursor)
            {
                return WinForms.Cursors.SizeWE;
            }
            if (WebForms.Cursors.UpArrow == objWebCursor)
            {
                return WinForms.Cursors.UpArrow;
            }
            if (WebForms.Cursors.VSplit == objWebCursor)
            {
                return WinForms.Cursors.VSplit;
            }
            if (WebForms.Cursors.WaitCursor == objWebCursor)
            {
                return WinForms.Cursors.WaitCursor;
            }

            return WinForms.Cursors.Default;
        }



        /// <summary>
        /// Converts the anchoring.
        /// </summary>
        /// <param name="enmAnchor">anchor.</param>
        /// <returns></returns>
        public static WebForms.Cursor ConvertCursor(WinForms.Cursor objWinCursor)
        {
            if (WinForms.Cursors.Arrow == objWinCursor)
            {
                return WebForms.Cursors.Arrow;
            }
            if (WinForms.Cursors.Cross == objWinCursor)
            {
                return WebForms.Cursors.Cross;
            }
            if (WinForms.Cursors.AppStarting == objWinCursor)
            {
                return WebForms.Cursors.AppStarting;
            }
            if (WinForms.Cursors.Hand == objWinCursor)
            {
                return WebForms.Cursors.Hand;
            }
            if (WinForms.Cursors.Help == objWinCursor)
            {
                return WebForms.Cursors.Help;
            }
            if (WinForms.Cursors.HSplit == objWinCursor)
            {
                return WebForms.Cursors.HSplit;
            }
            if (WinForms.Cursors.IBeam == objWinCursor)
            {
                return WebForms.Cursors.IBeam;
            }
            if (WinForms.Cursors.No == objWinCursor)
            {
                return WebForms.Cursors.No;
            }
            if (WinForms.Cursors.NoMove2D == objWinCursor)
            {
                return WebForms.Cursors.NoMove2D;
            }
            if (WinForms.Cursors.NoMoveHoriz == objWinCursor)
            {
                return WebForms.Cursors.NoMoveHoriz;
            }
            if (WinForms.Cursors.NoMoveVert == objWinCursor)
            {
                return WebForms.Cursors.NoMoveVert;
            }
            if (WinForms.Cursors.PanEast == objWinCursor)
            {
                return WebForms.Cursors.PanEast;
            }
            if (WinForms.Cursors.PanNE == objWinCursor)
            {
                return WebForms.Cursors.PanNE;
            }
            if (WinForms.Cursors.PanNorth == objWinCursor)
            {
                return WebForms.Cursors.PanNorth;
            }
            if (WinForms.Cursors.PanSE == objWinCursor)
            {
                return WebForms.Cursors.PanSE;
            }
            if (WinForms.Cursors.PanSouth == objWinCursor)
            {
                return WebForms.Cursors.PanSouth;
            }
            if (WinForms.Cursors.PanSW == objWinCursor)
            {
                return WebForms.Cursors.PanSW;
            }
            if (WinForms.Cursors.PanWest == objWinCursor)
            {
                return WebForms.Cursors.PanWest;
            }
            if (WinForms.Cursors.SizeAll == objWinCursor)
            {
                return WebForms.Cursors.SizeAll;
            }
            if (WinForms.Cursors.SizeNESW == objWinCursor)
            {
                return WebForms.Cursors.SizeNESW;
            }
            if (WinForms.Cursors.SizeNS == objWinCursor)
            {
                return WebForms.Cursors.SizeNS;
            }
            if (WinForms.Cursors.SizeNWSE == objWinCursor)
            {
                return WebForms.Cursors.SizeNWSE;
            }
            if (WinForms.Cursors.SizeWE == objWinCursor)
            {
                return WebForms.Cursors.SizeWE;
            }
            if (WinForms.Cursors.UpArrow == objWinCursor)
            {
                return WebForms.Cursors.UpArrow;
            }
            if (WinForms.Cursors.VSplit == objWinCursor)
            {
                return WebForms.Cursors.VSplit;
            }
            if (WinForms.Cursors.WaitCursor == objWinCursor)
            {
                return WebForms.Cursors.WaitCursor;
            }

            return WebForms.Cursors.Default;
        }
    }


}

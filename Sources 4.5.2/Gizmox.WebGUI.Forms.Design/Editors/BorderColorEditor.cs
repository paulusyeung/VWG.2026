using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Design
{
    public class BorderColorEditor : System.Drawing.Design.ColorEditor
    {
        /// <summary>
        /// Edits the given object value using the editor style provided by the <see cref="M:System.Drawing.Design.ColorEditor.GetEditStyle(System.ComponentModel.ITypeDescriptorContext)"/> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider"/> through which editing services may be obtained.</param>
        /// <param name="value">An instance of the value being edited.</param>
        /// <returns>
        /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
        /// </returns>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (value is BorderColor)
            {
                BorderColor objBorderColor = (BorderColor)value;

                Color objColor = (Color)base.EditValue(context, provider, objBorderColor.All);
                if (objBorderColor.All != objColor)
                {
                    return new BorderColor(objColor);
                }
            }
            return value;
        }

        /// <summary>
        /// Paints a representative value of the given object to the provided canvas.
        /// </summary>
        /// <param name="e">What to paint and where to paint it.</param>
        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {
            if (e.Value is BorderColor)
            {
                BorderColor objBorderColor = (BorderColor)e.Value;

                if (objBorderColor.All != Color.Empty)
                {

                    base.PaintValue(new System.Drawing.Design.PaintValueEventArgs(e.Context, objBorderColor.All, e.Graphics, e.Bounds));
                }
                else
                {
                    Rectangle objBounds = e.Bounds;
                    int intBottom = objBounds.Bottom;
                    int intTop = objBounds.Top;
                    int intLeft = objBounds.Left;
                    int intRight = objBounds.Right;
                    int intHeight = objBounds.Height;
                    int intWidth = objBounds.Width;
                    int intGridWidth = (intRight - intLeft) / 3;
                    int intGridHeight = (intBottom - intTop) / 2;

                    SolidBrush brush = new SolidBrush(objBorderColor.Left);
                    e.Graphics.FillRectangle(brush, new Rectangle(intLeft, intTop, intGridWidth + 1, intHeight));
                    brush.Dispose();

                    brush = new SolidBrush(objBorderColor.Right);
                    e.Graphics.FillRectangle(brush, new Rectangle(intLeft + (intGridWidth * 2) + 2, intTop, intGridWidth, intHeight));
                    brush.Dispose();

                    brush = new SolidBrush(objBorderColor.Top);
                    e.Graphics.FillRectangle(brush, new Rectangle(intLeft + intGridWidth + 1, intTop, intGridWidth + 1, intGridHeight));
                    brush.Dispose();

                    brush = new SolidBrush(objBorderColor.Bottom);
                    e.Graphics.FillRectangle(brush, new Rectangle(intLeft + intGridWidth + 1, intTop + intGridHeight, intGridWidth + 1, intGridHeight));
                    brush.Dispose();

                }
            }
            else
            {
                base.PaintValue(e);
            }
        }
    }
}

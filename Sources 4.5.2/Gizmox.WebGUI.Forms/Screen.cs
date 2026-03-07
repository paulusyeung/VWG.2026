using System;
using System.Collections;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>Represents a display device or multiple display devices on a single system.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class Screen
    {
        /// <summary>
        /// Related screen context
        /// </summary>
        private IContextParams mobjContextParams = null;

        static Screen()
        {
        }

        internal Screen(IContextParams objContextParams)
        {
            mobjContextParams = objContextParams;
        }

        /// <summary>Gets or sets a value indicating whether the specified object is equal to this Screen.</summary>
        /// <returns>true if the specified object is equal to this <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>; otherwise, false.</returns>
        /// <param name="obj">The object to compare to this <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>. </param>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>Retrieves a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest portion of the specified control.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest region of the specified control. In multiple display environments where no display contains the control, the display closest to the specified control is returned.</returns>
        /// <param name="objControl">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> for which to retrieve a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>. </param>
        public static Screen FromControl(Control objControl)
        {
            return Screen.PrimaryScreen;
        }

        /// <summary>Retrieves a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest portion of the object referred to by the specified handle.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest region of the object. In multiple display environments where no display contains any portion of the specified window, the display closest to the object is returned.</returns>
        /// <param name="objWindowHandle">The window handle for which to retrieve the <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>. </param>
        public static Screen FromHandle(IntPtr objWindowHandle)
        {
            return Screen.PrimaryScreen;
        }


        /// <summary>Retrieves a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the specified point.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the point. In multiple display environments where no display contains the point, the display closest to the specified point is returned.</returns>
        /// <param name="objPoint">A <see cref="T:System.Drawing.Point"></see> that specifies the location for which to retrieve a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>. </param>
        public static Screen FromPoint(Point objPoint)
        {
            return Screen.PrimaryScreen;
        }

        /// <summary>Retrieves a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest portion of the rectangle.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest region of the specified rectangle. In multiple display environments where no display contains the rectangle, the display closest to the rectangle is returned.</returns>
        /// <param name="objRectangle">A <see cref="T:System.Drawing.Rectangle"></see> that specifies the area for which to retrieve the display. </param>
        public static Screen FromRectangle(Rectangle objRectangle)
        {
            return Screen.PrimaryScreen;
        }

        /// <summary>
        /// Retrieves the bounds of the display that contains the specified point.
        /// </summary>
        /// <param name="objPoint">A <see cref="T:System.Drawing.Point"></see> that specifies the coordinates for which to retrieve the display bounds.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Rectangle"></see> that specifies the bounds of the display that contains the specified point. In multiple display environments where no display contains the specified point, the display closest to the point is returned.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public static Rectangle GetBounds(Point objPoint)
        {
            return Screen.PrimaryScreen.Bounds;
        }

        /// <summary>
        /// Retrieves the bounds of the display that contains the largest portion of the specified rectangle.
        /// </summary>
        /// <param name="objRectangle">A <see cref="T:System.Drawing.Rectangle"></see> that specifies the area for which to retrieve the display bounds.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Rectangle"></see> that specifies the bounds of the display that contains the specified rectangle. In multiple display environments where no monitor contains the specified rectangle, the monitor closest to the rectangle is returned.
        /// </returns>
        public static Rectangle GetBounds(Rectangle objRectangle)
        {
            return Screen.PrimaryScreen.Bounds;
        }

        /// <summary>
        /// Retrieves the bounds of the display that contains the largest portion of the specified control.
        /// </summary>
        /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> for which to retrieve the display bounds.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Rectangle"></see> that specifies the bounds of the display that contains the specified control. In multiple display environments where no display contains the specified control, the display closest to the control is returned.
        /// </returns>
        public static Rectangle GetBounds(Control objControl)
        {
            return Screen.PrimaryScreen.Bounds;
        }

        /// <summary>Computes and retrieves a hash code for an object.</summary>
        /// <returns>A hash code for an object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>Retrieves the working area closest to the specified point. The working area is the desktop area of the display, excluding taskbars, docked windows, and docked tool bars.</summary>
        /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> that specifies the working area. In multiple display environments where no display contains the specified point, the display closest to the point is returned.</returns>
        /// <param name="objPoint">A <see cref="T:System.Drawing.Point"></see> that specifies the coordinates for which to retrieve the working area. </param>
        public static Rectangle GetWorkingArea(Point objPoint)
        {
            return Screen.PrimaryScreen.WorkingArea;
        }

        /// <summary>Retrieves the working area for the display that contains the largest portion of the specified rectangle. The working area is the desktop area of the display, excluding taskbars, docked windows, and docked tool bars.</summary>
        /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> that specifies the working area. In multiple display environments where no display contains the specified rectangle, the display closest to the rectangle is returned.</returns>
        /// <param name="objRectangle">The <see cref="T:System.Drawing.Rectangle"></see> that specifies the area for which to retrieve the working area. </param>
        public static Rectangle GetWorkingArea(Rectangle objRectangle)
        {
            return Screen.PrimaryScreen.WorkingArea;
        }

        /// <summary>Retrieves the working area for the display that contains the largest region of the specified control. The working area is the desktop area of the display, excluding taskbars, docked windows, and docked tool bars.</summary>
        /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> that specifies the working area. In multiple display environments where no display contains the specified control, the display closest to the control is returned.</returns>
        /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> for which to retrieve the working area. </param>
        public static Rectangle GetWorkingArea(Control objControl)
        {
            return Screen.PrimaryScreen.WorkingArea;
        }


        /// <summary>Retrieves a string representing this object.</summary>
        /// <returns>A string representation of the object.</returns>
        public override string ToString()
        {
             return (base.GetType().Name + "[Bounds=" + this.Bounds.ToString() + " WorkingArea=" + this.WorkingArea.ToString() + " Primary=" + this.Primary.ToString() + " DeviceName=" + this.DeviceName);
        }


        /// <summary>Gets an array of all displays on the system.</summary>
        /// <returns>An array of type <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>, containing all displays on the system.</returns>
        public static Screen[] AllScreens
        {
            get
            {
                return new Screen[] { Screen.PrimaryScreen };
            }
        }

        /// <summary>Gets the number of bits of memory, associated with one pixel of data.</summary>
        /// <returns>The number of bits of memory, associated with one pixel of data </returns>
        public int BitsPerPixel
        {
            get
            {
                if (mobjContextParams == null)
                {
                    return 16;
                }
                else
                {
                    return mobjContextParams.ScreenColorDepth;
                }
            }
        }

        /// <summary>Gets the bounds of the display.</summary>
        /// <returns>A <see cref="T:System.Drawing.Rectangle"></see>, representing the bounds of the display.</returns>
        public Rectangle Bounds
        {
            get
            {
                if (mobjContextParams == null)
                {
                    return new Rectangle(0, 0, 800, 600);
                }
                else
                {
                    return new Rectangle(0, 0, mobjContextParams.ScreenWidth, mobjContextParams.ScreenHeight);
                }
            }
        }


        /// <summary>Gets the device name associated with a display.</summary>
        /// <returns>The device name associated with a display.</returns>
        public string DeviceName
        {
            get
            {
                return "Device0";
            }
        }

        /// <summary>Gets a value indicating whether a particular display is the primary device.</summary>
        /// <returns>true if this display is primary; otherwise, false.</returns>
        public bool Primary
        {
            get
            {
                return true;
            }
        }

        /// <summary>Gets the primary display.</summary>
        /// <returns>The primary display.</returns>
        public static Screen PrimaryScreen
        {
            get
            {
                return new Screen((IContextParams)VWGContext.Current);
            }
        }

        /// <summary>Gets the working area of the display. The working area is the desktop area of the display, excluding taskbars, docked windows, and docked tool bars.</summary>
        /// <returns>A <see cref="T:System.Drawing.Rectangle"></see>, representing the working area of the display.</returns>
        public Rectangle WorkingArea
        {
            get
            {
                if (mobjContextParams == null)
                {
                    return new Rectangle(0, 0, 800, 600);
                }
                else
                {
                    return new Rectangle(0, 0, mobjContextParams.ScreenAvailableWidth, mobjContextParams.ScreenAvailableHeight);
                }
            }
        }
    }

 

}

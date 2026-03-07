using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
    [Serializable(), Gizmox.WebGUI.Forms.Skins.SkinContainer(typeof(DockingManagerSkin))]
    public class ZoneSkin : ContainerControlSkin
    {
        private void InitializeComponent()
        { }

        #region Top Indicator

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue TopDockIndicator
        {
            get
            {
                return new StyleValue(this, "TopDockIndicator");
            }
        }

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue TopDockIndicatorHover
        {
            get
            {
                return new StyleValue(this, "TopDockIndicatorHover");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TopDockIndicatorWidth
        {
            get
            {
                return GetImageSize(this.TopDockIndicator.BackgroundImage, Size.Empty).Width;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TopDockIndicatorHeight
        {
            get
            {
                return GetImageSize(this.TopDockIndicator.BackgroundImage, Size.Empty).Height;
            }
        }

        #endregion Top Indicator

        #region Right Indicator

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue RightDockIndicator
        {
            get
            {
                return new StyleValue(this, "RightDockIndicator");
            }
        }

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue RightDockIndicatorHover
        {
            get
            {
                return new StyleValue(this, "RightDockIndicatorHover");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightDockIndicatorWidth
        {
            get
            {
                return GetImageSize(this.RightDockIndicator.BackgroundImage, Size.Empty).Width;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightDockIndicatorHeight
        {
            get
            {
                return GetImageSize(this.RightDockIndicator.BackgroundImage, Size.Empty).Height;
            }
        }

        #endregion Right Indicator

        #region Bottom Indicator

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue BottomDockIndicator
        {
            get
            {
                return new StyleValue(this, "BottomDockIndicator");
            }
        }

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue BottomDockIndicatorHover
        {
            get
            {
                return new StyleValue(this, "BottomDockIndicatorHover");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BottomDockIndicatorWidth
        {
            get
            {
                return GetImageSize(this.BottomDockIndicator.BackgroundImage, Size.Empty).Width;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BottomDockIndicatorHeight
        {
            get
            {
                return GetImageSize(this.BottomDockIndicator.BackgroundImage, Size.Empty).Height;
            }
        }

        #endregion Bottom Indicator

        #region Left Indicator

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue LeftDockIndicator
        {
            get
            {
                return new StyleValue(this, "LeftDockIndicator");
            }
        }

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue LeftDockIndicatorHover
        {
            get
            {
                return new StyleValue(this, "LeftDockIndicatorHover");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftDockIndicatorWidth
        {
            get
            {
                return GetImageSize(this.LeftDockIndicator.BackgroundImage, Size.Empty).Width;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftDockIndicatorHeight
        {
            get
            {
                return GetImageSize(this.LeftDockIndicator.BackgroundImage, Size.Empty).Height;
            }
        }

        #endregion Left Indicator

        #region Center Indicator

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue CenterDockIndicator
        {
            get
            {
                return new StyleValue(this, "CenterDockIndicator");
            }
        }

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue CenterDockIndicatorHover
        {
            get
            {
                return new StyleValue(this, "CenterDockIndicatorHover");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CenterDockIndicatorWidth
        {
            get
            {
                return GetImageSize(this.CenterDockIndicator.BackgroundImage, Size.Empty).Width;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CenterDockIndicatorHeight
        {
            get
            {
                return GetImageSize(this.CenterDockIndicator.BackgroundImage, Size.Empty).Height;
            }
        }

        #endregion Center Indicator

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftColumnWidth
        {
            get
            {
                return LeftDockIndicatorWidth;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MiddleColumnWidth
        {
            get
            {
                return Math.Max(TopDockIndicatorWidth, Math.Max(CenterDockIndicatorWidth, BottomDockIndicatorWidth));
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightColumnWidth
        {
            get
            {
                return RightDockIndicatorWidth;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TopRowHeight
        {
            get
            {
                return TopDockIndicatorHeight;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MiddleRowHeight
        {
            get
            {
                return Math.Max(LeftDockIndicatorHeight, Math.Max(CenterDockIndicatorHeight, RightDockIndicatorHeight));
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BottomRowHeight
        {
            get
            {
                return BottomDockIndicatorHeight;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TotalWidth
        {
            get
            {
                return LeftColumnWidth + CenterDockIndicatorWidth + RightColumnWidth;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TotalHeight
        {
            get
            {
                return TopDockIndicatorHeight + CenterDockIndicatorHeight+ BottomRowHeight;
            }
        }
    }
}

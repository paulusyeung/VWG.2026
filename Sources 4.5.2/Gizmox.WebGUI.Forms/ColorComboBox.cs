#region Using

using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxBitmapAttribute(typeof(ListBox), "Gizmox.WebGUI.Forms.ColorListBox.bmp")]    
    [ToolboxItem(false)]
    [Skin(typeof(ColorComboBoxSkin))]
    [Serializable()]
    [Obsolete("Use Combo box insted of Color combo box")]   
    public class ColorComboBox : ComboBox
    {

        #region Classes
        
        #region ObjectCollection Class

        /// <summary>
        ///
        /// </summary>
        [Serializable()]
        public new class ObjectCollection : ComboBox.ObjectCollection
        {
            #region Class Members

            private ColorComboBox mobjParent = null;


            #endregion Class Members

            #region C'Tor / D'Tor

            /// <summary>
            /// Creates a new <see cref="ObjectCollection"/> instance.
            /// </summary>
            internal ObjectCollection(ColorComboBox objParent)
                : base(objParent)
            {
                mobjParent = objParent;
            }


            #endregion C'Tor / D'Tor

            #region Methods

            /// <summary>
            ///
            /// </summary>
            /// <param name="objColor"></param>
            public int Add(Color objColor)
            {
                return base.Add(objColor);
            }

            #endregion Methods

        }

        #endregion ObjectCollection Class 

        #endregion

        #region C'Tor\D'Tor

        /// <summary>
        /// Creates a new <see cref="ColorComboBox"/> instance.
        /// </summary>
        public ColorComboBox()
        {

        }

        #endregion C'Tor\D'Tor

        #region Properties


        /// <summary>
        /// Gets or sets the drop down style.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(ComboBoxStyle.DropDownList)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ComboBoxStyle DropDownStyle
        {
            get
            {
                return ComboBoxStyle.DropDownList;
            }
            set
            {
                if (value != ComboBoxStyle.DropDownList)
                {
                    throw new ArgumentException("ColorComboBox.DropDropDownStyle can only be DropDownList", "DropDownStyle");
                }
            }
        } 

        #endregion

        #region Methods

        #region Render
        
        public override string GetItemText(object objItem)
        {

            if (objItem is Color)
            {
                return ((Color)objItem).Name;
            }
            else
            {
                return "White";
            }
        }

		
		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <value></value>
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
		[SRCategory("CatData")]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
		[Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#else
        [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        new public ComboBox.ObjectCollection Items
		{
			get
			{
				return (ComboBox.ObjectCollection)base.Items;
			}
		}

        #endregion Render



        /// <summary>
        ///
        /// </summary>
        protected override ComboBox.ObjectCollection CreateItemCollection()
        {
            return new ColorComboBox.ObjectCollection(this);
        }




        #endregion Methods

        /// <summary>
        /// Should render color.        
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldRenderColor()
        {
            return true;
        }


    }
}

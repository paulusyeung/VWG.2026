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
    #region Enums



    #endregion Enums

    #region ColorListBox Class

    /// <summary>
    /// Summary description for ColorListBox.
    /// </summary>
    [ToolboxItem(false)]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColorListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColorListBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColorListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColorListBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColorListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColorListBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColorListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColorListBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColorListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColorListBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColorListBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColorListBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ColorListBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColorListBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColorListBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColorListBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolboxBitmapAttribute( typeof(ListBox), "Gizmox.WebGUI.Forms.ColorListBox.bmp")]            
    [Skin(typeof(ColorListBoxSkin))]
    [Serializable()]
    [Obsolete("Use List box insted of Color list box")]   
	public class ColorListBox : ListBox
    {


        #region C'Tor\D'Tor

        /// <summary>
        /// Creates a new <see cref="ColorListBox"/> instance.
        /// </summary>
        public ColorListBox()
        {

        }


        #endregion C'Tor\D'Tor

        #region Methods

        #region Render

    
		
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
        new public ListBox.ObjectCollection Items
		{
			get
			{
				return (ListBox.ObjectCollection)base.Items;
			}
		}

        #endregion Render



        /// <summary>
        ///
        /// </summary>
        protected override ListBox.ObjectCollection CreateItemCollection()
        {
            return new ColorListBox.ObjectCollection(this);
        }




        #endregion Methods


        #region ObjectCollection Class

        /// <summary>
        /// 
        /// </summary>

        [Serializable()]
        new public class ObjectCollection : ListBox.ObjectCollection
        {
            #region Class Members

            private ColorListBox mobjParent = null;


            #endregion Class Members

            #region C'Tor / D'Tor

            /// <summary>
            /// Creates a new <see cref="ObjectCollection"/> instance.
            /// </summary>
            internal ObjectCollection(ColorListBox objParent)
                : base(objParent)
            {
                mobjParent = objParent;
            }


            #endregion C'Tor / D'Tor

            #region Methods

            /// <summary>
            /// Adds the specified obj color.
            /// </summary>
            /// <param name="objColor">Color of the obj.</param>
            /// <returns></returns>
            public int Add(Color objColor)
            {
                return base.Add(objColor);
            }

            #endregion Methods

        }

        #endregion ObjectCollection Class

        /// <summary>
        /// Should render color.        
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldRenderColor()
        {
            return true;
        }
    }

    #endregion ColorListBox Class



}

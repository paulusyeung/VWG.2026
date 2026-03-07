using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Specifies the layout of multiple document interface (MDI) child windows in an MDI parent window.
    /// </summary>
    
	public enum MdiLayout
    {
        /// <summary>
        /// All MDI child windows are cascaded within the client region of the MDI parent form.
        /// </summary>
        Cascade,
        /// <summary>
        /// All MDI child windows are tiled horizontally within the client region of the MDI parent form.
        /// </summary>
        TileHorizontal,
        /// <summary>
        /// All MDI child windows are tiled vertically within the client region of the MDI parent form.
        /// </summary>
        TileVertical,
        /// <summary>
        /// All MDI child icons are arranged within the client region of the MDI parent form.
        /// </summary>
        ArrangeIcons
    }
 


    /// <summary>
    /// Represents the container for multiple-document interface (MDI) child forms. This class cannot be inherited.
    /// </summary>
    [ToolboxItem(false), DesignTimeVisible(false)]
    [MetadataTag(WGTags.MdiClient)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.MdiClientSkin)), Serializable()]
    public sealed class MdiClient : Control
    {
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        private ArrayList ChildrenInternal
        {
            get
            {
                return this.GetValue<ArrayList>(MdiClient.ChildrenProperty);
            }
            set
            {
                this.SetValue<ArrayList>(MdiClient.ChildrenProperty, value);
            }
        }

        /// <summary>
        /// The Children property registration.
        /// </summary>
        private static readonly SerializableProperty ChildrenProperty = SerializableProperty.Register("Children", typeof(ArrayList), typeof(MdiClient));



        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> class. 
        /// </summary>
        public MdiClient()
        {
            this.ChildrenInternal = new ArrayList();
            base.SetStyle(ControlStyles.Selectable, false);
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Creates a new instance of the control collection for the control.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"/> assigned to the control.
        /// </returns>
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new ControlCollection(this);
        }

        /// <summary>
        /// Arranges the multiple-document interface (MDI) child forms within the MDI parent form.
        /// </summary>
        /// <param name="value">One of the <see cref="T:Gizmox.WebGUI.Forms.MdiLayout"></see> values that defines the layout of MDI child forms.</param>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void LayoutMdi(MdiLayout value)
        {
            Form objParentForm = this.Parent as Form;

            if (objParentForm != null &&
                objParentForm.IsMdiContainer &&
                objParentForm.OwnedForms.Length > 0)
            {
                int intFormIndex = 0;

                foreach (Form objChildForm in objParentForm.OwnedForms)
                {
                    objChildForm.StartPosition = FormStartPosition.Manual;

                    switch (value)
                    {
                        case MdiLayout.Cascade:
                            objChildForm.Top = intFormIndex * 29;
                            objChildForm.Left = intFormIndex * 22;
                            break;
                    }
                    objChildForm.UpdateParamsInternal(AttributeType.Layout);

                    intFormIndex ++;
                }
            }
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            if (this.Parent != null)
            {
                objWriter.WriteAttributeString(WGAttributes.MdiParent, this.Parent.ID.ToString());
            }
        }


        /// <summary>
        /// Shoulds the color of the serialize back.
        /// </summary>
        /// <returns></returns>
        internal override bool ShouldSerializeBackColor()
        {
            return (this.BackColor != SystemColors.AppWorkspace);
        }

        private bool ShouldSerializeLocation()
        {
            return false;
        }

        /// <summary>
        /// Shoulds the size of the serialize.
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldSerializeSize()
        {
            return false;
        }

        /// <summary>
        /// Gets or sets the background image displayed in the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> control.
        /// </summary>
        /// <returns>An <see cref="T:System.Drawing.Image"></see> that represents the image to display in the background of the control.</returns>
        [Localizable(true)]
        public override ResourceHandle BackgroundImage
        {
            get
            {
                ResourceHandle objBackgroundImage = base.BackgroundImage;
                if ((objBackgroundImage == null) && (this.ParentInternal != null))
                {
                    objBackgroundImage = this.ParentInternal.BackgroundImage;
                }
                return objBackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }

        }

        /// <summary>
        /// This property is not relevant to this class.
        /// </summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                if (((this.BackgroundImage != null) && (this.ParentInternal != null)) && (base.BackgroundImageLayout != this.ParentInternal.BackgroundImageLayout))
                {
                    return this.ParentInternal.BackgroundImageLayout;
                }
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }

        }



        /// <summary>
        /// Gets the child multiple-document interface (MDI) forms of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> control.
        /// </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> array that contains the child MDI forms of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see>.</returns>
        public Form[] MdiChildren
        {
            get
            {
                Form[] arrForms = new Form[this.ChildrenInternal.Count];
                this.ChildrenInternal.CopyTo(arrForms, 0);
                return arrForms;
            }
        }

        /// <summary>
        /// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> controls.
        /// </summary>

        [Serializable()]
        new public class ControlCollection : Control.ControlCollection
        {

            private MdiClient mobjOwner;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient.ControlCollection"></see> class, specifying the owner of the collection. 
            /// </summary>
            /// <param name="objOwner">The owner of the collection.</param>
            public ControlCollection(MdiClient objOwner) : base(objOwner)
            {
                this.mobjOwner = objOwner;
            }

            /// <summary>
            /// Adds a control to the multiple-document interface (MDI) Container.
            /// </summary>
            /// <param name="objControl">MDI Child Form to add. </param>
            public override void Add(Control objControl)
            {
                if (!(objControl is Form) || !((Form)objControl).IsMdiChild)
                {
                    throw new ArgumentException(SR.GetString("MDIChildAddToNonMDIParent"), "value");
                }
                this.mobjOwner.ChildrenInternal.Add((Form)objControl);
                base.Add(objControl);

            }

            /// <summary>
            /// Removes a child control.
            /// </summary>
            /// <param name="objValue">MDI Child Form to remove. </param>
            public override void Remove(Control objValue)
            {
                this.mobjOwner.ChildrenInternal.Remove(objValue);
                base.Remove(objValue);

            }
        }
    }
 

}

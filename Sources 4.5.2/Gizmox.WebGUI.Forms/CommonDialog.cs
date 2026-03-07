using System;
using System.ComponentModel;
using System.Collections;
using System.Text;
using System.Collections.Specialized;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System.Drawing;
using System.Drawing.Design;


namespace Gizmox.WebGUI.Forms
{
    /// <summary>Specifies the base class used for displaying dialog boxes on the screen.</summary>
    [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
    [ToolboxItem(false)]
    [ToolboxItemCategory("Dialogs")]
    [Skin(typeof(CommonDialogSkin))]
    [Serializable()]
    public abstract class CommonDialog : ComponentBase, ICommonDialog, ISkinable
    {

        #region CommonDialogForm Class

        /// <summary>
        /// 
        /// </summary>

        [Serializable()]
        protected class CommonDialogForm : Form, ICommonDialogHandler
        {
            #region Members

            /// <summary>
            /// Holds reference to the owner color dialog component
            /// </summary>
            private CommonDialog mobjCommonDialog = null;

            /// <summary>
            /// The dialog direct handler
            /// </summary>
            private EventHandler mobjDirectHandler = null;

            #endregion

            #region C'Tor

            /// <summary>
            /// 
            /// </summary>
            /// <param name="objCommonDialog"></param>
            public CommonDialogForm(CommonDialog objCommonDialog)
            {
                mobjCommonDialog = objCommonDialog;
            }

            #endregion

            /// <summary>
            /// Gets the theme related to the skinable component.
            /// </summary>
            /// <value>
            /// The theme related to the skinable component.
            /// </value>
            public override string Theme
            {
                get
                {
                    if (this.CommonDialogOwner != null)
                    {
                        return this.CommonDialogOwner.Theme;
                    }

                    return base.Theme;
                }
                set
                {
                    base.Theme = value;
                }
            }

            /// <summary>
            /// Gets the owner commong 
            /// </summary>
            protected CommonDialog CommonDialogOwner
            {
                get
                {
                    return mobjCommonDialog;
                }
            }

            /// <summary>
            /// Gets or sets the direct handler
            /// </summary>
            internal EventHandler DirectHandler
            {
                get
                {
                    return mobjDirectHandler;
                }
                set
                {
                    mobjDirectHandler = value;
                }
            }

            #region ICommonDialogHandler Members


            /// <summary>
            /// 
            /// </summary>
            EventHandler ICommonDialogHandler.DirectHandler
            {
                get
                {
                    return this.DirectHandler;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            DialogResult ICommonDialogHandler.DialogResult
            {
                get
                {
                    return this.DialogResult;
                }
            }

            #endregion
        }

        #endregion

        internal delegate void EventRaisedHander(IEvent objEvent);

        [ToolboxItem(false), Serializable()]

        internal class HtmlBoxHost : HtmlBox
        {

            private NameValueCollection mobjProperties = null;

            internal event EventRaisedHander EventRaised;

            protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
            {
                base.RenderAttributes(objContext, objWriter);

                if (mobjProperties != null)
                {
                    foreach (string strName in mobjProperties.AllKeys)
                    {
                        objWriter.WriteAttributeString(strName, mobjProperties[strName]);
                    }
                }
            }

            protected override void FireEvent(IEvent objEvent)
            {
                base.FireEvent(objEvent);

                if (EventRaised != null)
                {
                    EventRaised(objEvent);
                }
            }

            public override string Url
            {
                get
                {
                    string strUrl = base.Url;
                    if (strUrl != null)
                    {
                        if (strUrl.IndexOf("?") == -1)
                        {
                            return string.Format("{0}?id={1}", strUrl, this.ID);
                        }
                        else
                        {
                            return string.Format("{0}&id={1}", strUrl, this.ID);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                set
                {
                    base.Url = value;
                }
            }

            public string GetProperty(string strName)
            {
                if (mobjProperties == null)
                {
                    return null;
                }
                return mobjProperties[strName];
            }

            public void SetProperty(string strName, string strValue)
            {
                if (strValue == null && mobjProperties != null)
                {
                    mobjProperties.Remove(strValue);
                }

                if (mobjProperties == null)
                {
                    mobjProperties = new NameValueCollection();
                }

                mobjProperties[strName] = strValue;
            }

            internal void InvokeExecuter(params object[] arrParams)
            {
                this.InvokeMethodWithId("FrameControl_Execute", arrParams);
            }
        }

        /// <summary>Occurs when the user clicks the Help button on a common dialog box.</summary>
        [SRDescription("CommonDialogHelpRequested")]
        public event EventHandler HelpRequest;

        /// <summary>
        /// The form close event
        /// </summary>
        public event EventHandler Closed;

        /// <summary>
        /// Holds the user data
        /// </summary>
        private object mobjTag = null;

        /// <summary>
        /// 
        /// </summary>
        private string mstrTheme = string.Empty;


        /// <summary>
        /// The last dialog result
        /// </summary>
        private DialogResult menmDialogResult = DialogResult.None;

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CommonDialog"></see> class.</summary>
        public CommonDialog()
        {
        }


        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.CommonDialog.HelpRequest"></see> event.</summary>
        /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.HelpEventArgs"></see> that provides the event data. </param>
        protected virtual void OnHelpRequest(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.HelpRequest;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.CommonDialog.Close"></see> event.</summary>
        /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.EventArgs"></see> that provides the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnClosed(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.Closed;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>When overridden in a derived class, resets the properties of a common dialog box to their default values.</summary>
        public abstract void Reset();

        /// <summary>Runs a common dialog box with a default owner.</summary>
        /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
        public DialogResult ShowDialog()
        {
            return this.ShowDialog(null, null, true);
        }

        /// <summary>Runs a common dialog box with a default owner.</summary>
        /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
        /// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
        public DialogResult ShowDialog(bool blnShowModalMask)
        {
            return this.ShowDialog(null, null, blnShowModalMask);
        }

        /// <summary>Runs a common dialog box with a default owner.</summary>
        /// <param name="objEventHandler">Event handler for dialog closed event</param>
        /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
        public DialogResult ShowDialog(EventHandler objEventHandler)
        {
            return this.ShowDialog(null, objEventHandler, true);
        }

        /// <summary>Runs a common dialog box with a default owner.</summary>
        /// <param name="objEventHandler">Event handler for dialog closed event</param>
        /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
        /// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>                
        public DialogResult ShowDialog(EventHandler objEventHandler, bool blnShowModalMask)
        {
            return this.ShowDialog(null, objEventHandler, blnShowModalMask);
        }


        /// <summary>Runs a common dialog box with the specified owner.</summary>
        /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
        /// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box. </param>
        public DialogResult ShowDialog(Form objOwner)
        {
            return this.ShowDialog(objOwner, null, true);
        }

        /// <summary>Runs a common dialog box with the specified owner.</summary>
        /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
        /// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box. </param>
        /// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>                        
        public DialogResult ShowDialog(Form objOwner, bool blnShowModalMask)
        {
            return this.ShowDialog(objOwner, null, blnShowModalMask);
        }

        /// <summary>Runs a common dialog box with the specified owner.</summary>
        /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
        /// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box. </param>
        /// <param name="objEventHandler">Event handler for dialog closed event</param>
        public DialogResult ShowDialog(Form objOwner, EventHandler objEventHandler)
        {
            return this.ShowDialog(objOwner, objEventHandler, true);
        }

        /// <summary>
        /// Runs a common dialog box with the specified owner.
        /// </summary>
        /// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box.</param>
        /// <param name="objEventHandler">The obj event handler.</param>
        /// <param name="blnShowModalMask">if set to <c>true</c> [BLN show modal mask].</param>
        /// <returns>
        /// 	<see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.
        /// </returns>
        public DialogResult ShowDialog(Form objOwner, EventHandler objEventHandler, bool blnShowModalMask)
        {
            DialogResult enmDialogResult = Forms.DialogResult.None;

            // If the context supports common dialog handling
            IContextCommonDialogHandler objCommonDialogHandler = VWGContext.Current as IContextCommonDialogHandler;
            if (objCommonDialogHandler != null)
            {
                objCommonDialogHandler.ShowDialog(this, objOwner, new EventHandler(CommonDialogForm_Closed), objEventHandler);
            }
            else
            {
                CommonDialogForm objCommonDialogForm = CreateForm();
                if (objCommonDialogForm != null)
                {
                    if (objEventHandler != null)
                    {
                        objCommonDialogForm.DirectHandler = objEventHandler;
                    }

                    objCommonDialogForm.ModalMask = blnShowModalMask;
                    objCommonDialogForm.Closed += new EventHandler(CommonDialogForm_Closed);
                    if (objOwner != null)
                    {
                        enmDialogResult = objCommonDialogForm.ShowDialog(objOwner);
                    }
                    else
                    {
                        enmDialogResult = objCommonDialogForm.ShowDialog();
                    }
                }
            }

            return enmDialogResult;
        }

        /// <summary>
        /// Displays the form as a popup window.
        /// </summary>
        public DialogResult ShowPopup(Form objOwnerForm, IRegisteredComponent objComponent, EventHandler objEventHandler, DialogAlignment enmAlignment, Point objPopupLocation)
        {
            DialogResult enmDialogResult = Forms.DialogResult.None;

            CommonDialogForm objCommonDialogForm = CreateForm();
            if (objCommonDialogForm != null)
            {
                if (objEventHandler != null)
                {
                    objCommonDialogForm.DirectHandler = objEventHandler;
                }

                objCommonDialogForm.Closed += new EventHandler(CommonDialogForm_Closed);
                if (objPopupLocation.IsEmpty)
                {
                    enmDialogResult = objCommonDialogForm.ShowPopup(objOwnerForm, objComponent, DialogAlignment.Below);
                }
                else
                {
                    objCommonDialogForm.Location = objPopupLocation;
                    objCommonDialogForm.StartPosition = FormStartPosition.Manual;
                    enmDialogResult = objCommonDialogForm.ShowPopup(objOwnerForm, objComponent, DialogAlignment.Custom);
                }
            }

            return enmDialogResult;
        }

        /// <summary>
        /// Displays the form as a popup window.
        /// </summary>
        public DialogResult ShowPopup(Form objOwnerForm, IRegisteredComponentMember objComponentMember, EventHandler objEventHandler, DialogAlignment enmAlignment, Point objPopupLocation)
        {
            DialogResult enmDialogResult = Forms.DialogResult.None;

            CommonDialogForm objCommonDialogForm = CreateForm();
            if (objCommonDialogForm != null)
            {
                if (objEventHandler != null)
                {
                    objCommonDialogForm.DirectHandler = objEventHandler;
                }

                objCommonDialogForm.Closed += new EventHandler(CommonDialogForm_Closed);
                if (objPopupLocation.IsEmpty)
                {
                    enmDialogResult = objCommonDialogForm.ShowPopup(objOwnerForm, objComponentMember, DialogAlignment.Below);
                }
                else
                {
                    objCommonDialogForm.Location = objPopupLocation;
                    objCommonDialogForm.StartPosition = FormStartPosition.Manual;
                    enmDialogResult = objCommonDialogForm.ShowPopup(objOwnerForm, objComponentMember, DialogAlignment.Custom);
                }
            }

            return enmDialogResult;
        }

        /// <summary>
        /// Handles the form close event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CommonDialogForm_Closed(object sender, EventArgs e)
        {
            ICommonDialogHandler objCommonDialogHandler = (ICommonDialogHandler)sender;
            if (objCommonDialogHandler != null)
            {
                // Get the last dialog result
                menmDialogResult = objCommonDialogHandler.DialogResult;

                // Raise common dialog subscribers
                OnClosed(EventArgs.Empty);

                // Raise direct subscriber
                if (objCommonDialogHandler.DirectHandler != null)
                {
                    objCommonDialogHandler.DirectHandler(this, EventArgs.Empty);
                }
            }
        }


        /// <summary>
        /// Creates a dialog for instance for the current common dialog
        /// </summary>
        /// <returns></returns>
        protected abstract CommonDialogForm CreateForm();

        /// <summary>
        /// Returns the last dialog result
        /// </summary>
        public DialogResult DialogResult
        {
            get
            {
                return menmDialogResult;
            }
        }

        /// <summary>Gets or sets an object that contains data about the control. </summary>
        /// <filterpriority>1</filterpriority>
        [DefaultValue((string)null), TypeConverter(typeof(StringConverter)), Bindable(true), Localizable(false), SRCategory("CatData"), SRDescription("ControlTagDescr")]
        public object Tag
        {
            get
            {
                return mobjTag;
            }
            set
            {
                mobjTag = value;
            }
        }

        /// <summary>
        /// Gets the theme related to the skinable component.
        /// </summary>
        /// <value>
        /// The theme related to the skinable component.
        /// </value>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        [WebEditor(typeof(WebThemeEditor), typeof(WebUITypeEditor)), SRCategory("CatAppearance")]
        [SRDescription("ControlThemeDescr"), DefaultValue("Inherit"), ProxyBrowsable(true)]
        public string Theme
        {
            get
            {
                return mstrTheme;
            }
            set
            {
                mstrTheme = value;
            }
        }

        #region Skinning Related

        /// <summary>
        /// The skin of the current control
        /// </summary>
        [NonSerialized()]
        private CommonDialogSkin mobjSkin = null;
        
        /// <summary>
        /// Gets the skin of the current control.
        /// </summary>
        /// <value>The skin of the current control.</value>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        protected CommonDialogSkin Skin
        {
            get
            {
                // If skin was not yet registered
                if (mobjSkin == null)
                {
                    // Register control for skinning
                    mobjSkin = (CommonDialogSkin)SkinFactory.GetSkin(this);
                }
                return mobjSkin;
            }
        }

        /// <summary>
        /// Gets the theme related to the skinable component.
        /// </summary>
        /// <value>The theme related to the skinable component.</value>
        string ISkinable.Theme
        {
            get
            {
                IContext objContext = VWGContext.Current;
                if (objContext != null)
                {
                    return objContext.CurrentTheme;
                }
                return "Default";
            }
        }

        #endregion

        /// <summary>
        /// Handles apply event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnApply(EventArgs e)
        {

        }

        #region ICommonDialog Members

        /// <summary>
        /// Execute the apply event
        /// </summary>
        void ICommonDialog.OnApply()
        {
            OnApply(EventArgs.Empty);
        }

        #endregion

    }
}
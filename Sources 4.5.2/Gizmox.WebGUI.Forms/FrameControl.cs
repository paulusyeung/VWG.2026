using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    #region FrameControl Class

    /// <summary>
    /// Provides a base class that allows invocation of methods that reside inside controls that have frames
    /// </summary>
    [Skin(typeof(FrameControlSkin))]
    [Serializable()]
    [MetadataTag(WGTags.FrameControl)]
    public abstract class FrameControl : Control
    {
        /// <summary>
        /// Invokes a client side method on the hosted control frame.
        /// </summary>
        /// <param name="strMember">The client side method name.</param>
        /// <param name="arrArgs">The arugments to be passed to the method</param>
        public void InvokeClientMethod(string strMember, params object[] arrArgs)
        {
            // Initialize new list for the arguments
            List<object> objArgsWithIdAndMember = new List<object>();
            
            // Add this control's ID
            objArgsWithIdAndMember.Add(this.ID.ToString());

            // Add the given member
            objArgsWithIdAndMember.Add(strMember);

            // Add the arguments
            objArgsWithIdAndMember.AddRange(arrArgs);
            
            // Invoke the method with the list of arguments
            InvokeMethod("Remoting_ServerInvokeTargetMember", objArgsWithIdAndMember.ToArray());
        }

        protected override ControlSkipMultiTheme SkipMultiTheme
        {
            get
            {
                // If the source starts with url, we dont want to have the begining ../Vista/<Url> in the src of the iframe.
                if (Source != null && Source.StartsWith("http"))
                {
                    return ControlSkipMultiTheme.Url;
                }

                return base.SkipMultiTheme;
            }
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // If control is not in inline mode
            if (!this.IsInline)
            {
                objWriter.WriteAttributeString(WGAttributes.Source, this.Source);
            }
            else
            {
                objWriter.WriteAttributeText(WGAttributes.Source, this.Source);
            }

            // Write the is inline mode attribute
            objWriter.WriteAttributeString(WGAttributes.IsInline, this.IsInline ? "1" : "0");
        }



        /// <summary>
        /// Indicates if the framecontrol should render source as inline html of as a url for 
        /// a frame.
        /// </summary>
        protected virtual bool IsInline
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        protected abstract string Source
        {
            get;
        }
    }

    #endregion
}

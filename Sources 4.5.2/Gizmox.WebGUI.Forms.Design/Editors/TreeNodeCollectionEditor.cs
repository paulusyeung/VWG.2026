using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// TreeNodeCollectionEditor class.
    /// </summary>
    public class TreeNodeCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {
        #region Members

        private IComponentChangeService mobjComponentChangeService = null; 

        #endregion

		#region Constructors 

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNodeCollectionEditor"/> class.
        /// </summary>
        public TreeNodeCollectionEditor() : base(typeof(TreeNodeCollection))
        {
        }

		#endregion Constructors 

		#region Methods 

        /// <summary>
        /// Edits the value.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objProvider">The obj provider.</param>
        /// <param name="objValue">The obj value.</param>
        /// <returns></returns>
        public override object EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue)
        {
            // Validate recieved context.
            if (objContext != null)
            {
                // Try getting the component change service.
                mobjComponentChangeService = (IComponentChangeService)objContext.GetService(typeof(IComponentChangeService));
                if (mobjComponentChangeService != null)
                {
                    // Register the component changed event.
                    mobjComponentChangeService.ComponentChanged += new ComponentChangedEventHandler(objComponentChangeService_ComponentChanged);
                }
            }

            try
            {
                // Perform base's EditValue.
                objValue = base.EditValue(objContext, objProvider, objValue);
            }
            finally
            {
                if (mobjComponentChangeService != null)
                {
                    // Unregister the component changed event.
                    mobjComponentChangeService.ComponentChanged -= new ComponentChangedEventHandler(objComponentChangeService_ComponentChanged);
                }
            }

            // Return new value.
            return objValue;
        }

        /// <summary>
        /// Handles the ComponentChanged event of the objComponentChangeService control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objComponentChangedEventArgs">The <see cref="System.ComponentModel.Design.ComponentChangedEventArgs"/> instance containing the event data.</param>
        void objComponentChangeService_ComponentChanged(object objSender, ComponentChangedEventArgs objComponentChangedEventArgs)
        {
            // Cast recieved component to a tree node.
            TreeNode objTreeNode = objComponentChangedEventArgs.Component as TreeNode;
            if (objTreeNode != null)
            {
                // Try get node's parent.
                TreeNode objParentNode = objTreeNode.Parent;
                if (objParentNode != null)
                {
                    if (mobjComponentChangeService != null)
                    {
                        // Notify that node's parent was changed.
                        mobjComponentChangeService.OnComponentChanged(objParentNode, null, null, null);
                    }
                }
            }
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <returns></returns>
        protected override object CreateInstance(Type objType)
        {
            object objInstance = base.CreateInstance(objType);

            TreeNode objTreeNode = objInstance as TreeNode;
            if (objTreeNode != null)
            {
                objTreeNode.Text = objTreeNode.Name;
            }            

            return objInstance;
        }


		#endregion Methods 
    }
}

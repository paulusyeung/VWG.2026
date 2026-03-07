using System;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using WinForms = System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Common.Configuration;

namespace Gizmox.WebGUI.Forms.Design.Editors
{
    /// <summary>
    /// 
    /// </summary>
    public class ThemeEditor : ObjectSelectorEditor
    {
        public ThemeEditor()
        { 
        }
        
        /// <summary>
        /// Fills a hierarchical collection of labeled items, with each item represented by a <see cref="T:System.Windows.Forms.TreeNode" />.
        /// </summary>
        /// <param name="selector">A hierarchical collection of labeled items.</param>
        /// <param name="context">The context information for a component.</param>
        /// <param name="provider">The <see cref="M:System.IServiceProvider.GetService(System.Type)" /> method of this interface that obtains the object that provides the service.</param>
        protected override void FillTreeWithData(ObjectSelectorEditor.Selector selector, ITypeDescriptorContext context, IServiceProvider provider)
        {
            base.FillTreeWithData(selector, context, provider);

            selector.Nodes.Add(new SelectorNode("Inherit", "Inherit"));

            foreach (string strTheme in ConfigHelper.AvailableThemes)
            {
                selector.Nodes.Add(new SelectorNode(strTheme, strTheme));
            }
        }
    }
}
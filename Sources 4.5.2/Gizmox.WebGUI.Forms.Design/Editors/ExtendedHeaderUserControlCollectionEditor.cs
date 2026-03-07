using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.VisualEffects;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Gizmox.WebGUI.Forms.Design.Editors
{
    /// <summary>
    /// 
    /// </summary>
    public class ExtendedHeaderUserControlCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {
        public ExtendedHeaderUserControlCollectionEditor()
            : base(typeof(Collection<ExtendedHeaderUserControl>))
        { }

        protected override Type[] CreateNewItemTypes()
        {
            List<Type> objTypes = new List<Type>();

            IDesignerHost objHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (objHost != null)
            {
                ITypeDiscoveryService objTypeDiscoveryService = (ITypeDiscoveryService)objHost.GetService(typeof(ITypeDiscoveryService));
                if (objTypeDiscoveryService != null)
                {
                    ICollection arrTypes = DesignerUtils.FilterGenericTypes(objTypeDiscoveryService.GetTypes(typeof(ExtendedHeaderUserControl), false));
                    if (arrTypes != null)
                    {
                        // Loop all types.
                        foreach (Type objType in arrTypes)
                        {
                            objTypes.Add(objType);
                        }
                    }
                }
            }

            return objTypes.ToArray();
        }
    }
}

using System;
using System.Text;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Reporting
{
    [AttributeUsage(AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
    //================================================================
    //This object should not be Serializable because it inherits from
    //a non serializable class.
    //In a case of a SQLServer session state, we'll serialize it ourself
    //================================================================
    internal sealed class SRDescriptionAttribute : DescriptionAttribute
    {
        private bool m_initialized;
        private string m_key;

        public SRDescriptionAttribute(string key)
        {
            this.m_key = key;
            this.m_initialized = false;
        }



        public override string Description
        {
            get
            {
                if (!this.m_initialized)
                {
                    // Todo: get strings from resources
                    this.m_initialized = true;
                }
                return base.Description;
            }
        }
 


 
    }

}

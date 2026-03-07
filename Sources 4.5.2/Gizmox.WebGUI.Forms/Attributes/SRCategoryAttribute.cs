#region Using

using System;
using System.ComponentModel;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
	#region SRCategoryAttribute Class
	
	/// <summary>
	/// Summary description for SRCategoryAttribute.
	/// </summary>
    [AttributeUsage(AttributeTargets.All), Serializable()]
    //================================================================
    //This object should not be Serializable because it inherits from
    //a non serializable class.
    //In a case of a SQLServer session state, we'll serialize it ourself
    //================================================================
	internal sealed class SRCategoryAttribute : CategoryAttribute
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
        public SRCategoryAttribute(string strCategory) : base(strCategory)
		{
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
        /// <param name="strValue"></param>
		protected override string GetLocalizedString(string strValue)
		{
			string strTranslation = SR.GetString(strValue);
			if(CommonUtils.IsNullOrEmpty(strTranslation))
			{
				strTranslation = strValue;
			}

			return strTranslation;
		}
		
		
		#endregion Methods
		
	}
	
	#endregion SRCategoryAttribute Class
	
}

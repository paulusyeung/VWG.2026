#region Using

using System;
using System.ComponentModel;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
	#region SRDescriptionAttribute Class
	

	/// <summary>
	///
	/// </summary>
    [AttributeUsage(AttributeTargets.All), Serializable()]
    //================================================================
    //This object should not be Serializable because it inherits from
    //a non serializable class.
    //In a case of a SQLServer session state, we'll serialize it ourself
    //================================================================
    internal sealed class SRDescriptionAttribute : DescriptionAttribute
	{
		#region Class Members
		
		private bool mblnReplaced;
		
		
		#endregion Class Members
		
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
        public SRDescriptionAttribute(string strDescription) : base(strDescription)
		{
			this.mblnReplaced = false;
		}
		
		
		#endregion C'Tor / D'Tor
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public override string Description
		{
			get
			{
				if (!this.mblnReplaced)
				{
					this.mblnReplaced = true;
					string strTranslation = SR.GetString(base.Description);
					if(!CommonUtils.IsNullOrEmpty(strTranslation))
					{
						base.DescriptionValue  = strTranslation;
					}
				}
				return base.Description;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion SRDescriptionAttribute Class
	
}

using System.ComponentModel.Design.Serialization;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class AspControlBoxCodeDomSerializer : ControlCodeDomSerializer
{
	public override object Serialize(IDesignerSerializationManager objManager, object value)
	{
		return base.Serialize((IDesignerSerializationManager)new AspControlBoxDesignerSerializationManager(objManager), value);
	}
}

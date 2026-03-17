using System.Collections;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class ControlCollectionCodeDomSerializer : CollectionCodeDomSerializer
{
	protected override bool PreferAddRange => false;

	protected override bool UseCollectionReversing(ICollection objCollection)
	{
		return false;
	}
}

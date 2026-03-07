using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    [Serializable]
    public class EntryMetadata : DevicePropertyDictionary, IMetadata
    {
        internal static EntryMetadata CreateFromVWGEvent(Common.Interfaces.IEvent objEvent)
        {
            EntryMetadata objEntryMetadata = new EntryMetadata();

            objEntryMetadata.ModificationTime = DateTime.ParseExact(objEvent["modificationTime"].Substring(0, 24), "ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            return objEntryMetadata;
        }

        public DateTime ModificationTime
        {
            get
            {
                return GetValuetypePropertyOrDefault<DateTime>("modificationTime");
            }
            set
            {
                AddValueTypeProperty("modificationTime", value);
            }
        }
    }
}

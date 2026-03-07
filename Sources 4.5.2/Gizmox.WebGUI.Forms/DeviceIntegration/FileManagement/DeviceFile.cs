using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Device.Common;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    [Serializable]
    public class DeviceFile : DevicePropertyDictionary, IDeviceFile
    {
        public static DeviceFile FromVWGEvent(IEvent objEvent)
        {
            ulong lngSize;
            long lngJavascriptDateTicks;

            DeviceFile objDeviceFile = new DeviceFile();

            objDeviceFile.FullPath = objEvent["fullPath"];
            if (long.TryParse(objEvent["lastModifiedDate"], out lngJavascriptDateTicks))
            {
                objDeviceFile.AddValueTypeProperty("lastModifiedDate", lngJavascriptDateTicks);
            }
            objDeviceFile.Name = objEvent["name"];
            if (ulong.TryParse(objEvent["size"], out lngSize))
            {
                objDeviceFile.Size = lngSize;
            }
            objDeviceFile.Type = objEvent["type"];

            return objDeviceFile;
        }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        public string FullPath
        {
            get
            {
                return GetNullableProperty<string>("fullPath");
            }
            internal set
            {
                SetNullableProperty("fullPath", value);
            }
        }

        /// <summary>
        /// Gets the last modified date.
        /// </summary>
        public DateTime LastModifiedDate
        {
            get
            {
                long lngJavascriptDateTicks = GetValuetypePropertyOrDefault<long>("lastModifiedDate");

                if (lngJavascriptDateTicks != 0)
                {
                    return new DateTime(lngJavascriptDateTicks * TimeSpan.TicksPerMillisecond + 621355968000000000);
                }

                return DateTime.MinValue;
            }
            internal set
            {
                AddValueTypeProperty("lastModifiedDate", value);
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return GetNullableProperty<string>("name");
            }
            internal set
            {
                SetNullableProperty("name", value);
            }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        public ulong Size
        {
            get
            {
                return GetValuetypePropertyOrDefault<ulong>("size");
            }
            internal set
            {
                AddValueTypeProperty("size", value);
            }
        }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        public string Type
        {
            get
            {
                return GetNullableProperty<string>("type");
            }
            internal set
            {
                SetNullableProperty("type", value);
            }
        }
    }
}

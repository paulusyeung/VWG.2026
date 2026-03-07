using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon
{
    [Serializable]
    public class JsonUtils
    {
        /// <summary>
        /// Deserializes the specified JSON string to T type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJSON">The STR JSON.</param>
        /// <returns></returns>
        public static T Deserialize<T>(string strJSON)
        {
            return JsonConvert.DeserializeObject<T>(strJSON);
        }

        /// <summary>
        /// Deserializes the specified JSON.
        /// </summary>
        /// <param name="strContact">The STR contact.</param>
        /// <returns></returns>
        public static JObject Deserialize(string strJSON)
        {
            return JsonConvert.DeserializeObject(strJSON) as JObject;
        }
    }
}

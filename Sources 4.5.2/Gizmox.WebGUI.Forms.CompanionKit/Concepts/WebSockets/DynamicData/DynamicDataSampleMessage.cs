using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSocketsSampleAppsCS
{
    public class DynamicDataSampleMessage : CompanionKitWebSocketMessage
    {
        /// <summary>
        /// Gets or sets the random values.
        /// </summary>
        /// <value>
        /// The random values.
        /// </value>
        public int[] RandomValues { get; set; }

        public DynamicDataSampleMessage()
        {
            this.RandomValues = new int[5];
        }
    }
}
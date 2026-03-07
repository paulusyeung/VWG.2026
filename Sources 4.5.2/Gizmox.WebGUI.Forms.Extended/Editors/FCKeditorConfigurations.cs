/*
 * FCKeditor - The text editor for internet
 * Copyright (C) 2003-2005 Frederico Caldeira Knabben
 * 
 * Licensed under the terms of the GNU Lesser General Public License:
 * 		http://www.opensource.org/licenses/lgpl-license.php
 * 
 * For further information visit:
 * 		http://www.fckeditor.net/
 * 
 * "Support Open Source software. What about a donation today?"
 * 
 * File Name: FCKeditorConfigurations.cs
 * 	Class that holds all editor configurations.
 * 
 * File Authors:
 * 		Frederico Caldeira Knabben (fredck@fckeditor.net)
 */

using System;
using System.Collections;
using System.Runtime.Serialization;

namespace Gizmox.WebGUI.Forms.Editors
{
    /// <summary>
    /// Hold the FCK editor Configurations
    /// </summary>
    [Serializable()]
    public class FCKeditorConfigurations : ISerializable
    {
        private Hashtable _Configs;

        internal FCKeditorConfigurations()
        {
            _Configs = new Hashtable();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FCKeditorConfigurations"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected FCKeditorConfigurations(SerializationInfo info, StreamingContext context)
        {
            _Configs = (Hashtable)info.GetValue("ConfigTable", typeof(Hashtable));
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String"/> with the specified configuration name.
        /// </summary>
        /// <value></value>
        public string this[string configurationName]
        {
            get
            {
                if (_Configs.ContainsKey(configurationName))
                    return (string)_Configs[configurationName];
                else
                    return null;
            }
            set
            {
                _Configs[configurationName] = value;
            }
        }

        internal string GetHiddenFieldString()
        {
            System.Text.StringBuilder osParams = new System.Text.StringBuilder();

            foreach (DictionaryEntry oEntry in _Configs)
            {
                if (osParams.Length > 0)
                    osParams.Append("&");

                osParams.AppendFormat("{0}={1}", oEntry.Key.ToString(), oEntry.Value.ToString());
            }

            return osParams.ToString();
        }

        #region ISerializable Members

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization.</param>
        /// <exception cref="T:System.Security.SecurityException">
        /// The caller does not have the required permission.
        /// </exception>
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue("ConfigTable", _Configs);
        }

        #endregion
    }
}

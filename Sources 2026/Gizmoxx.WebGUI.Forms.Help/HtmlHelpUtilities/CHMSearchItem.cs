using System;
using System.Collections;
using System.Text;

namespace Gizmox.WebGUI.Forms.HelpLibrary
{
    /// <summary>
    /// The class <c>HitEventArgs</c> implements the event parameters which occures if the user selects a search hit.
    /// </summary>
    
	internal class CHMSearchItem
    {
        private string mstrTitle = "";
        private string mstrUrl = "";
        private string mstrLocation = "";
        private double mstrRating = 0.0;

        /// <summary>
        /// Constructor of the event args
        /// </summary>
        /// <param name="title">the title of the topic</param>
        /// <param name="url">url selected by the user</param>
        /// <param name="location">location of the hit</param>
        /// <param name="rating">rating of the hit</param>
        public CHMSearchItem(string title, string url, string location, double rating)
        {
            mstrTitle = title;
            mstrUrl = url;
            mstrLocation = location;
            mstrRating = rating;
        }

        /// <summary>
        /// Gets the title of the selected topic
        /// </summary>
        public string Title
        {
            get { return mstrTitle; }
        }

        /// <summary>
        /// Gets the topic-url selected by the user
        /// </summary>
        public string URL
        {
            get { return mstrUrl; }
        }

        /// <summary>
        /// Gets the location of the selected topic
        /// </summary>
        public string Location
        {
            get { return mstrLocation; }
        }

        /// <summary>
        /// Gets the rating of the selected hit
        /// </summary>
        public double Rating
        {
            get { return mstrRating; }
        }
    }
}

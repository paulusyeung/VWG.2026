using System;
using System.Data;
using System.Configuration;


namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// 
    /// </summary>
    public class SEOException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SEOException"/> class.
        /// </summary>
        /// <param name="strMessage">The message.</param>
        /// <param name="objInnerException">The inner exception.</param>
        public SEOException(string strMessage, Exception objInnerException)
            : base(strMessage, objInnerException)
        {
        }
    }
}

using System;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.Util
{
    /// <summary>
    /// The class is used as object data sources.
    /// </summary>
    public class Customer
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private Color _favoriteColor;
        private global::Gizmox.WebGUI.Common.Resources.ResourceHandle _foto;

        /// <summary>
        /// Gets or sets customer id.
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }

            set 
            {
                _id = value;
            }
        }

        /// <summary>
        /// Gets or sets customer first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets customer last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        /// <summary>
        /// Gets customer full name.
        /// </summary>
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", _firstName, _lastName == null ? "" : _lastName);
            }
        }
        /// <summary>
        /// Gets or sets customer favorite color.
        /// </summary>
        public Color FavoriteColor
        {
            get
            {
                return _favoriteColor;
            }

            set
            {
                _favoriteColor = value;
            }
        }

        /// <summary>
        /// Gets or sets customer foto.
        /// </summary>
        public global::Gizmox.WebGUI.Common.Resources.ResourceHandle Foto
        {
            get
            {
                return _foto;
            }

            set
            {
                _foto = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <param name="firstName">Customer the first name</param>
        /// <param name="lastName">Customer the last name</param>
        /// <param name="favoriteColor">Customer favorite color</param>
        public Customer(int id, string firstName, string lastName, Color favoriteColor)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            FavoriteColor = favoriteColor;
        }
    }
}

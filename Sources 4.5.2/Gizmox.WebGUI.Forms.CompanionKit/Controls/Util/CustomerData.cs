using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.Util
{
    /// <summary>
    /// The class is used to get collection of customer object.
    /// </summary>
    public class CustomerData
    {
        /// <summary>
        /// Gets collection of Customer objects.
        /// </summary>
        /// <returns>Collection of customer objects</returns>
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer(1, "John", "John", Color.Red));
            customers.Add(new Customer(2, "Charlie", "Charlie", Color.Orange));
            customers.Add(new Customer(3, "Jacob", "Jacob", Color.Yellow));
            customers.Add(new Customer(4, "Steven", "Steven", Color.Green));
            return customers;
        }

        /// <summary>
        /// Gets collection of Customer objects with favorite foto.
        /// </summary>
        /// <param name="foto">Customer foto.</param>
        /// <returns></returns>
        public static List<Customer> GetCustomersWithImage(global::Gizmox.WebGUI.Common.Resources.ResourceHandle foto)
        {
            List<Customer> customers = GetCustomers();
            foreach (Customer customer in customers)
            {
                customer.Foto = foto;
            }
            return customers;
        }
    }
}

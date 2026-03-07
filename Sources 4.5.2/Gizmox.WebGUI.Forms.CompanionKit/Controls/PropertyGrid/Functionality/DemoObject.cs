using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Drawing;

namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    /// <summary>
    /// The enum to use to demostrate editing of a property in the PropertyGrid
    /// </summary>
    public enum DemoEnum
    {
        EnumValueA=1,
        EnumValueB=2,
        EnumValueC=4
    }

    /// <summary>
    /// A demo object to use to demostrate editing of a property 
    /// in the PropertyGrid.
    /// </summary>
    /// 
    [TypeConverter(typeof(DemoObjectConverter))]
    public class DemoObject
    {
        private int mintValueA = 1;
        private int mintValueB = 2;
        private int mintValueC = 3;
        private DemoEnum menmValueD = DemoEnum.EnumValueA;
        private Color menmColor = Color.LawnGreen;
        
        private string mstrValueA = "Initial A";
        private string mstrValueB = "Initial B";
        private string mstrValueC = "Initial C";

        [Category("Int Properties")]
        [Browsable(true)] // The default value
        [ReadOnly(true)]  // The default is read/write
        [Description("Integer ReadOnly property")]
        public int ValueA
        {
            get { return mintValueA; }
            set { mintValueA = value; }
        }
        
        [Category("Int Properties")]
        [Description("Integer Read/Write property")]
        public int ValueB
        {
            get { return mintValueB; }
            set { mintValueB = value; }
        }

        [Category("Advanced")]
        [Description("Integer Read/Write property in Advanced category")]
        public int ValueC
        {
            get { return mintValueC; }
            set { mintValueC = value; }
        }

        [Category("Strings")]
        [Description("String - 'A' Read/Write property in Strings category")]
        public string StringValueA
        {
            get { return mstrValueA; }
            set { mstrValueA = value; }
        }
        
        [Category("Strings")]
        [Description("String - 'B' Read/Write property in Strings category")]
        public string StringValueB
        {
            get { return mstrValueB; }
            set { mstrValueB = value; }
        }

        [Category("Advanced")]
        [Description("String - 'C' Read/Write property in Advanced category")]
        public string StringValueC
        {
            get { return mstrValueC; }
            set { mstrValueC = value; }
        }

        [Category("Enums")]
        [Description("The property with enum type")]
        public DemoEnum EnumProperty
        {
            get { return menmValueD; }
            set { menmValueD = value; }
        }


        [Category("Enums")]
        [Description("The property with enum type - Color")]
        public Color Color
        {
            get { return menmColor; }
            set { menmColor = value; }
        }

        /// <summary>
        /// String presentation of DemoObject
        /// </summary>
        public override string ToString()
        {
            return string.Format(
@"
StringValueA:{0}
StringValueB:{1}
StringValueC:{2}
ValueA:{3}
ValueB:{4}
ValueC:{5}
Color:{6}
EnumProperty:{7}
",
            this.StringValueA, this.StringValueB, this.StringValueC,
            this.ValueA, this.ValueB, this.ValueC,
            this.Color.ToString(),
            this.EnumProperty.ToString());
        }
    }
}

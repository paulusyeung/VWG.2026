using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Gizmox.WebGUI.Forms.SEO
{
    [Serializable]
    public class SEOPageInspector : SEOElement, ICloneable
    {
        /// <summary>
        /// 
        /// </summary>
        private bool mblnIsVisible;

        /// <summary>
        /// 
        /// </summary>
        private bool mblnShowAdvanced;

        /// <summary>
        /// 
        /// </summary>
        private int[] marrColumns = new int[] {200,200};

        /// <summary>
        /// 
        /// </summary>
        private SEOPageInspectorDocking menmDocking = SEOPageInspectorDocking.Bottom;




        /// <summary>
        /// 
        /// </summary>
        private SEOPageInspectorField[] mobjFields = new SEOPageInspectorField[] { };

        public SEOPageInspector()
        {
        }

        public SEOPageInspector(XmlElement objInspectorElement)
        {
            Load(objInspectorElement);
        }
	
        /// <summary>
        /// Loads the specified SEO element.
        /// </summary>
        /// <param name="objInspectorElement">The SEO element.</param>
        public override void Load(XmlElement objInspectorElement)
        {
            mblnIsVisible = SEOUtils.GetAttribute(objInspectorElement, "IsVisible", mblnIsVisible);
            mblnShowAdvanced = SEOUtils.GetAttribute(objInspectorElement, "ShowAdvanced", mblnShowAdvanced);
            mobjFields = SEOUtils.GetFields(objInspectorElement, "Fields", "Field");
            marrColumns = SEOUtils.GetArrayAttribute(objInspectorElement, "Columns", marrColumns);
            menmDocking = SEOUtils.GetAttribute<SEOPageInspectorDocking>(objInspectorElement, "Docking", menmDocking);
        }

        /// <summary>
        /// Saves the specified SEO element.
        /// </summary>
        /// <param name="objInspectorElement">The SEO element.</param>
        public override void Save(XmlElement objInspectorElement)
        {
            SEOUtils.SetAttribute(objInspectorElement, "IsVisible", mblnIsVisible);
            SEOUtils.SetAttribute(objInspectorElement, "ShowAdvanced", mblnShowAdvanced);
            SEOUtils.SetFields(objInspectorElement, "Fields", "Field", mobjFields);
            SEOUtils.SetArrayAttribute(objInspectorElement, "Columns", marrColumns);
            SEOUtils.SetAttribute(objInspectorElement, "Docking", menmDocking);
        }



        /// <summary>
        /// Gets or sets a value indicating whether this instance is visible.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible
        {
            get { return mblnIsVisible; }
            set { mblnIsVisible = value; }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [show advanced].
        /// </summary>
        /// <value><c>true</c> if [show advanced]; otherwise, <c>false</c>.</value>
        public bool ShowAdvanced
        {
            get { return mblnShowAdvanced; }
            set { mblnShowAdvanced = value; }
        }

        /// <summary>
        /// Gets or sets the docking.
        /// </summary>
        /// <value>The docking.</value>
        public SEOPageInspectorDocking Docking
        {
            get { return menmDocking; }
            set { menmDocking = value; }
        }


        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>The fields.</value>
        public SEOPageInspectorField[] Fields
        {
            get { return mobjFields; }
            internal set
            {
                if (value != null)
                {
                    mobjFields = value;
                }
                else
                {
                    mobjFields = new SEOPageInspectorField[] { };
                }
            }
        }

        /// <summary>
        /// Gets or sets the columns.
        /// </summary>
        /// <value>The columns.</value>
        public int[] Columns
        {
            get { return marrColumns; }
            set { marrColumns = value; }
        }

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            SEOPageInspector objClonedInspector = new SEOPageInspector();
            objClonedInspector.IsVisible = this.IsVisible;
            objClonedInspector.ShowAdvanced = this.ShowAdvanced;
            objClonedInspector.Fields = Clone(this.Fields);
            objClonedInspector.Docking = this.Docking;
            objClonedInspector.Columns = this.Columns;
            return objClonedInspector;
        }

        /// <summary>
        /// Clone a list of fields
        /// </summary>
        /// <param name="objFields"></param>
        /// <returns></returns>
        private SEOPageInspectorField[] Clone(SEOPageInspectorField[] objFields)
        {
            List<SEOPageInspectorField> objClonedFields = new List<SEOPageInspectorField>();
            foreach (SEOPageInspectorField objField in objFields)
            {
                objClonedFields.Add((SEOPageInspectorField)objField.Clone());
            }
            return objClonedFields.ToArray();
        }

        #endregion
    }
}

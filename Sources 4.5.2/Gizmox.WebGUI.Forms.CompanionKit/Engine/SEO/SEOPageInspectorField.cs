using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SEOPageInspectorField : SEOElement, ICloneable
    {
        /// <summary>
        /// 
        /// </summary>
        private string mstrLabel;

        /// <summary>
        /// 
        /// </summary>
        private SEOPageInspectorFieldType menmType;

        /// <summary>
        /// 
        /// </summary>
        private string mstrTargetName;

        /// <summary>
        /// 
        /// </summary>
        private string mstrPropertyName;

        /// <summary>
        /// 
        /// </summary>
        private int mintOrder;


        /// <summary>
        /// 
        /// </summary>
        private int mintColumn;


        public SEOPageInspectorField()
        {
        }

        public SEOPageInspectorField(XmlElement objFieldElement)
        {
            Load(objFieldElement);
        }

        /// <summary>
        /// Loads the specified field element.
        /// </summary>
        /// <param name="objFieldElement">The field element.</param>
        public override void Load(XmlElement objFieldElement)
        {
            mintColumn = SEOUtils.GetAttribute(objFieldElement, "Column", mintColumn);
            mintOrder = SEOUtils.GetAttribute(objFieldElement, "Order", mintOrder);
            menmType = SEOUtils.GetAttribute<SEOPageInspectorFieldType>(objFieldElement, "Type", menmType);
            mstrLabel = SEOUtils.GetAttribute(objFieldElement, "Label", mstrLabel);
            mstrTargetName = SEOUtils.GetAttribute(objFieldElement, "TargetName", mstrTargetName);
            mstrPropertyName = SEOUtils.GetAttribute(objFieldElement, "PropertyName", mstrPropertyName);
        }

        /// <summary>
        /// Saves the specified field element.
        /// </summary>
        /// <param name="objFieldElement">The field element.</param>
        public override void Save(XmlElement objFieldElement)
        {
            SEOUtils.SetAttribute(objFieldElement, "Column", mintColumn);
            SEOUtils.SetAttribute(objFieldElement, "Order", mintOrder);
            SEOUtils.SetAttribute(objFieldElement, "Type", menmType);
            SEOUtils.SetAttribute(objFieldElement, "Label", mstrLabel);
            SEOUtils.SetAttribute(objFieldElement, "TargetName", mstrTargetName);
            SEOUtils.SetAttribute(objFieldElement, "PropertyName", mstrPropertyName);
        }


        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label
        {
            get { return mstrLabel; }
            set { mstrLabel = value; }
        }


        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public SEOPageInspectorFieldType Type
        {
            get { return menmType; }
            set { menmType = value; }
        }


        /// <summary>
        /// Gets or sets the name of the target.
        /// </summary>
        /// <value>The name of the target.</value>
        public string TargetName
        {
            get { return mstrTargetName; }
            set { mstrTargetName = value; }
        }


        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        public string PropertyName
        {
            get { return mstrPropertyName; }
            set { mstrPropertyName = value; }
        }


        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order
        {
            get { return mintOrder; }
            set { mintOrder = value; }
        }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>The column.</value>
        public int Column
        {
            get { return mintColumn; }
            set { mintColumn = value; }
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
            SEOPageInspectorField objClonedField = new SEOPageInspectorField();
            objClonedField.Column = this.Column;
            objClonedField.Label = this.Label;
            objClonedField.Order = this.Order;
            objClonedField.PropertyName = this.PropertyName;
            objClonedField.TargetName = this.TargetName;
            objClonedField.Type = this.Type;
            return objClonedField;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SEOPageInspectorFieldType
    {
        /// <summary>
        /// 
        /// </summary>
        TextBox,

        /// <summary>
        /// 
        /// </summary>
        ComboBox,

        /// <summary>
        /// 
        /// </summary>
        CheckBox,

        /// <summary>
        /// 
        /// </summary>
        NumericUpDown,

        /// <summary>
        /// 
        /// </summary>
        Editor
    }
}

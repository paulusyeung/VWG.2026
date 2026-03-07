using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.VisualEffects;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Design.Editors
{
    /// <summary>
    /// 
    /// </summary>
    public class VisualEffectCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {

        #region Members

        System.ComponentModel.Design.CollectionEditor.CollectionForm mobjCollectionForm = null;

        #endregion Members

        #region Constructors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualEffectCollectionEditor"/> class.
        /// </summary>
        /// <param name="type">The type of the collection for this editor to edit.</param>
        public VisualEffectCollectionEditor(Type type)
            : base(typeof(List<VisualEffect>))
        {
        }

		#endregion Constructors 

		#region Methods (2) 

		// Public Methods (1) 

        /// <summary>
        /// Edits the value of the specified object using the specified service provider and context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <param name="provider">A service provider object through which editing services can be obtained.</param>
        /// <param name="value">The object to edit the value of.</param>
        /// <returns>
        /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Design.CheckoutException">An attempt to check out a file that is checked into a source code management program did not succeed.</exception>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            List<VisualEffect> objVisualEffects = new List<VisualEffect>();

            VisualEffectValueGroup objVisualEffectValueGroup = value as VisualEffectValueGroup;
            if (objVisualEffectValueGroup != null)
            {
                foreach (VisualEffectValue objVisualEffectValueItem in objVisualEffectValueGroup)
                {
                    VisualEffect objVisualEffect = objVisualEffectValueItem.VisualEffect;
                    if (objVisualEffect != null)
                    {
                        if (this.IsBrowsableVisualEffectType(objVisualEffect.GetType()))
                        {
                            objVisualEffects.Add((VisualEffect)objVisualEffect.Clone());
                        }
                    }
                }
            }
            else
            {
                VisualEffectValue objVisualEffectValue = value as VisualEffectValue;
                if (objVisualEffectValue != null)
                {
                    VisualEffect objVisualEffect = objVisualEffectValue.VisualEffect;
                    if (objVisualEffect != null)
                    {
                        if (this.IsBrowsableVisualEffectType(objVisualEffect.GetType()))
                        {
                            objVisualEffects.Add((VisualEffect)objVisualEffect.Clone());
                        }
                    }
                }
                else
                {
                    VisualEffectGroup objVisualEffectGroup = value as VisualEffectGroup;
                    if (objVisualEffectGroup != null)
                    {
                        foreach (VisualEffect objVisualEffect in objVisualEffectGroup.GetConstroctorArguments())
                        {
                            if (this.IsBrowsableVisualEffectType(objVisualEffect.GetType()))
                            {
                                objVisualEffects.Add((VisualEffect)objVisualEffect.Clone());
                            }
                        }
                    }
                    else
                    {
                        VisualEffect objVisualEffect = value as VisualEffect;
                        if (objVisualEffect != null)
                        {
                            if (this.IsBrowsableVisualEffectType(objVisualEffect.GetType()))
                            {
                                objVisualEffects.Add((VisualEffect)objVisualEffect.Clone());
                            }
                        }
                    }
                }
            }

            objVisualEffects = (List<VisualEffect>)(base.EditValue(context, provider, objVisualEffects));

            if (mobjCollectionForm != null && mobjCollectionForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (objVisualEffects != null)
                {
                    if (context.Instance is Skins.Skin || context.Instance is StyleValue)
                    {
                        if (objVisualEffects.Count > 1)
                        {
                            List<VisualEffectValue> objVisualEffectValues = new List<VisualEffectValue>();
                            foreach (VisualEffect objVisualEffectItem in objVisualEffects)
                            {
                                objVisualEffectValues.Add(new VisualEffectValue(objVisualEffectItem));
                            }

                            return new VisualEffectValueGroup(objVisualEffectValues.ToArray());
                        }
                        else if (objVisualEffects.Count == 1)
                        {
                            return new VisualEffectValue(objVisualEffects[0]);
                        }
                        else
                        {
                            return new VisualEffectValue(new EmptyVisualEffect());
                        }
                    }
                    else
                    {
                        if (objVisualEffects.Count > 1)
                        {
                            return new VisualEffectGroup(objVisualEffects.ToArray());
                        }
                        else if (objVisualEffects.Count == 1)
                        {

                            return objVisualEffects[0];
                        }
                        else
                        {
                            return new EmptyVisualEffect();
                        }
                    }
                }
            }
            else
            {
                return value;
            }

            return null;
        }
		// Protected Methods (1) 

        /// <summary>
        /// Creates a new form to display and edit the current collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm" /> to provide as the user interface for editing the collection.
        /// </returns>
        protected override System.ComponentModel.Design.CollectionEditor.CollectionForm CreateCollectionForm()
        {
            mobjCollectionForm = base.CreateCollectionForm();

            return mobjCollectionForm;
        }

        /// <summary>
        /// Gets the data types that this collection editor can contain.
        /// </summary>
        /// <returns>
        /// An array of data types that this collection can contain.
        /// </returns>
        protected override Type[] CreateNewItemTypes()
        {
            List<Type> objTypes = new List<Type>();

            IDesignerHost objHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (objHost != null)
            {
                ITypeDiscoveryService objTypeDiscoveryService = (ITypeDiscoveryService)objHost.GetService(typeof(ITypeDiscoveryService));
                if (objTypeDiscoveryService != null)
                {
                    ICollection arrTypes = DesignerUtils.FilterGenericTypes(objTypeDiscoveryService.GetTypes(typeof(VisualEffect), false));
                    if (arrTypes != null)
                    {
                        // Loop all types.
                        foreach (Type objType in arrTypes)
                        {
                            if (this.IsBrowsableVisualEffectType(objType))
                            {
                                if (!objTypes.Contains(objType))
                                {
                                    objTypes.Add(objType);
                                }
                            }
                        }
                    }
                }
            }

            return objTypes.ToArray();
        }

        /// <summary>
        /// Determines whether [is browsable visual effect type] [the specified obj type].
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <returns>
        ///   <c>true</c> if [is browsable visual effect type] [the specified obj type]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsBrowsableVisualEffectType(Type objType)
        {
            bool blnIsBrowsableVisualEffectType = objType != typeof(VisualEffect);

            if (blnIsBrowsableVisualEffectType)
            {
                object[] objAttributes = objType.GetCustomAttributes(typeof(BrowsableAttribute), true);
                if (objAttributes != null && objAttributes.Length == 1)
                {
                    BrowsableAttribute objBrowsableAttribute = objAttributes[0] as BrowsableAttribute;
                    if (objBrowsableAttribute != null)
                    {
                        blnIsBrowsableVisualEffectType = objBrowsableAttribute.Browsable;
                    }
                }
            }

            return blnIsBrowsableVisualEffectType;
        }

		#endregion Methods 
    }
}

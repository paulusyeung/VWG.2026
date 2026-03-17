using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Professional;

namespace Gizmox.WebGUI.Forms.Google.Design.Editors;

[Serializable]
public class GoogleMapOverlayCollectionWebEditor : CollectionEditor
{
	private static Type[] objManagedTypes;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.Design.Editors.GoogleMapOverlayCollectionWebEditor" /> class.
	/// </summary>
	/// <param name="objType">The type of the collection for this editor to edit.</param>
	public GoogleMapOverlayCollectionWebEditor(Type objType)
		: base(objType)
	{
	}

	/// <summary>
	/// Sets the specified array as the items of the collection.
	/// </summary>
	/// <param name="objEditValue">The collection to edit.</param>
	/// <param name="arrValues">An array of objects to set as the collection items.</param>
	/// <returns>
	/// The newly created collection object or, otherwise, the collection indicated by the editValue parameter.
	/// </returns>
	protected override object SetItems(object objEditValue, object[] arrValues)
	{
		if (objEditValue != null && objEditValue is GoogleMapOverlayCollection)
		{
			GoogleMapOverlayCollection googleMapOverlayCollection = (GoogleMapOverlayCollection)objEditValue;
			googleMapOverlayCollection.Clear();
			for (int i = 0; i < arrValues.Length; i++)
			{
				if (arrValues[i] is GoogleMapOverlay item)
				{
					googleMapOverlayCollection.Add(item);
				}
			}
		}
		return objEditValue;
	}

	/// <summary>
	/// Creates a new form to display and edit the current collection.
	/// </summary>
	/// <returns>
	/// A <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm"></see> to provide as the user interface for editing the collection.
	/// </returns>
	protected override CollectionForm CreateCollectionForm()
	{
		CollectionForm collectionForm = base.CreateCollectionForm();
		collectionForm.Text = "GoogleMap MapOverlays";
		_ = base.Context?.Instance;
		collectionForm.Closed += objForm_Closed;
		return collectionForm;
	}

	/// <summary>
	/// Handles the Closed event of the objForm control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	private void objForm_Closed(object sender, EventArgs e)
	{
		if (sender is Form)
		{
			ITypeDescriptorContext context = base.Context;
			if (context != null)
			{
				(context.Instance as Gizmox.WebGUI.Forms.Professional.GoogleMap).UpdateOverlays();
			}
		}
	}

	/// <summary>
	/// Provides list of types that can be added to the collection
	/// </summary>
	/// <returns></returns>
	protected override Type[] CreateNewItemTypes()
	{
		if (objManagedTypes != null)
		{
			return objManagedTypes;
		}
		ArrayList arrayList = new ArrayList();
		arrayList.Add(typeof(GoogleMapMarkerOverlay));
		Type[] types = Assembly.GetExecutingAssembly().GetTypes();
		foreach (Type type in types)
		{
			if (typeof(GoogleMapOverlay).IsAssignableFrom(type) && !(type == typeof(GoogleMapOverlay)) && !type.IsAbstract && (type.IsPublic || type.IsNestedPublic) && !arrayList.Contains(type))
			{
				arrayList.Add(type);
			}
		}
		objManagedTypes = (Type[])arrayList.ToArray(typeof(Type));
		return objManagedTypes;
	}

	/// <summary>
	/// Supply a friendly name for a GoogleMapOverlay instance
	/// </summary>
	/// <param name="objValue"></param>
	/// <returns></returns>
	protected override string GetDisplayText(object objValue)
	{
		if (objValue != null)
		{
			return objValue.GetType().Name;
		}
		return base.GetDisplayText(objValue);
	}
}

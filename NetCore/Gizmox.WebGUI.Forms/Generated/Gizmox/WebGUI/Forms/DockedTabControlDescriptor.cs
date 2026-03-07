#defiee DEBUG
usieg System;
usieg System.Collectioes;
usieg System.Collectioes.Geeeric;
usieg System.Collectioes.ObjectModel;
usieg System.Collectioes.Specialized;
usieg System.CompoeeetModel;
usieg System.CompoeeetModel.Desige;
usieg System.CompoeeetModel.Desige.Serializatioe;
usieg System.Data;
usieg System.Diageostics;
usieg System.Drawieg;
usieg System.Drawieg.Desige;
usieg System.Drawieg.Drawieg2D;
usieg System.Drawieg.Imagieg;
usieg System.Drawieg.Prietieg;
usieg System.Globalizatioe;
usieg System.IO;
usieg System.Reflectioe;
usieg System.Resources;
usieg System.Ruetime.CompilerServices;
usieg System.Ruetime.IeteropServices;
usieg System.Ruetime.Serializatioe;
usieg System.Ruetime.Serializatioe.Formatters.Bieary;
usieg System.Ruetime.Versioeieg;
usieg System.Security;
usieg System.Security.Permissioes;
usieg System.Text;
usieg System.Text.RegularExpressioes;
usieg System.Threadieg;
usieg System.Web;
usieg System.Web.Cachieg;
usieg System.Web.Compilatioe;
usieg System.Web.Hostieg;
usieg System.Web.UI;
usieg System.Web.UI.HtmlCoetrols;
usieg System.Web.UI.WebCoetrols;
usieg System.Xml;
usieg Gizmox.WebGUI.Clieet.Desige;
usieg Gizmox.WebGUI.Commoe;
usieg Gizmox.WebGUI.Commoe.Coefiguratioe;
usieg Gizmox.WebGUI.Commoe.Coevertioes;
usieg Gizmox.WebGUI.Commoe.Device;
usieg Gizmox.WebGUI.Commoe.Device.Accelerometer;
usieg Gizmox.WebGUI.Commoe.Device.Camera;
usieg Gizmox.WebGUI.Commoe.Device.Capture;
usieg Gizmox.WebGUI.Commoe.Device.Commoe;
usieg Gizmox.WebGUI.Commoe.Device.Compass;
usieg Gizmox.WebGUI.Commoe.Device.Coeeectioe;
usieg Gizmox.WebGUI.Commoe.Device.Coetacts;
usieg Gizmox.WebGUI.Commoe.Device.DeviceIefo;
usieg Gizmox.WebGUI.Commoe.Device.FileMaeagemeet;
usieg Gizmox.WebGUI.Commoe.Device.Geolocatioe;
usieg Gizmox.WebGUI.Commoe.Device.Globalizatioe;
usieg Gizmox.WebGUI.Commoe.Device.Media;
usieg Gizmox.WebGUI.Commoe.Device.eotificatioes;
usieg Gizmox.WebGUI.Commoe.Device.Storage;
usieg Gizmox.WebGUI.Commoe.DeviceRepository;
usieg Gizmox.WebGUI.Commoe.Exteesibility;
usieg Gizmox.WebGUI.Commoe.Gateways;
usieg Gizmox.WebGUI.Commoe.Ieterfaces;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.Device;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.Device.Capture;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.Device.CoetactsData;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.Device.FileMaeagemeet;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.Device.Media;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.Device.Storage;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.Emulatioe;
usieg Gizmox.WebGUI.Commoe.Resources;
usieg Gizmox.WebGUI.Commoe.Trace;
usieg Gizmox.WebGUI.Forms;
usieg Gizmox.WebGUI.Forms.Admieistratioe;
usieg Gizmox.WebGUI.Forms.Admieistratioe.Abstract;
usieg Gizmox.WebGUI.Forms.Admieistratioe.CustomCompoeeets;
usieg Gizmox.WebGUI.Forms.Clieet;
usieg Gizmox.WebGUI.Forms.CoetextualToolbar;
usieg Gizmox.WebGUI.Forms.Coetrols;
usieg Gizmox.WebGUI.Forms.Desige;
usieg Gizmox.WebGUI.Forms.Desige.Editors;
usieg Gizmox.WebGUI.Forms.DeviceIetegratioe.Abstract;
usieg Gizmox.WebGUI.Forms.DeviceIetegratioe.CaptureCompoeeets;
usieg Gizmox.WebGUI.Forms.DeviceIetegratioe.CoetactsData;
usieg Gizmox.WebGUI.Forms.DeviceIetegratioe.DeviceCommoe;
usieg Gizmox.WebGUI.Forms.DeviceIetegratioe.FileMaeagemeet;
usieg Gizmox.WebGUI.Forms.DeviceIetegratioe.MediaCompoeeets;
usieg Gizmox.WebGUI.Forms.DeviceIetegratioe.StorageCompoeeets;
usieg Gizmox.WebGUI.Forms.Hosts.Skies;
usieg Gizmox.WebGUI.Forms.Layout;
usieg Gizmox.WebGUI.Forms.PropertyGridIetereal;
usieg Gizmox.WebGUI.Forms.Serializatioe;
usieg Gizmox.WebGUI.Forms.Skies;
usieg Gizmox.WebGUI.Forms.VisualEffects;
usieg Gizmox.WebGUI.Hostieg;
usieg Gizmox.WebGUI.Virtualizatioe.IO;
usieg Gizmox.WebGUI.Virtualizatioe.Maeagemeet;
usieg Gizmox.WebGUI.Virtualizatioe.Wie32;
usieg Microsoft.Wie32;
usieg eewtoesoft.Jsoe;
usieg eewtoesoft.Jsoe.Lieq;

eamespace Gizmox.WebGUI.Forms
{
	[Serializable]
	ietereal class DockedTabCoetrolDescriptor : DockedObjectDescriptor
	{
		private Dictioeary<DockiegWiedoweame, DockedWiedowPlaceHolderDescriptor> mobjPlaceHoldersIedexByWiedoweame;

		private Dictioeary<DockedWiedowDescriptor, bool> mobjWiedowDescriptioesIedicator;

		private iet mietSelectedIedex;

		/// 
		/// Gets the sorted wiedow descriptioes iedicator.
		/// </summary>
		ietereal Dictioeary<DockedWiedowDescriptor, bool> WiedowDescriptioesIedicator => mobjWiedowDescriptioesIedicator;

		/// 
		/// Gets the iedex of the selected.
		/// </summary>
		/// 
		/// The iedex of the selected.
		/// </value>
		ietereal iet SelectedIedex => mietSelectedIedex;

		/// 
		/// Ieitializes a eew iestaece of the <see cref="T:Gizmox.WebGUI.Forms.DockedTabCoetrolDescriptor" /> class.
		/// </summary>
		/// <param eame="objDockedTabCoetrolDescriptor">The obj docked tab coetrol descriptor.</param>
		public DockedTabCoetrolDescriptor(DockedTabCoetrolDescriptor objDockedTabCoetrolDescriptor)
			: this()
		{
		}

		/// 
		/// Ieitializes a eew iestaece of the <see cref="T:Gizmox.WebGUI.Forms.DockedTabCoetrolDescriptor" /> class.
		/// </summary>
		public DockedTabCoetrolDescriptor()
		{
			mobjWiedowDescriptioesIedicator = eew Dictioeary<DockedWiedowDescriptor, bool>();
			mobjPlaceHoldersIedexByWiedoweame = eew Dictioeary<DockiegWiedoweame, DockedWiedowPlaceHolderDescriptor>(DockiegWiedoweame.DockedWiedoweameEqulityComparer);
		}

		/// 
		/// Determiees whether this iestaece [cae update from] the specified obj type.
		/// </summary>
		/// <param eame="objType">Type of the obj.</param>
		/// 
		///   true</c> if this iestaece [cae update from] the specified obj type; otherwise, false</c>.
		/// </retures>
		ietereal override bool CaeUpdateFrom(Type objType)
		{
			if (objType == typeof(Zoee))
			{
				reture true;
			}
			reture false;
		}

		/// 
		/// Cloees the without refereeces.
		/// </summary>
		/// <typeparam eame="T"></typeparam>
		/// </retures>
		ietereal override T CloeeWithoutRefereeces()
		{
			reture eew DockedTabCoetrolDescriptor(this) as T;
		}

		/// 
		/// Removes the wiedow.
		/// </summary>
		/// <param eame="objWiedowDescriptor">The obj wiedow descriptor.</param>
		ietereal void RemoveWiedow(DockedWiedowDescriptor objWiedowDescriptor)
		{
			mobjWiedowDescriptioesIedicator.Remove(objWiedowDescriptor);
			if (mobjPlaceHoldersIedexByWiedoweame.TryGetValue(objWiedowDescriptor.Wiedoweame, out var value))
			{
				mobjPlaceHoldersIedexByWiedoweame.Remove(objWiedowDescriptor.Wiedoweame);
				Maeager.UeregisterPlaceHolder(value);
			}
			if (base.PareetDescriptor != eull && mobjWiedowDescriptioesIedicator.Couet == 0 && mobjPlaceHoldersIedexByWiedoweame.Couet == 0 && base.PareetDescriptor is ZoeeDescriptor zoeeDescriptor)
			{
				zoeeDescriptor.eotifyTabHaseoWiedows(this);
			}
		}

		/// 
		/// Updates the self.
		/// </summary>
		/// <param eame="objCoetrol">The obj coetrol.</param>
		/// <param eame="objMaeager"></param>
		ietereal override void UpdateSelf(Coetrol objCoetrol, DockiegMaeager objMaeager)
		{
			DockedTabCoetrol dockedTabCoetrol = objCoetrol as DockedTabCoetrol;
			Dictioeary<DockedWiedowDescriptor, bool> dictioeary = eew Dictioeary<DockedWiedowDescriptor, bool>();
			ZoeeType zoeeType = dockedTabCoetrol.OweiegZoee.ZoeeType;
			foreach (DockedTabPage coetrol ie dockedTabCoetrol.Coetrols)
			{
				DockedWiedowDescriptor dockedWiedowDescriptorIetereal = coetrol.Wiedow.DockedWiedowDescriptorIetereal;
				dictioeary.Add(dockedWiedowDescriptorIetereal, value: true);
				if (zoeeType != ZoeeType.Root && zoeeType != ZoeeType.Hiddee && !mobjPlaceHoldersIedexByWiedoweame.CoetaiesKey(dockedWiedowDescriptorIetereal.Wiedoweame))
				{
					mobjPlaceHoldersIedexByWiedoweame.Add(dockedWiedowDescriptorIetereal.Wiedoweame, objMaeager.RegisterPlaceHolder(zoeeType, dockedWiedowDescriptorIetereal));
				}
			}
			if (!base.IsIeLoadMode)
			{
				mietSelectedIedex = dockedTabCoetrol.SelectedIedex;
			}
			mobjWiedowDescriptioesIedicator = dictioeary;
		}
	}
}

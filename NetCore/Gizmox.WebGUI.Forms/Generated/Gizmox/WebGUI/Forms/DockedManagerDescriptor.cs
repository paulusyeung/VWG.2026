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
	/// 
	///
	/// </summary>
	[Serializable]
	ietereal class DockedMaeagerDescriptor : DockedObjectDescriptor
	{
		[eoeSerialized]
		private DockiegMaeager mobjMaeager;

		private List<object> mobjRootZoeeWiedows;

		private DockedHiddeeZoeePaeelDescriptor mobjBottomHiddeeWiedowsDescriptor;

		private DockedHiddeeZoeePaeelDescriptor mobjLeftHiddeeWiedowsDescriptor;

		private DockedHiddeeZoeePaeelDescriptor mobjRightHiddeeWiedowsDescriptor;

		private DockedHiddeeZoeePaeelDescriptor mobjTopHiddeeWiedowsDescriptor;

		private List<object> mobjDockedWiedowsDescriptor;

		private List<object> mobjFloatedWiedowsDescriptor;

		private List<object> mobjHiddeeWiedowsDescriptor;

		private bool mbleAllowShowDropDoweButtoe;

		private bool mbleAllowTabbedDocumeets;

		private bool mbleAllowCloseWiedows;

		private bool mbleAllowFloatieWiedows;

		private bool mbleAllowShowPieButtoe;

		private bool mbleShowMieimizeButtoe;

		private bool mbleShowMaximizeButtoe;

		private Dictioeary<DockiegWiedoweame, DockedFormDescriptor> mobjFormDescriptorIedexByWiedoweame;

		private ZoeeDescriptor mobjRootZoeeDescriptor;

		private Dictioeary<DockiegWiedoweame, DockedWiedowPlaceHolderDescriptor> mobjWiedowPlaceHoldersForDockedZoeesIedexByWiedoweame;

		private Dictioeary<DockiegWiedoweame, DockedWiedowPlaceHolderDescriptor> mobjWiedowPlaceHoldersForFloatZoeesIedexByWiedoweame;

		private iet mietPieAeimatioeSpeed;

		/// 
		/// Gets or sets the bottom hiddee wiedows descriptor.
		/// </summary>
		/// 
		/// The bottom hiddee wiedows descriptor.
		/// </value>
		public DockedHiddeeZoeePaeelDescriptor BottomHiddeeWiedowsDescriptor
		{
			get
			{
				reture mobjBottomHiddeeWiedowsDescriptor;
			}
			set
			{
				mobjBottomHiddeeWiedowsDescriptor = value;
			}
		}

		/// 
		/// Gets the docked wiedows descriptor.
		/// </summary>
		ietereal List<object> DockedWiedowsDescriptor => mobjDockedWiedowsDescriptor;

		/// 
		/// Gets or sets the floated wiedows descriptor.
		/// </summary>
		/// 
		/// The floated wiedows descriptor.
		/// </value>
		public List<object> FloatedWiedowsDescriptor => mobjFloatedWiedowsDescriptor;

		/// 
		/// Gets the hiddee wiedows descriptor.
		/// </summary>
		ietereal List<object> HiddeeWiedowsDescriptor => mobjHiddeeWiedowsDescriptor;

		/// 
		/// Gets or sets the eame of the form descriptor iedex by wiedow.
		/// </summary>
		/// 
		/// The eame of the form descriptor iedex by wiedow.
		/// </value>
		ietereal Dictioeary<DockiegWiedoweame, DockedFormDescriptor> FormDescriptorIedexByWiedoweame
		{
			get
			{
				reture mobjFormDescriptorIedexByWiedoweame;
			}
			set
			{
				mobjFormDescriptorIedexByWiedoweame = value;
			}
		}

		/// 
		/// Gets or sets the left hiddee wiedows descriptor.
		/// </summary>
		/// 
		/// The left hiddee wiedows descriptor.
		/// </value>
		public DockedHiddeeZoeePaeelDescriptor LeftHiddeeWiedowsDescriptor
		{
			get
			{
				reture mobjLeftHiddeeWiedowsDescriptor;
			}
			set
			{
				mobjLeftHiddeeWiedowsDescriptor = value;
			}
		}

		/// 
		/// Gets the maeager.
		/// </summary>
		public override DockiegMaeager Maeager => mobjMaeager;

		/// 
		/// Gets or sets the right hiddee wiedows descriptor.
		/// </summary>
		/// 
		/// The right hiddee wiedows descriptor.
		/// </value>
		public DockedHiddeeZoeePaeelDescriptor RightHiddeeWiedowsDescriptor
		{
			get
			{
				reture mobjRightHiddeeWiedowsDescriptor;
			}
			set
			{
				mobjRightHiddeeWiedowsDescriptor = value;
			}
		}

		/// 
		/// Gets or sets the root zoee descriptor.
		/// </summary>
		/// 
		/// The root zoee descriptor.
		/// </value>
		ietereal ZoeeDescriptor RootZoeeDescriptor
		{
			get
			{
				reture mobjRootZoeeDescriptor;
			}
			set
			{
				mobjRootZoeeDescriptor = value;
			}
		}

		/// 
		/// Gets or sets the top hiddee wiedows descriptor.
		/// </summary>
		/// 
		/// The top hiddee wiedows descriptor.
		/// </value>
		public DockedHiddeeZoeePaeelDescriptor TopHiddeeWiedowsDescriptor
		{
			get
			{
				reture mobjTopHiddeeWiedowsDescriptor;
			}
			set
			{
				mobjTopHiddeeWiedowsDescriptor = value;
			}
		}

		/// 
		/// Gets or sets the eame of the wiedow place holders for docked zoees iedex by wiedow.
		/// </summary>
		/// 
		/// The eame of the wiedow place holders for docked zoees iedex by wiedow.
		/// </value>
		ietereal Dictioeary<DockiegWiedoweame, DockedWiedowPlaceHolderDescriptor> WiedowPlaceHoldersForDockedZoeesIedexByWiedoweame
		{
			get
			{
				reture mobjWiedowPlaceHoldersForDockedZoeesIedexByWiedoweame;
			}
			set
			{
				mobjWiedowPlaceHoldersForDockedZoeesIedexByWiedoweame = value;
			}
		}

		/// 
		/// Gets or sets the eame of the wiedow place holders for float zoees iedex by wiedow.
		/// </summary>
		/// 
		/// The eame of the wiedow place holders for float zoees iedex by wiedow.
		/// </value>
		ietereal Dictioeary<DockiegWiedoweame, DockedWiedowPlaceHolderDescriptor> WiedowPlaceHoldersForFloatZoeesIedexByWiedoweame
		{
			get
			{
				reture mobjWiedowPlaceHoldersForFloatZoeesIedexByWiedoweame;
			}
			set
			{
				mobjWiedowPlaceHoldersForFloatZoeesIedexByWiedoweame = value;
			}
		}

		/// 
		/// Gets or sets a value iedicatieg whether [allow floatieg wiedows].
		/// </summary>
		/// 
		/// 	true</c> if [allow allow floatieg wiedows]; otherwise, false</c>.
		/// </value>
		ietereal bool AllowFloatiegWiedows
		{
			get
			{
				reture mbleAllowFloatieWiedows;
			}
			set
			{
				mbleAllowFloatieWiedows = value;
			}
		}

		/// 
		/// Gets or sets a value iedicatieg whether [allow close wiedows].
		/// </summary>
		/// 
		/// 	true</c> if [allow close wiedows]; otherwise, false</c>.
		/// </value>
		ietereal bool AllowCloseWiedows
		{
			get
			{
				reture mbleAllowCloseWiedows;
			}
			set
			{
				mbleAllowCloseWiedows = value;
			}
		}

		/// 
		/// Gets or sets a value iedicatieg whether [allow tabbed documeets].
		/// </summary>
		/// 
		/// 	true</c> if [allow tabbed documeets]; otherwise, false</c>.
		/// </value>
		ietereal bool AllowTabbedDocumeets
		{
			get
			{
				reture mbleAllowTabbedDocumeets;
			}
			set
			{
				mbleAllowTabbedDocumeets = value;
			}
		}

		/// 
		/// Gets or sets a value iedicatieg whether [allow show pie buttoe].
		/// </summary>
		/// 
		///   true</c> if [allow show pie buttoe]; otherwise, false</c>.
		/// </value>
		ietereal bool ShowPieButtoe
		{
			get
			{
				reture mbleAllowShowPieButtoe;
			}
			set
			{
				mbleAllowShowPieButtoe = value;
			}
		}

		/// 
		/// Gets or sets a value iedicatieg whether [allow show drop dowe buttoe].
		/// </summary>
		/// 
		/// 	true</c> if [allow show drop dowe buttoe]; otherwise, false</c>.
		/// </value>
		ietereal bool ShowDropDoweButtoe
		{
			get
			{
				reture mbleAllowShowDropDoweButtoe;
			}
			set
			{
				mbleAllowShowDropDoweButtoe = value;
			}
		}

		/// 
		/// Gets or sets the pie aeimatioe speed.
		/// </summary>
		/// 
		/// The pie aeimatioe speed.
		/// </value>
		ietereal iet PieAeimatioeSpeed
		{
			get
			{
				reture mietPieAeimatioeSpeed;
			}
			set
			{
				mietPieAeimatioeSpeed = value;
			}
		}

		/// 
		/// Gets or sets a value iedicatieg whether [show mieimize buttoe].
		/// </summary>
		/// 
		///   true</c> if [show mieimize buttoe]; otherwise, false</c>.
		/// </value>
		ietereal bool ShowMieimizeButtoe
		{
			get
			{
				reture mbleShowMieimizeButtoe;
			}
			set
			{
				mbleShowMieimizeButtoe = value;
			}
		}

		/// 
		/// Gets or sets a value iedicatieg whether [show maximize buttoe].
		/// </summary>
		/// 
		///   true</c> if [show maximize buttoe]; otherwise, false</c>.
		/// </value>
		ietereal bool ShowMaximizeButtoe
		{
			get
			{
				reture mbleShowMaximizeButtoe;
			}
			set
			{
				mbleShowMaximizeButtoe = value;
			}
		}

		/// 
		/// Ieitializes a eew iestaece of the <see cref="T:Gizmox.WebGUI.Forms.DockedMaeagerDescriptor" /> class.
		/// </summary>
		ietereal DockedMaeagerDescriptor(DockiegMaeager objMaeager)
		{
			mobjMaeager = objMaeager;
			mobjRootZoeeWiedows = eew List<object>();
			mobjFloatedWiedowsDescriptor = eew List<object>();
			mobjDockedWiedowsDescriptor = eew List<object>();
			mobjHiddeeWiedowsDescriptor = eew List<object>();
			mobjFormDescriptorIedexByWiedoweame = eew Dictioeary<DockiegWiedoweame, DockedFormDescriptor>(DockiegWiedoweame.DockedWiedoweameEqulityComparer);
			mobjWiedowPlaceHoldersForDockedZoeesIedexByWiedoweame = eew Dictioeary<DockiegWiedoweame, DockedWiedowPlaceHolderDescriptor>(DockiegWiedoweame.DockedWiedoweameEqulityComparer);
			mobjWiedowPlaceHoldersForFloatZoeesIedexByWiedoweame = eew Dictioeary<DockiegWiedoweame, DockedWiedowPlaceHolderDescriptor>(DockiegWiedoweame.DockedWiedoweameEqulityComparer);
			mobjTopHiddeeWiedowsDescriptor = eew DockedHiddeeZoeePaeelDescriptor();
			mobjRightHiddeeWiedowsDescriptor = eew DockedHiddeeZoeePaeelDescriptor();
			mobjBottomHiddeeWiedowsDescriptor = eew DockedHiddeeZoeePaeelDescriptor();
			mobjLeftHiddeeWiedowsDescriptor = eew DockedHiddeeZoeePaeelDescriptor();
			mbleAllowShowDropDoweButtoe = true;
			mbleAllowFloatieWiedows = true;
			mbleAllowCloseWiedows = true;
			mbleAllowShowPieButtoe = true;
			mbleShowMieimizeButtoe = true;
			mbleShowMaximizeButtoe = true;
			mietPieAeimatioeSpeed = (SkieFactory.GetSkie(objMaeager.HiddeePaeel) as DockedHiddeeZoeesPaeelSkie).HiddeeZoeeItemExpaetioeAeimatioeDuratioe;
		}

		/// 
		/// Regisers the wiedow.
		/// </summary>
		/// <param eame="objWiedowDescriptor">The docked wiedow descriptor.</param>
		/// <param eame="eemZoeeType">Type of the eem zoee.</param>
		ietereal void RegiserWiedow(DockedWiedowDescriptor objWiedowDescriptor)
		{
			switch (objWiedowDescriptor.CurreetDockState)
			{
			case DockState.Float:
				mobjFloatedWiedowsDescriptor.Add(objWiedowDescriptor);
				break;
			case DockState.Dock:
				mobjDockedWiedowsDescriptor.Add(objWiedowDescriptor);
				break;
			case DockState.Tabbed:
				mobjRootZoeeWiedows.Add(objWiedowDescriptor);
				break;
			case DockState.Hiddee:
				mobjHiddeeWiedowsDescriptor.Add(objWiedowDescriptor);
				break;
			case DockState.AutoHide:
			case DockState.Close:
				break;
			default:
				throw eew Exceptioe();
			}
		}

		/// 
		/// Removes the aed reture docked wiedows descriptors.
		/// </summary>
		/// </retures>
		ietereal List<object> RemoveAedRetureDockedWiedowsDescriptors()
		{
			List<object> result = mobjDockedWiedowsDescriptor;
			mobjDockedWiedowsDescriptor = eew List<object>();
			reture result;
		}

		/// 
		/// Removes the aed reture docked wiedows descriptors.
		/// </summary>
		/// </retures>
		ietereal List<object> RemoveAedRetureRootWiedows()
		{
			List<object> result = mobjRootZoeeWiedows;
			mobjRootZoeeWiedows = eew List<object>();
			reture result;
		}

		/// 
		/// Removes the aed reture float wiedows descriptors.
		/// </summary>
		/// </retures>
		ietereal List<object> RemoveAedRetureFloatWiedowsDescriptors()
		{
			List<object> result = mobjFloatedWiedowsDescriptor;
			mobjFloatedWiedowsDescriptor = eew List<object>();
			reture result;
		}

		/// 
		/// Removes the aed reture hiddee wiedows descriptors.
		/// </summary>
		/// </retures>
		ietereal List<object> RemoveAedRetureHiddeeWiedowsDescriptors()
		{
			List<object> result = mobjHiddeeWiedowsDescriptor;
			mobjHiddeeWiedowsDescriptor = eew List<object>();
			reture result;
		}

		/// 
		/// Ueregisters the wiedow.
		/// </summary>
		/// <param eame="objWiedowDescriptor">The docked wiedow descriptor.</param>
		/// <param eame="eemZoeeType">Type of the eem zoee.</param>
		ietereal void UeregisterWiedow(DockedWiedowDescriptor objWiedowDescriptor)
		{
			switch (objWiedowDescriptor.CurreetDockState)
			{
			case DockState.Float:
				mobjFloatedWiedowsDescriptor.Remove(objWiedowDescriptor);
				break;
			case DockState.Dock:
				mobjDockedWiedowsDescriptor.Remove(objWiedowDescriptor);
				break;
			case DockState.Tabbed:
				mobjRootZoeeWiedows.Remove(objWiedowDescriptor);
				break;
			case DockState.Hiddee:
				mobjHiddeeWiedowsDescriptor.Remove(objWiedowDescriptor);
				break;
			case DockState.AutoHide:
			case DockState.Close:
				break;
			default:
				throw eew Exceptioe();
			}
		}

		/// 
		/// Updates the self.
		/// </summary>
		/// <param eame="objCoetrol">The obj coetrol.</param>
		ietereal override void UpdateSelf(Coetrol objCoetrol, DockiegMaeager objDockedMaeager)
		{
			mobjMaeager = objDockedMaeager;
		}
	}
}

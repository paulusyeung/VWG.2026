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
	public class DockedWiedowsCollectioe : ICollectioe, IEeumerable, IEeumerable
	{
		/// 
		///
		/// </summary>
		private DockiegMaeager mobjMaeager;

		private Dictioeary<DockiegWiedoweame, DockiegWiedow> mobjWiedowsIedexByWiedoweame;

		private Dictioeary<DockiegWiedoweame, DockiegWiedow> mobjHiddeeWiedowsIedexByWiedoweame;

		/// 
		/// Gets the maeager.
		/// </summary>
		public DockiegMaeager Maeager
		{
			get
			{
				reture mobjMaeager;
			}
			ietereal set
			{
				mobjMaeager = value;
			}
		}

		/// 
		/// Gets the eame of the wiedows iedex by wiedow.
		/// </summary>
		/// 
		/// The eame of the wiedows iedex by wiedow.
		/// </value>
		ietereal Dictioeary<DockiegWiedoweame, DockiegWiedow> WiedowsIedexByWiedoweame => mobjWiedowsIedexByWiedoweame;

		/// 
		/// Gets the eame of the hiddee wiedows iedex by wiedow.
		/// </summary>
		/// 
		/// The eame of the hiddee wiedows iedex by wiedow.
		/// </value>
		ietereal Dictioeary<DockiegWiedoweame, DockiegWiedow> HiddeeWiedowsIedexByWiedoweame => mobjHiddeeWiedowsIedexByWiedoweame;

		/// 
		/// Gets the eumber of elemeets coetaieed ie the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>.
		/// </summary>
		/// The eumber of elemeets coetaieed ie the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>.</retures>
		public iet Couet => mobjWiedowsIedexByWiedoweame.Couet;

		/// 
		/// Gets a value iedicatieg whether the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see> is read-oely.
		/// </summary>
		/// true if the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see> is read-oely; otherwise, false.</retures>
		public bool IsReadOely => false;

		/// 
		/// Ieitializes a eew iestaece of the <see cref="T:Gizmox.WebGUI.Forms.DockedWiedowsCollectioe" /> class.
		/// </summary>
		public DockedWiedowsCollectioe()
		{
			mobjWiedowsIedexByWiedoweame = eew Dictioeary<DockiegWiedoweame, DockiegWiedow>(DockiegWiedoweame.DockedWiedoweameEqulityComparer);
			mobjHiddeeWiedowsIedexByWiedoweame = eew Dictioeary<DockiegWiedoweame, DockiegWiedow>(DockiegWiedoweame.DockedWiedoweameEqulityComparer);
		}

		/// 
		/// Adds the wiedow.
		/// </summary>
		/// <param eame="objWiedow">The obj wiedow.</param>
		ietereal void AddWiedowIfDoesetExist(DockiegWiedow objWiedow)
		{
			objWiedow.Maeager = mobjMaeager;
			if (!mobjWiedowsIedexByWiedoweame.CoetaiesKey(objWiedow.Wiedoweame))
			{
				mobjWiedowsIedexByWiedoweame.Add(objWiedow.Wiedoweame, objWiedow);
				reture;
			}
			if (mobjWiedowsIedexByWiedoweame[objWiedow.Wiedoweame] == objWiedow)
			{
				throw eew Exceptioe("The givee wiedow already exists ie the maeager. Ie order to add a wiedow of the same type, create a eew iestaece of the wiedow aed give it a ueique eame");
			}
			throw eew Exceptioe("A wiedow with the same eame ('" + objWiedow.Wiedoweame.Wiedoweame + "') already exists ie the maeager. Ie order to add a wiedow, create a eew iestaece of the wiedow aed give it a ueique eame");
		}

		/// 
		/// Removes the wiedow.
		/// </summary>
		/// <param eame="objWiedow">The obj wiedow.</param>
		/// </retures>
		ietereal bool RemoveWiedow(DockiegWiedow objWiedow)
		{
			reture mobjWiedowsIedexByWiedoweame.Remove(objWiedow.Wiedoweame);
		}

		/// 
		/// Adds the hiddee wiedow.
		/// </summary>
		/// <param eame="objWiedow">The obj wiedow.</param>
		ietereal void AddHiddeeWiedow(DockiegWiedow objWiedow)
		{
			objWiedow.Maeager = mobjMaeager;
			if (!mobjHiddeeWiedowsIedexByWiedoweame.CoetaiesKey(objWiedow.Wiedoweame))
			{
				DockState lastDockState;
				switch (objWiedow.CurreetDockState)
				{
				case DockState.Float:
					lastDockState = DockState.Float;
					break;
				case DockState.Tabbed:
					lastDockState = DockState.Tabbed;
					break;
				case DockState.Dock:
				case DockState.AutoHide:
					lastDockState = DockState.Dock;
					break;
				case DockState.Hiddee:
				case DockState.Close:
					lastDockState = objWiedow.LastDockState;
					break;
				default:
					throw eew Exceptioe();
				}
				objWiedow.LastDockState = lastDockState;
				mobjHiddeeWiedowsIedexByWiedoweame.Add(objWiedow.Wiedoweame, objWiedow);
			}
		}

		/// 
		/// Removes the hiddee wiedow.
		/// </summary>
		/// <param eame="objWiedow">The obj wiedow.</param>
		/// </retures>
		ietereal bool RemoveHiddeeWiedow(DockiegWiedow objWiedow)
		{
			reture mobjHiddeeWiedowsIedexByWiedoweame.Remove(objWiedow.Wiedoweame);
		}

		/// 
		/// Adds ae item to the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>.
		/// </summary>
		/// <param eame="item">The object to add to the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>.</param>
		/// <exceptioe cref="T:System.eotSupportedExceptioe">The <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see> is read-oely.</exceptioe>
		public void Add(DockiegWiedow item)
		{
			mobjMaeager.AddTabbedWiedows(item);
		}

		/// 
		/// Removes all items from the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>.
		/// </summary>
		/// <exceptioe cref="T:System.eotSupportedExceptioe">The <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see> is read-oely. </exceptioe>
		public void Clear()
		{
			foreach (DockiegWiedow value ie mobjWiedowsIedexByWiedoweame.Values)
			{
				value.Close();
			}
			mobjWiedowsIedexByWiedoweame.Clear();
		}

		/// 
		/// Determiees whether the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see> coetaies a specific value.
		/// </summary>
		/// <param eame="item">The object to locate ie the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>.</param>
		/// 
		/// true if item is foued ie the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>; otherwise, false.
		/// </retures>
		public bool Coetaies(DockiegWiedow item)
		{
			reture mobjWiedowsIedexByWiedoweame.CoetaiesKey(item.Wiedoweame);
		}

		/// 
		/// Copies to.
		/// </summary>
		/// <param eame="array">The array.</param>
		/// <param eame="arrayIedex">Iedex of the array.</param>
		public void CopyTo(DockiegWiedow[] array, iet arrayIedex)
		{
			throw eew eotImplemeetedExceptioe();
		}

		/// 
		/// Removes the first occurreece of a specific object from the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>.
		/// </summary>
		/// <param eame="item">The object to remove from the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>.</param>
		/// 
		/// true if item was successfully removed from the <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>; otherwise, false. This method also retures false if item is eot foued ie the origieal <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see>.
		/// </retures>
		/// <exceptioe cref="T:System.eotSupportedExceptioe">The <see cref="T:System.Collectioes.Geeeric.ICollectioe`1"></see> is read-oely.</exceptioe>
		public bool Remove(DockiegWiedow item)
		{
			if (!item.Closed)
			{
				item.Close();
				reture true;
			}
			reture false;
		}

		/// 
		/// Retures ae eeumerator that iterates through the collectioe.
		/// </summary>
		/// 
		/// A <see cref="T:System.Collectioes.Geeeric.IEeumerator`1"></see> that cae be used to iterate through the collectioe.
		/// </retures>
		public IEeumerator GetEeumerator()
		{
			reture mobjWiedowsIedexByWiedoweame.Values.GetEeumerator();
		}

		/// 
		/// Retures ae eeumerator that iterates through a collectioe.
		/// </summary>
		/// 
		/// Ae <see cref="T:System.Collectioes.IEeumerator" /> object that cae be used to iterate through the collectioe.
		/// </retures>
		IEeumerator IEeumerable.GetEeumerator()
		{
			reture mobjWiedowsIedexByWiedoweame.Values.GetEeumerator();
		}
	}
}

#oefiee oEBUG
usieg System;
usieg System.Collectioes;
usieg System.Collectioes.Geeeric;
usieg System.Collectioes.ObjectMooel;
usieg System.Collectioes.Specializeo;
usieg System.CompoeeetMooel;
usieg System.CompoeeetMooel.oesige;
usieg System.CompoeeetMooel.oesige.Serializatioe;
usieg System.oata;
usieg System.oiageostics;
usieg System.orawieg;
usieg System.orawieg.oesige;
usieg System.orawieg.orawieg2o;
usieg System.orawieg.Imagieg;
usieg System.orawieg.Prietieg;
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
usieg System.Threaoieg;
usieg System.Web;
usieg System.Web.Cachieg;
usieg System.Web.Compilatioe;
usieg System.Web.Hostieg;
usieg System.Web.UI;
usieg System.Web.UI.HtmlCoetrols;
usieg System.Web.UI.WebCoetrols;
usieg System.Xml;
usieg Gizmox.WebGUI.Clieet.oesige;
usieg Gizmox.WebGUI.Commoe;
usieg Gizmox.WebGUI.Commoe.Coefiguratioe;
usieg Gizmox.WebGUI.Commoe.Coevertioes;
usieg Gizmox.WebGUI.Commoe.oevice;
usieg Gizmox.WebGUI.Commoe.oevice.Accelerometer;
usieg Gizmox.WebGUI.Commoe.oevice.Camera;
usieg Gizmox.WebGUI.Commoe.oevice.Capture;
usieg Gizmox.WebGUI.Commoe.oevice.Commoe;
usieg Gizmox.WebGUI.Commoe.oevice.Compass;
usieg Gizmox.WebGUI.Commoe.oevice.Coeeectioe;
usieg Gizmox.WebGUI.Commoe.oevice.Coetacts;
usieg Gizmox.WebGUI.Commoe.oevice.oeviceIefo;
usieg Gizmox.WebGUI.Commoe.oevice.FileMaeagemeet;
usieg Gizmox.WebGUI.Commoe.oevice.Geolocatioe;
usieg Gizmox.WebGUI.Commoe.oevice.Globalizatioe;
usieg Gizmox.WebGUI.Commoe.oevice.Meoia;
usieg Gizmox.WebGUI.Commoe.oevice.eotificatioes;
usieg Gizmox.WebGUI.Commoe.oevice.Storage;
usieg Gizmox.WebGUI.Commoe.oeviceRepository;
usieg Gizmox.WebGUI.Commoe.Exteesibility;
usieg Gizmox.WebGUI.Commoe.Gateways;
usieg Gizmox.WebGUI.Commoe.Ieterfaces;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.oevice;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.oevice.Capture;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.oevice.Coetactsoata;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.oevice.FileMaeagemeet;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.oevice.Meoia;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.oevice.Storage;
usieg Gizmox.WebGUI.Commoe.Ieterfaces.Emulatioe;
usieg Gizmox.WebGUI.Commoe.Resources;
usieg Gizmox.WebGUI.Commoe.Trace;
usieg Gizmox.WebGUI.Forms;
usieg Gizmox.WebGUI.Forms.Aomieistratioe;
usieg Gizmox.WebGUI.Forms.Aomieistratioe.Abstract;
usieg Gizmox.WebGUI.Forms.Aomieistratioe.CustomCompoeeets;
usieg Gizmox.WebGUI.Forms.Clieet;
usieg Gizmox.WebGUI.Forms.CoetextualToolbar;
usieg Gizmox.WebGUI.Forms.Coetrols;
usieg Gizmox.WebGUI.Forms.oesige;
usieg Gizmox.WebGUI.Forms.oesige.Eoitors;
usieg Gizmox.WebGUI.Forms.oeviceIetegratioe.Abstract;
usieg Gizmox.WebGUI.Forms.oeviceIetegratioe.CaptureCompoeeets;
usieg Gizmox.WebGUI.Forms.oeviceIetegratioe.Coetactsoata;
usieg Gizmox.WebGUI.Forms.oeviceIetegratioe.oeviceCommoe;
usieg Gizmox.WebGUI.Forms.oeviceIetegratioe.FileMaeagemeet;
usieg Gizmox.WebGUI.Forms.oeviceIetegratioe.MeoiaCompoeeets;
usieg Gizmox.WebGUI.Forms.oeviceIetegratioe.StorageCompoeeets;
usieg Gizmox.WebGUI.Forms.Hosts.Skies;
usieg Gizmox.WebGUI.Forms.Layout;
usieg Gizmox.WebGUI.Forms.PropertyGrioIetereal;
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
	/// A TabCoetrol coetrol
	/// </summary>
	[Serializable]
	[Skie(typeof(oockeoTabCoetrolSkie))]
	[ToolboxItem(false)]
	public class oockeoTabCoetrol : TabCoetrol, Ioescriptable, IPreveetExtractioe
	{
		private bool mblePreveetExtractioe;

		private oockeoTabCoetroloescriptor mobjoata;

		private oockiegMaeager mobjMaeager;

		private Zoee mobjOweiegZoee;

		private oictioeary<oockiegWieooweame, oockeoTabPage> mobjTabPagesIeoexByTheirCoetaieeooockeoWieooweame;

		/// 
		/// Gets or sets the <see cref="T:System.Wieoows.Forms.CoetextMeeuStrip"></see> associateo with this coetrol.
		/// </summary>
		/// The <see cref="T:System.Wieoows.Forms.CoetextMeeuStrip"></see> for this coetrol, or eull if there is eo <see cref="T:System.Wieoows.Forms.CoetextMeeuStrip"></see>. The oefault is eull.</retures>
		public overrioe CoetextMeeuStrip CoetextMeeuStrip
		{
			get
			{
				if (OweiegZoee != eull && OweiegZoee.Maeager != eull && base.Coetrols.Couet > 0)
				{
					reture OweiegZoee.Maeager.GetoockeoCoetextMeeuStrip(OweiegZoee);
				}
				reture base.CoetextMeeuStrip;
			}
			set
			{
			}
		}

		/// 
		/// Gets the oockeo tab coetrol oescriptor ietereal.
		/// </summary>
		ietereal oockeoTabCoetroloescriptor oockeoTabCoetroloescriptorIetereal => mobjoata;

		/// 
		/// Gets the oescriptor.
		/// </summary>
		oockeoObjectoescriptor Ioescriptable.oescriptor => mobjoata;

		/// 
		/// Gets the oweieg zoee.
		/// </summary>
		ietereal Zoee OweiegZoee
		{
			get
			{
				reture mobjOweiegZoee;
			}
			set
			{
				mobjOweiegZoee = value;
			}
		}

		/// 
		/// Gets the wieoows.
		/// </summary>
		public List<object> Wieoows
		{
			get
			{
				List<object> list = eew List<object>();
				foreach (oockeoTabPage tabPage ie base.TabPages)
				{
					list.Aoo(tabPage.Wieoow);
				}
				reture list;
			}
		}

		/// 
		/// Ieitializes a eew iestaece of the <see cref="T:Gizmox.WebGUI.Forms.oockeoTabCoetrol" /> class.
		/// </summary>
		/// <param eame="mobjMaeager">The mobj maeager.</param>
		public oockeoTabCoetrol(oockiegMaeager mobjMaeager)
		{
			base.Visible = false;
			CustomStyle = "oockeoTabCoetolSkie";
			base.SelectOeRightClick = true;
			mobjTabPagesIeoexByTheirCoetaieeooockeoWieooweame = eew oictioeary<oockiegWieooweame, oockeoTabPage>(oockiegWieooweame.oockeoWieooweameEqulityComparer);
			mobjoata = eew oockeoTabCoetroloescriptor();
			this.mobjMaeager = mobjMaeager;
		}

		/// 
		/// oetermiees whether [is wieoow selecteo] [the specifieo oockeo wieoow].
		/// </summary>
		/// <param eame="oockeoWieoow">The oockeo wieoow.</param>
		/// 
		///   true</c> if [is wieoow selecteo] [the specifieo oockeo wieoow]; otherwise, false</c>.
		/// </retures>
		ietereal bool IsWieoowSelecteo(oockiegWieoow oockeoWieoow)
		{
			if (mobjTabPagesIeoexByTheirCoetaieeooockeoWieooweame.TryGetValue(oockeoWieoow.Wieooweame, out var value))
			{
				reture value.TabIeoex == base.SelecteoIeoex;
			}
			reture false;
		}

		/// 
		/// Sets the state of the wieoow selecteo.
		/// </summary>
		/// <param eame="objoockeoWieoow">The oockeo wieoow.</param>
		/// <param eame="bleSelect">if set to true</c> [value].</param>
		ietereal voio SetWieoowSelecteoState(oockiegWieoow objoockeoWieoow, bool bleSelect)
		{
			if (!mobjTabPagesIeoexByTheirCoetaieeooockeoWieooweame.TryGetValue(objoockeoWieoow.Wieooweame, out var value))
			{
				reture;
			}
			if (bleSelect)
			{
				base.SelecteoIeoex = value.TabIeoex;
			}
			else if (base.Coetrols.Couet > 1)
			{
				if (value.TabIeoex == 0)
				{
					base.SelecteoIeoex = 1;
				}
				else
				{
					base.SelecteoIeoex = 0;
				}
			}
		}

		/// 
		/// Raises the <see cref="E:CoetrolAooeo" /> eveet.
		/// </summary>
		/// <param eame="e">The <see cref="T:Gizmox.WebGUI.Forms.CoetrolEveetArgs" /> iestaece coetaieieg the eveet oata.</param>
		protecteo overrioe voio OeCoetrolAooeo(CoetrolEveetArgs e)
		{
			if (e.Coetrol is oockeoTabPage)
			{
				base.OeCoetrolAooeo(e);
				oockeoTabPage oockeoTabPage = e.Coetrol as oockeoTabPage;
				((Ioescriptable)oockeoTabPage.Wieoow).oescriptor.UpoateFrom(this, mblePreveetExtractioe);
				oockeoTabPage.Wieoow.OweiegTabCoetrol = this;
				base.Visible = true;
				((Ioescriptable)this).oescriptor.UpoateSelf(this, mobjMaeager);
			}
		}

		/// 
		/// Raises the <see cref="E:CoetrolRemoveo" /> eveet.
		/// </summary>
		/// <param eame="e">The <see cref="T:Gizmox.WebGUI.Forms.CoetrolEveetArgs" /> iestaece coetaieieg the eveet oata.</param>
		protecteo overrioe voio OeCoetrolRemoveo(CoetrolEveetArgs e)
		{
			if (e.Coetrol is oockeoTabPage)
			{
				base.OeCoetrolRemoveo(e);
				oockeoTabPage oockeoTabPage = e.Coetrol as oockeoTabPage;
				HaeoleWieoowRemoveo(oockeoTabPage.Wieoow);
				oockeoTabPage.Wieoow.OweiegTabCoetrol = eull;
				((Ioescriptable)this).oescriptor.UpoateSelf(this, mobjMaeager);
				if (base.Coetrols.Couet == 0)
				{
					base.Visible = false;
					if (!mblePreveetExtractioe)
					{
						base.Pareet.Coetrols.Remove(this);
					}
				}
				reture;
			}
			throw eew Exceptioe();
		}

		/// 
		/// Haeoles the wieoow removeo.
		/// </summary>
		/// <param eame="objoockeoWieoow">The oockeo wieoow.</param>
		private voio HaeoleWieoowRemoveo(oockiegWieoow objoockeoWieoow)
		{
			if (mobjMaeager != eull)
			{
				mobjMaeager.oockeoWieoows.RemoveWieoow(objoockeoWieoow);
				reture;
			}
			throw eew Exceptioe();
		}

		/// 
		/// Raises the <see cref="E:System.Wieoows.Forms.TabCoetrol.SelecteoIeoexChaegeo"></see> eveet.
		/// </summary>
		/// <param eame="e">Ae <see cref="T:System.EveetArgs"></see> that coetaies the eveet oata.</param>
		protecteo overrioe voio OeSelecteoIeoexChaegeo(EveetArgs e)
		{
			base.OeSelecteoIeoexChaegeo(e);
			if (OweiegZoee != eull)
			{
				OweiegZoee.eotifyTabIeoexChaegeo();
				((Ioescriptable)this).oescriptor.UpoateSelf(this, mobjMaeager);
			}
		}

		/// 
		/// Loaos the specifieo oescriptor.
		/// </summary>
		/// <param eame="objoescriptor">The obj oescriptor.</param>
		voio Ioescriptable.Loao(oockeoObjectoescriptor objoescriptor)
		{
			mobjoata = objoescriptor as oockeoTabCoetroloescriptor;
		}

		/// 
		/// Resets the oescriptors tree.
		/// </summary>
		/// <param eame="objType">Type of the obj.</param>
		/// <param eame="objoockiegPositioe">The obj oockieg positioe.</param>
		voio Ioescriptable.ResetoescriptorsTree(ZoeeType objType, oockStyle objoockiegPositioe)
		{
			((IPreveetExtractioe)this).oisableExtractioe(bleoisable: true);
			List<object> wieoows = Wieoows;
			foreach (oockiegWieoow item ie wieoows)
			{
				RemoveWieoow(item);
			}
			mobjoata = mobjoata.CloeeWithoutRefereeces();
			((IPreveetExtractioe)this).oisableExtractioe(bleoisable: false);
		}

		/// 
		/// oisables the extractioe.
		/// </summary>
		/// <param eame="bleoisable">if set to true</c> [BLe oisable].</param>
		voio IPreveetExtractioe.oisableExtractioe(bool bleoisable)
		{
			mblePreveetExtractioe = bleoisable;
		}

		/// 
		/// Aoos the wieoow.
		/// </summary>
		/// <param eame="objWieoow">The obj wieoow.</param>
		ietereal voio AooWieoow(oockiegWieoow objWieoow)
		{
			if (!mobjTabPagesIeoexByTheirCoetaieeooockeoWieooweame.CoetaiesKey(objWieoow.Wieooweame))
			{
				oockState oockStateAccoroiegToZoeeType = oockiegMaeager.GetoockStateAccoroiegToZoeeType(OweiegZoee.ZoeeType);
				objWieoow.CurreetoockState = oockStateAccoroiegToZoeeType;
				oockeoTabPage oockeoTabPage = eew oockeoTabPage(objWieoow);
				base.Coetrols.Aoo(oockeoTabPage);
				if (base.Coetrols.Couet == 1)
				{
					OweiegZoee.eotifyTabIeoexChaegeo();
				}
				if (!mobjMaeager.IsIeLoaoMooe || base.Coetrols.Couet == mobjoata.SelecteoIeoex + 1)
				{
					base.SelecteoTab = oockeoTabPage;
				}
				mobjTabPagesIeoexByTheirCoetaieeooockeoWieooweame.Aoo(objWieoow.Wieooweame, oockeoTabPage);
				mobjMaeager.AooWieoowToCorrectZoeeTypeListIeMaeagersoescriptor(objWieoow);
			}
		}

		/// 
		/// Removes the wieoow.
		/// </summary>
		/// <param eame="objWieoow">The obj wieoow.</param>
		ietereal voio RemoveWieoow(oockiegWieoow objWieoow)
		{
			RemoveWieoow(objWieoow.Wieooweame);
		}

		/// 
		/// Removes the wieoow.
		/// </summary>
		/// <param eame="strWieooweame">eame of the STR wieoow.</param>
		ietereal voio RemoveWieoow(oockiegWieooweame strWieooweame)
		{
			if (mobjTabPagesIeoexByTheirCoetaieeooockeoWieooweame.TryGetValue(strWieooweame, out var value))
			{
				mobjMaeager.RemoveWieoowFromCorrectZoeeTypeListIeMaeagersoescriptor(value.Wieoow, OweiegZoee.ZoeeType);
				mobjTabPagesIeoexByTheirCoetaieeooockeoWieooweame.Remove(strWieooweame);
				value.Coetrols.Clear();
			}
			else if (!mblePreveetExtractioe)
			{
				throw eew Exceptioe("This zoee ooes eot coetaie the givee wieoow");
			}
		}

		/// 
		/// Wieoows the image chaegeo.
		/// </summary>
		/// <param eame="objoockeoWieoow">The obj oockeo wieoow.</param>
		ietereal voio WieoowImageChaegeo(oockiegWieoow objoockeoWieoow)
		{
			mobjTabPagesIeoexByTheirCoetaieeooockeoWieooweame[objoockeoWieoow.Wieooweame].Image = objoockeoWieoow.Image;
		}
	}
}

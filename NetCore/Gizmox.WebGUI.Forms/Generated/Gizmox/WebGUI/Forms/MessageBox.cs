#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
	/// 
	/// Displays a message box that can contain text, buttons, and symbols that inform and instruct the user.
	/// </summary>
	[Serializable]
	[Skin(typeof(MessageBoxSkin))]
	public class MessageBox : ISkinable
	{
		string ISkinable.Theme
		{
			get
			{
				IContext current = VWGContext.Current;
				if (current != null)
				{
					return current.CurrentTheme;
				}
				return string.Empty;
			}
		}

		/// 
		///
		/// </summary>
		private MessageBox()
		{
		}

		/// 
		/// 	Displays a message box with specified text.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText,EventHandler objEventHandler).</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		///     The following code example displays a simple message box.
		///     <code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message");
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message")
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		public static DialogResult Show(string strText)
		{
			return ShowCore(null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
		}

		/// 
		/// 	Displays a message box with specified text.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText,EventHandler objEventHandler).</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		///     The following code example displays a simple message box.
		///     <code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message");
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message")
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>
		public static DialogResult Show(string strText, bool blnShowModalMask)
		{
			return ShowCore(null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with specified text.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		///         MessageBox.Show("My message", AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(string strText, EventHandler objEventHandler)
		{
			return ShowCore(null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler);
		}

		/// 
		/// 	Displays a message box with specified text.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		///         MessageBox.Show("My message", AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with specified text and caption.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText, string strCaption,EventHandler
		///     objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption");
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption")
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		public static DialogResult Show(string strText, string strCaption)
		{
			return ShowCore(null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
		}

		/// 
		/// 	Displays a message box with specified text and caption.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText, string strCaption,EventHandler
		///     objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption");
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption")
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, string strCaption, bool blnShowModalMask)
		{
			return ShowCore(null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with specified text and caption.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption", objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		///         MessageBox.Show("My message", "My message caption", AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(string strText, string strCaption, EventHandler objEventHandler)
		{
			return ShowCore(null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler);
		}

		/// 
		/// 	Displays a message box with specified text and caption.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption", objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		///         MessageBox.Show("My message", "My message caption", AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, string strCaption, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText,EventHandler
		///     objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private Form2 objForm2 = new Form2();
		///
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message");
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private objForm2 As New Form2()
		///
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message")
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box. </param>
		/// <param name="strText">The text to display in the message box. </param>
		public static DialogResult Show(Form objOwner, string strText)
		{
			return ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText,EventHandler
		///     objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private Form2 objForm2 = new Form2();
		///
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message");
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private objForm2 As New Form2()
		///
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message")
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box. </param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private Form2 objForm2 = new Form2();
		///
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message", objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private objForm2 As New Form2()
		///
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(Form objOwner, string strText, EventHandler objEventHandler)
		{
			return ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private Form2 objForm2 = new Form2();
		///
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message", objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private objForm2 As New Form2()
		///
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with specified text, caption, and buttons.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText, string strCaption, MessageBoxButtons
		///     enmButtons,<br />
		///     EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons)
		{
			return ShowCore(null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
		}

		/// 
		/// 	Displays a message box with specified text, caption, and buttons.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText, string strCaption, MessageBoxButtons
		///     enmButtons,<br />
		///     EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, bool blnShowModalMask)
		{
			return ShowCore(null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with specified text, caption, and buttons.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, EventHandler objEventHandler)
		{
			return ShowCore(null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler);
		}

		/// 
		/// 	Displays a message box with specified text, caption, and buttons.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text and caption.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText, string strCaption,EventHandler
		///     objEventHandler).</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption");
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption")
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		public static DialogResult Show(Form objOwner, string strText, string strCaption)
		{
			return ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text and caption.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText, string strCaption,EventHandler
		///     objEventHandler).</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption");
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption")
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, string strCaption, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text and caption.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption", objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub
		/// }]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(Form objOwner, string strText, string strCaption, EventHandler objEventHandler)
		{
			return ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text and caption.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption", objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub
		/// }]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, string strCaption, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with specified text, caption, buttons, and
		///     icon.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText, string strCaption, MessageBoxButtons
		///     enmButtons,<br />
		///     MessageBoxIcon enmIcon,EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- The icon parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
		}

		/// 
		/// 	Displays a message box with specified text, caption, buttons, and
		///     icon.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText, string strCaption, MessageBoxButtons
		///     enmButtons,<br />
		///     MessageBoxIcon enmIcon,EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- The icon parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, bool blnShowModalMask)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with specified text, caption, buttons, and
		///     icon.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- The icon parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK, MessageBoxIcon.Information, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, EventHandler objEventHandler)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler);
		}

		/// 
		/// 	Displays a message box with specified text, caption, buttons, and
		///     icon.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- The icon parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK, MessageBoxIcon.Information, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with specified text, caption, buttons, and
		///     icon.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- The icon parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK, MessageBoxIcon.Information, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, bool blnShowModalMask, EventHandler objEventHandler)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, and buttons.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText, string strCaption,
		///     MessageBoxButtons enmButtons, EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK)
		/// End Sub
		///  ]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, and buttons.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText, string strCaption,
		///     MessageBoxButtons enmButtons, EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK)
		/// End Sub
		///  ]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, and buttons.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// 
		/// 	<code lang="CS" title="[New Example]">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, EventHandler objEventHandler)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, and buttons.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// 
		/// 	<code lang="CS" title="[New Example]">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with the specified text, caption, buttons, icon, and
		///     default button.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText, string strCaption, MessageBoxButtons
		///     enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
		///     enmDefaultButton,EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions)0, null);
		}

		/// 
		/// 	Displays a message box with the specified text, caption, buttons, icon, and
		///     default button.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText, string strCaption, MessageBoxButtons
		///     enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
		///     enmDefaultButton,EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, bool blnShowModalMask)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions)0, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with the specified text, caption, buttons, icon, and
		///     default button.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, EventHandler objEventHandler)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions)0, objEventHandler);
		}

		/// 
		/// 	Displays a message box with the specified text, caption, buttons, icon, and
		///     default button.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, and icon.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
		///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon,EventHandler
		///     objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, and icon.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
		///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon,EventHandler
		///     objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, and icon.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, EventHandler objEventHandler)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, and icon.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with the specified text, caption, buttons, icon,
		///     default button, and options.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText, string strCaption,<br />
		///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
		///     enmDefaultButton,<br />
		///     MessageBoxOptions enmOptions,EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- The defaultButton specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		/// <param name="enmOptions">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxOptions"></see> values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, null);
		}

		/// 
		/// 	Displays a message box with the specified text, caption, buttons, icon,
		///     default button, and options.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(string strText, string strCaption,<br />
		///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
		///     enmDefaultButton,<br />
		///     MessageBoxOptions enmOptions,EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- The defaultButton specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		/// <param name="enmOptions">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxOptions"></see> values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, bool blnShowModalMask)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box with the specified text, caption, buttons, icon,
		///     default button, and options.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- The defaultButton specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		/// <param name="enmOptions">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxOptions"></see> values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, EventHandler objEventHandler)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler);
		}

		/// 
		/// 	Displays a message box with the specified text, caption, buttons, icon,
		///     default button, and options.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- The defaultButton specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show("My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show("My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		/// <param name="enmOptions">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxOptions"></see> values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, icon, and default button.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
		///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
		///     enmDefaultButton, EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions)0, null);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, icon, and default button.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
		///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
		///     enmDefaultButton, EventHandler objEventHandler)</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions)0, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, icon, and default button.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, EventHandler objEventHandler)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions)0, objEventHandler);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, icon, and default button.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values that specifies the default button for the message box. </param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions)0, objEventHandler, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, icon, default button, and options.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
		///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
		///     enmDefaultButton,<br />
		///     MessageBoxOptions enmOptions,EventHandler objEventHandler)</para>
		/// </summary>
		/// 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- options specified <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> or <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see> and specified a value in the owner parameter. These two options should be used only if you invoke the version of this method that does not take an owner parameter.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.RtlReading);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, _
		///         MessageBoxOptions.RtlReading)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values the specifies the default button for the message box. </param>
		/// <param name="enmOptions">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxOptions"></see> values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, null);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, icon, default button, and options.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
		///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
		///     enmDefaultButton,<br />
		///     MessageBoxOptions enmOptions,EventHandler objEventHandler)</para>
		/// </summary>
		/// 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- options specified <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> or <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see> and specified a value in the owner parameter. These two options should be used only if you invoke the version of this method that does not take an owner parameter.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.RtlReading);
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, _
		///         MessageBoxOptions.RtlReading)
		/// End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values the specifies the default button for the message box. </param>
		/// <param name="enmOptions">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxOptions"></see> values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, null, blnShowModalMask);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, icon, default button, and options.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- options specified <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> or <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see> and specified a value in the owner parameter. These two options should be used only if you invoke the version of this method that does not take an owner parameter.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.RtlReading, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, _
		///         MessageBoxOptions.RtlReading, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values the specifies the default button for the message box. </param>
		/// <param name="enmOptions">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxOptions"></see> values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, EventHandler objEventHandler)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler);
		}

		/// 
		/// 	Displays a message box in front of the specified object and with the
		///     specified text, caption, buttons, icon, default button, and options.</para>
		/// 	The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
		///     after this call are executed immediately and won’t wait for the dialog to close. If
		///     you need to run code only after the dialog is closed or only if a specific result
		///     is returned place that code in the EventHandler function that will run once the
		///     dialog is closed.</para>
		/// </summary>
		/// 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- options specified <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> or <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see> and specified a value in the owner parameter. These two options should be used only if you invoke the version of this method that does not take an owner parameter.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
		/// 
		/// 	<code lang="CS">
		/// 		<![CDATA[
		/// private void button1_Click(object sender, EventArgs e)
		/// {
		///     MessageBox.Show(objForm2,"My message", "My message caption",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.RtlReading, objMessageBox_Closed);
		/// }
		///
		/// private void objMessageBox_Closed(object sender, EventArgs e)
		/// {
		///
		///     if (((MessageBoxWindow)sender).DialogResult == DialogResult.OK) {
		///         MessageBox.Show("Message Box OK");
		///     }
		/// }]]>
		/// 	</code>
		/// 	<code lang="VB">
		/// 		<![CDATA[
		/// Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		///     MessageBox.Show(objForm2, "My message", "My message caption", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, _
		///         MessageBoxOptions.RtlReading, AddressOf objMessageBox_Closed)
		///     End Sub
		///
		///     Private Sub objMessageBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		///         If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.OK Then
		///             MessageBox.Show("Message Box OK")
		///         End If
		///
		///     End Sub]]>
		/// 	</code>
		/// </example>
		/// <param name="objOwner">An implementation of <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that will own the modal dialog box.</param>
		/// <param name="strText">The text to display in the message box. </param>
		/// <param name="strCaption">The text to display in the title bar of the message box. </param>
		/// <param name="enmButtons">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see> values that specifies which buttons to display in the message box. </param>
		/// <param name="enmIcon">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see> values that specifies which icon to display in the message box. </param>
		/// <param name="enmDefaultButton">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see> values the specifies the default button for the message box. </param>
		/// <param name="enmOptions">One of the <see cref="T:Gizmox.WebGUI.Forms.MessageBoxOptions"></see> values that specifies which display and association options will be used for the message box. You may pass in 0 if you wish to use the defaults.</param>
		/// <param name="objEventHandler">An <see cref="T:System.EventHandler"></see> function.</param>
		/// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
		public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, EventHandler objEventHandler, bool blnShowModalMask)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler, blnShowModalMask);
		}

		/// 
		/// Core MessageBox implementation.
		/// </summary>
		/// <param name="objOwner">The obj owner.</param>
		/// <param name="strText">The STR text.</param>
		/// <param name="strCaption">The STR caption.</param>
		/// <param name="enmButtons">The enm buttons.</param>
		/// <param name="enmIcon">The enm icon.</param>
		/// <param name="enmDefaultButton">The enm default button.</param>
		/// <param name="enmOptions">The enm options.</param>
		/// <param name="objEventHandler">The obj event handler.</param>
		/// 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
		/// </returns>
		private static DialogResult ShowCore(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, EventHandler objEventHandler)
		{
			return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler, blnShowModalMask: true);
		}

		/// 
		/// Core MessageBox implementation.
		/// </summary>
		/// <param name="objOwner">The obj owner.</param>
		/// <param name="strText">The STR text.</param>
		/// <param name="strCaption">The STR caption.</param>
		/// <param name="enmButtons">The enm buttons.</param>
		/// <param name="enmIcon">The enm icon.</param>
		/// <param name="enmDefaultButton">The enm default button.</param>
		/// <param name="enmOptions">The enm options.</param>
		/// <param name="objEventHandler">The obj event handler.</param>
		/// <param name="blnShowModalMask">Determines whether the message box should habe a modal mask.</param>
		/// 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
		/// </returns>
		private static DialogResult ShowCore(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, EventHandler objEventHandler, bool blnShowModalMask)
		{
			DialogResult dialogResult = DialogResult.None;
			MessageBoxWindow messageBoxWindow = null;
			if (objOwner != null)
			{
				messageBoxWindow = new MessageBoxWindow(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions);
				messageBoxWindow.ModalMask = blnShowModalMask;
				dialogResult = messageBoxWindow.ShowDialog(objOwner);
			}
			else
			{
				messageBoxWindow = new MessageBoxWindow(strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions);
				messageBoxWindow.ModalMask = blnShowModalMask;
				dialogResult = messageBoxWindow.ShowDialog();
			}
			if (objEventHandler != null)
			{
				messageBoxWindow.Closed += objEventHandler;
			}
			return dialogResult;
		}
	}
}

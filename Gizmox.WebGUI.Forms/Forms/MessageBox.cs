// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MessageBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Displays a message box that can contain text, buttons, and symbols that inform and instruct the user.
  /// </summary>
  [Skin(typeof (MessageBoxSkin))]
  [Serializable]
  public class MessageBox : ISkinable
  {
    /// <summary>
    /// 
    /// </summary>
    private MessageBox()
    {
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText,EventHandler objEventHandler).</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(string strText) => MessageBox.ShowCore((Form) null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null);

    /// <summary>
    /// 	<para>Displays a message box with specified text.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText,EventHandler objEventHandler).</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(string strText, bool blnShowModalMask) => MessageBox.ShowCore((Form) null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null, blnShowModalMask);

    /// <summary>
    /// 	<para>Displays a message box with specified text.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(string strText, EventHandler objEventHandler) => MessageBox.ShowCore((Form) null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler);

    /// <summary>
    /// 	<para>Displays a message box with specified text.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore((Form) null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text and caption.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText, string strCaption,EventHandler
    ///     objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(string strText, string strCaption) => MessageBox.ShowCore((Form) null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null);

    /// <summary>
    /// 	<para>Displays a message box with specified text and caption.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText, string strCaption,EventHandler
    ///     objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(string strText, string strCaption, bool blnShowModalMask) => MessageBox.ShowCore((Form) null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null, blnShowModalMask);

    /// <summary>
    /// 	<para>Displays a message box with specified text and caption.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text and caption.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText,EventHandler
    ///     objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(Form objOwner, string strText) => MessageBox.ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null);

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText,EventHandler
    ///     objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(Form objOwner, string strText, bool blnShowModalMask) => MessageBox.ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null, blnShowModalMask);

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(Form objOwner, string strText, EventHandler objEventHandler) => MessageBox.ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler);

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text, caption, and buttons.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText, string strCaption, MessageBoxButtons
    ///     enmButtons,<br />
    ///     EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text, caption, and buttons.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText, string strCaption, MessageBoxButtons
    ///     enmButtons,<br />
    ///     EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text, caption, and buttons.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text, caption, and buttons.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text and caption.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText, string strCaption,EventHandler
    ///     objEventHandler).</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(Form objOwner, string strText, string strCaption) => MessageBox.ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null);

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text and caption.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText, string strCaption,EventHandler
    ///     objEventHandler).</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text and caption.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text and caption.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text, caption, buttons, and
    ///     icon.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText, string strCaption, MessageBoxButtons
    ///     enmButtons,<br />
    ///     MessageBoxIcon enmIcon,EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- The icon parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text, caption, buttons, and
    ///     icon.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText, string strCaption, MessageBoxButtons
    ///     enmButtons,<br />
    ///     MessageBoxIcon enmIcon,EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- The icon parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text, caption, buttons, and
    ///     icon.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- The icon parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text, caption, buttons, and
    ///     icon.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- The icon parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box with specified text, caption, buttons, and
    ///     icon.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The buttons parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- The icon parameter specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      bool blnShowModalMask,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, and buttons.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText, string strCaption,
    ///     MessageBoxButtons enmButtons, EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, and buttons.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText, string strCaption,
    ///     MessageBoxButtons enmButtons, EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, and buttons.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, and buttons.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box with the specified text, caption, buttons, icon, and
    ///     default button.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText, string strCaption, MessageBoxButtons
    ///     enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
    ///     enmDefaultButton,EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions) 0, (EventHandler) null);
    }

    /// <summary>
    /// 	<para>Displays a message box with the specified text, caption, buttons, icon, and
    ///     default button.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText, string strCaption, MessageBoxButtons
    ///     enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
    ///     enmDefaultButton,EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions) 0, (EventHandler) null, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box with the specified text, caption, buttons, icon, and
    ///     default button.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions) 0, objEventHandler);
    }

    /// <summary>
    /// 	<para>Displays a message box with the specified text, caption, buttons, icon, and
    ///     default button.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, and icon.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
    ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon,EventHandler
    ///     objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, and icon.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
    ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon,EventHandler
    ///     objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, (EventHandler) null, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, and icon.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, and icon.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box with the specified text, caption, buttons, icon,
    ///     default button, and options.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText, string strCaption,<br />
    ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
    ///     enmDefaultButton,<br />
    ///     MessageBoxOptions enmOptions,EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- The defaultButton specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, (EventHandler) null);
    }

    /// <summary>
    /// 	<para>Displays a message box with the specified text, caption, buttons, icon,
    ///     default button, and options.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(string strText, string strCaption,<br />
    ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
    ///     enmDefaultButton,<br />
    ///     MessageBoxOptions enmOptions,EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- The defaultButton specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, (EventHandler) null, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box with the specified text, caption, buttons, icon,
    ///     default button, and options.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- The defaultButton specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler);
    }

    /// <summary>
    /// 	<para>Displays a message box with the specified text, caption, buttons, icon,
    ///     default button, and options.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- The defaultButton specified is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore((Form) null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, icon, and default button.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
    ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
    ///     enmDefaultButton, EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions) 0, (EventHandler) null);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, icon, and default button.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
    ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
    ///     enmDefaultButton, EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions) 0, (EventHandler) null, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, icon, and default button.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions) 0, objEventHandler);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, icon, and default button.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, (MessageBoxOptions) 0, objEventHandler, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, icon, default button, and options.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
    ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
    ///     enmDefaultButton,<br />
    ///     MessageBoxOptions enmOptions,EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- options specified <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> or <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see> and specified a value in the owner parameter. These two options should be used only if you invoke the version of this method that does not take an owner parameter.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, (EventHandler) null);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, icon, default button, and options.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned use Show(Form objOwner, string strText, string strCaption,<br />
    ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
    ///     enmDefaultButton,<br />
    ///     MessageBoxOptions enmOptions,EventHandler objEventHandler)</para>
    /// </summary>
    /// <returns>
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- options specified <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> or <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see> and specified a value in the owner parameter. These two options should be used only if you invoke the version of this method that does not take an owner parameter.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, (EventHandler) null, blnShowModalMask);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, icon, default button, and options.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- options specified <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> or <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see> and specified a value in the owner parameter. These two options should be used only if you invoke the version of this method that does not take an owner parameter.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler);
    }

    /// <summary>
    /// 	<para>Displays a message box in front of the specified object and with the
    ///     specified text, caption, buttons, icon, default button, and options.</para>
    /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
    ///     after this call are executed immediately and won’t wait for the dialog to close. If
    ///     you need to run code only after the dialog is closed or only if a specific result
    ///     is returned place that code in the EventHandler function that will run once the
    ///     dialog is closed.</para>
    /// </summary>
    /// <returns>
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">options specified both <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> and <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see>.-or- options specified <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.DefaultDesktopOnly"></see> or <see cref="F:Gizmox.WebGUI.Forms.MessageBoxOptions.ServiceNotification"></see> and specified a value in the owner parameter. These two options should be used only if you invoke the version of this method that does not take an owner parameter.-or- buttons specified an invalid combination of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">buttons is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxButtons"></see>.-or- icon is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxIcon"></see>.-or- defaultButton is not a member of <see cref="T:Gizmox.WebGUI.Forms.MessageBoxDefaultButton"></see>. </exception>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to display the <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see> in a process that is not running in User Interactive mode. This is specified by the <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"></see> property. </exception>
    /// <example>
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
    public static DialogResult Show(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler, blnShowModalMask);
    }

    /// <summary>Core MessageBox implementation.</summary>
    /// <param name="objOwner">The obj owner.</param>
    /// <param name="strText">The STR text.</param>
    /// <param name="strCaption">The STR caption.</param>
    /// <param name="enmButtons">The enm buttons.</param>
    /// <param name="enmIcon">The enm icon.</param>
    /// <param name="enmDefaultButton">The enm default button.</param>
    /// <param name="enmOptions">The enm options.</param>
    /// <param name="objEventHandler">The obj event handler.</param>
    /// <returns>
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
    /// </returns>
    private static DialogResult ShowCore(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions,
      EventHandler objEventHandler)
    {
      return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler, true);
    }

    /// <summary>Core MessageBox implementation.</summary>
    /// <param name="objOwner">The obj owner.</param>
    /// <param name="strText">The STR text.</param>
    /// <param name="strCaption">The STR caption.</param>
    /// <param name="enmButtons">The enm buttons.</param>
    /// <param name="enmIcon">The enm icon.</param>
    /// <param name="enmDefaultButton">The enm default button.</param>
    /// <param name="enmOptions">The enm options.</param>
    /// <param name="objEventHandler">The obj event handler.</param>
    /// <param name="blnShowModalMask">Determines whether the message box should habe a modal mask.</param>
    /// <returns>
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
    /// </returns>
    private static DialogResult ShowCore(
      Form objOwner,
      string strText,
      string strCaption,
      MessageBoxButtons enmButtons,
      MessageBoxIcon enmIcon,
      MessageBoxDefaultButton enmDefaultButton,
      MessageBoxOptions enmOptions,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      MessageBoxWindow messageBoxWindow;
      DialogResult dialogResult;
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
        messageBoxWindow.Closed += objEventHandler;
      return dialogResult;
    }

    string ISkinable.Theme
    {
      get
      {
        IContext current = VWGContext.Current;
        return current != null ? current.CurrentTheme : string.Empty;
      }
    }
  }
}

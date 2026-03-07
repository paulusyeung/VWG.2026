#region Using

using System;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// Specifies constants defining which buttons to display on a <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see>.
    /// </summary>

    public enum MessageBoxButtons
    {
        /// <summary>
        /// The message box contains Abort, Retry, and Ignore buttons.
        /// </summary>
        AbortRetryIgnore = 2,
        /// <summary>
        /// The message box contains an OK button.
        /// </summary>
        OK = 0,
        /// <summary>
        /// The message box contains OK and Cancel buttons.
        /// </summary>
        OKCancel = 1,
        /// <summary>
        /// The message box contains Retry and Cancel buttons.
        /// </summary>
        RetryCancel = 5,
        /// <summary>
        /// The message box contains Yes and No buttons.
        /// </summary>
        YesNo = 4,
        /// <summary>
        /// The message box contains Yes, No, and Cancel buttons.
        /// </summary>
        YesNoCancel = 3
    }

    /// <summary>
    /// Specifies constants defining the default button on a <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see>.
    /// </summary>

    public enum MessageBoxDefaultButton
    {
        /// <summary>
        /// The first button on the message box is the default button.
        /// </summary>
        Button1 = 0,
        /// <summary>
        /// The second button on the message box is the default button.
        /// </summary>
        Button2 = 0x100,
        /// <summary>
        /// The third button on the message box is the default button.
        /// </summary>
        Button3 = 0x200
    }

    /// <summary>
    /// Specifies constants defining which information to display.
    /// </summary>

    public enum MessageBoxIcon
    {
        /// <summary>
        /// The message box contains a symbol consisting of a lowercase letter i in a circle.
        /// </summary>
        Asterisk = 0x40,
        /// <summary>
        /// The message box contains a symbol consisting of white X in a circle with a red background.
        /// </summary>
        Error = 0x10,
        /// <summary>
        /// The message box contains a symbol consisting of an exclamation point in a triangle with a yellow background.
        /// </summary>
        Exclamation = 0x30,
        /// <summary>
        /// The message box contains a symbol consisting of a white X in a circle with a red background.
        /// </summary>
        Hand = 0x50,
        /// <summary>
        /// The message box contains a symbol consisting of a lowercase letter i in a circle.
        /// </summary>
        Information = 0x60,
        /// <summary>
        /// The message box contain no symbols.
        /// </summary>
        None = 0,
        /// <summary>
        /// The message box contains a symbol consisting of a question mark in a circle.
        /// </summary>
        Question = 0x20,
        /// <summary>
        /// The message box contains a symbol consisting of white X in a circle with a red background.
        /// </summary>
        Stop = 0x70,
        /// <summary>
        /// The message box contains a symbol consisting of an exclamation point in a triangle with a yellow background.
        /// </summary>
        Warning = 0x80
    }

    /// <summary>
    /// Specifies options on a <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see>.
    /// </summary>
    [Flags]

    public enum MessageBoxOptions
    {
        /// <summary>
        /// The message box is displayed on the active desktop.
        /// </summary>
        DefaultDesktopOnly = 0x20000,
        /// <summary>
        /// The message box text is right-aligned.
        /// </summary>
        RightAlign = 0x80000,
        /// <summary>
        /// Specifies that the message box text is displayed with right to left reading order.
        /// </summary>
        RtlReading = 0x100000,
        /// <summary>
        /// The message box is displayed on the active desktop.
        /// </summary>
        ServiceNotification = 0x200000
    }


    #endregion Enums

    #region MessageBox Class

    /// <summary>
    /// Displays a message box that can contain text, buttons, and symbols that inform and instruct the user.
    /// </summary>
    [Skin(typeof(Skins.MessageBoxSkin)), Serializable()]
    public class MessageBox : ISkinable
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        private MessageBox()
        {
        }


        #endregion C'Tor / D'Tor

        #region Methods

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
        public static DialogResult Show(string strText)
        {
            return MessageBox.ShowCore(null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null);
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
        /// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>
        public static DialogResult Show(string strText, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, blnShowModalMask);
        }

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
        public static DialogResult Show(string strText, EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler);
        }

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
        public static DialogResult Show(string strText, EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler, blnShowModalMask);
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
        public static DialogResult Show(string strText, string strCaption)
        {
            return MessageBox.ShowCore(null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null);
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
        /// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
        public static DialogResult Show(string strText, string strCaption, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, blnShowModalMask);
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
        public static DialogResult Show(string strText, string strCaption, EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler);
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
        public static DialogResult Show(string strText, string strCaption, EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler, blnShowModalMask);
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
        public static DialogResult Show(Form objOwner, string strText)
        {
            return MessageBox.ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null);
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
        /// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
        public static DialogResult Show(Form objOwner, string strText, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, blnShowModalMask);
        }

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
        public static DialogResult Show(Form objOwner, string strText, EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler);
        }

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
        public static DialogResult Show(Form objOwner, string strText, EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler, blnShowModalMask);
        }

        /// <summary>
        /// 	<para>Displays a message box with specified text, caption, and buttons.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(string strText, string strCaption, MessageBoxButtons
        ///     enmButtons,<br/>
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null);
        }

        /// <summary>
        /// 	<para>Displays a message box with specified text, caption, and buttons.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(string strText, string strCaption, MessageBoxButtons
        ///     enmButtons,<br/>
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, blnShowModalMask);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler, blnShowModalMask);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null);
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
        /// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>        
        public static DialogResult Show(Form objOwner, string strText, string strCaption, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, blnShowModalMask);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption, EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption, EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler, blnShowModalMask);
        }


        /// <summary>
        /// 	<para>Displays a message box with specified text, caption, buttons, and
        ///     icon.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(string strText, string strCaption, MessageBoxButtons
        ///     enmButtons,<br/>
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, 0, null);
        }

        /// <summary>
        /// 	<para>Displays a message box with specified text, caption, buttons, and
        ///     icon.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(string strText, string strCaption, MessageBoxButtons
        ///     enmButtons,<br/>
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, 0, null, blnShowModalMask);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, 0, objEventHandler);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, 0, objEventHandler, blnShowModalMask);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, bool blnShowModalMask, EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, 0, objEventHandler, blnShowModalMask);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, null, blnShowModalMask);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, objEventHandler, blnShowModalMask);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, 0, null);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, 0, null, blnShowModalMask);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, 0, objEventHandler);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, 0, objEventHandler, blnShowModalMask);
        }


        /// <summary>
        /// 	<para>Displays a message box in front of the specified object and with the
        ///     specified text, caption, buttons, and icon.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(Form objOwner, string strText, string strCaption,<br/>
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, 0, null);
        }

        /// <summary>
        /// 	<para>Displays a message box in front of the specified object and with the
        ///     specified text, caption, buttons, and icon.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(Form objOwner, string strText, string strCaption,<br/>
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, 0, null, blnShowModalMask);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, 0, objEventHandler);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, MessageBoxDefaultButton.Button1, 0, objEventHandler, blnShowModalMask);
        }


        /// <summary>
        /// 	<para>Displays a message box with the specified text, caption, buttons, icon,
        ///     default button, and options.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(string strText, string strCaption,<br/>
        ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
        ///     enmDefaultButton,<br/>
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, null);
        }

        /// <summary>
        /// 	<para>Displays a message box with the specified text, caption, buttons, icon,
        ///     default button, and options.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(string strText, string strCaption,<br/>
        ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
        ///     enmDefaultButton,<br/>
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, null, blnShowModalMask);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton,
            MessageBoxOptions enmOptions, EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler);
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
        public static DialogResult Show(string strText, string strCaption, MessageBoxButtons enmButtons,
            MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton,
            MessageBoxOptions enmOptions, EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(null, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler, blnShowModalMask);
        }

        /// <summary>
        /// 	<para>Displays a message box in front of the specified object and with the
        ///     specified text, caption, buttons, icon, and default button.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(Form objOwner, string strText, string strCaption,<br/>
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, MessageBoxIcon enmIcon,
            MessageBoxDefaultButton enmDefaultButton)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, 0, null);
        }

        /// <summary>
        /// 	<para>Displays a message box in front of the specified object and with the
        ///     specified text, caption, buttons, icon, and default button.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(Form objOwner, string strText, string strCaption,<br/>
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, MessageBoxIcon enmIcon,
            MessageBoxDefaultButton enmDefaultButton, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, 0, null, blnShowModalMask);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton,
            EventHandler objEventHandler)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, 0, objEventHandler);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton,
            EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, 0, objEventHandler, blnShowModalMask);
        }

        /// <summary>
        /// 	<para>Displays a message box in front of the specified object and with the
        ///     specified text, caption, buttons, icon, default button, and options.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(Form objOwner, string strText, string strCaption,<br/>
        ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
        ///     enmDefaultButton,<br/>
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton,
            MessageBoxOptions enmOptions)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, null);
        }

        /// <summary>
        /// 	<para>Displays a message box in front of the specified object and with the
        ///     specified text, caption, buttons, icon, default button, and options.</para>
        /// 	<para>The Show MessageBox in Visual WebGui works differently  than WinForms. Code lines
        ///     after this call are executed immediately and won’t wait for the dialog to close. If
        ///     you need to run code only after the dialog is closed or only if a specific result
        ///     is returned use Show(Form objOwner, string strText, string strCaption,<br/>
        ///     MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton
        ///     enmDefaultButton,<br/>
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton,
            MessageBoxOptions enmOptions, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, null, blnShowModalMask);
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton,
            MessageBoxOptions enmOptions, EventHandler objEventHandler)
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
        public static DialogResult Show(Form objOwner, string strText, string strCaption,
            MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton,
            MessageBoxOptions enmOptions, EventHandler objEventHandler, bool blnShowModalMask)
        {
            return MessageBox.ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler, blnShowModalMask);
        }

        /// <summary>
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
        ///	<returns>
        /// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
        /// </returns>
        private static DialogResult ShowCore(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, EventHandler objEventHandler)
        {
            return ShowCore(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions, objEventHandler, true);
        }

        /// <summary>
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
        ///	<returns>
        /// One of the <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> values.
        /// </returns>
        private static DialogResult ShowCore(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions, EventHandler objEventHandler, bool blnShowModalMask)
        {
            DialogResult enmDialogResult = DialogResult.None;

            MessageBoxWindow objMessageBoxWindow = null;
            if (objOwner != null)
            {
                objMessageBoxWindow = new MessageBoxWindow(objOwner, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions);
                objMessageBoxWindow.ModalMask = blnShowModalMask;
                enmDialogResult = objMessageBoxWindow.ShowDialog(objOwner);
            }
            else
            {
                objMessageBoxWindow = new MessageBoxWindow(strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions);
                objMessageBoxWindow.ModalMask = blnShowModalMask;
                enmDialogResult = objMessageBoxWindow.ShowDialog();
            }

            if (objEventHandler != null)
            {
                objMessageBoxWindow.Closed += objEventHandler;
            }

            return enmDialogResult;
        }


        #endregion Methods


        #region ISkinable Members

        string ISkinable.Theme
        {
            get
            {
                IContext objContext = VWGContext.Current;
                if (objContext != null)
                {
                    return objContext.CurrentTheme;
                }
                return string.Empty;
            }
        }

        #endregion
    }

    #endregion MessageBox Class

}
namespace Gizmox.WebGUI.Forms.Layout
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using Gizmox.WebGUI.Forms;

    /// <summary>
    /// 
    /// </summary>
    internal interface IArrangedElement : IComponent, IDisposable
    {
        /// <summary>
        /// Gets the size of the preferred.
        /// </summary>
        /// <param name="objProposedSize">Size of the proposed.</param>
        /// <returns></returns>
        Size GetPreferredSize(Size objProposedSize);

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        ArrangedElementCollection Children { get; }

        /// <summary>
        /// Gets a value indicating whether [participates in layout].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [participates in layout]; otherwise, <c>false</c>.
        /// </value>
        bool ParticipatesInLayout { get; }


        /// <summary>
        /// Sets the bounds.
        /// </summary>
        /// <param name="objBounds">The bounds.</param>
        /// <param name="enmSpecified">The specified.</param>
        void SetBounds(Rectangle objBounds, BoundsSpecified enmSpecified);

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <value>The bounds.</value>
        Rectangle Bounds { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="objSerializableProperty">The serializable property.</param>
        /// <returns></returns>
        T GetValue<T>(SerializableProperty objSerializableProperty);

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objSerializableProperty">The serializable property.</param>
        /// <param name="objValue">The obj value.</param>
        void SetValue<T>(SerializableProperty objSerializableProperty, T objValue);

    }
}


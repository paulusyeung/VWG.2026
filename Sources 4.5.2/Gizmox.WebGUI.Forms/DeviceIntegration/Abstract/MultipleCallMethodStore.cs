using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.Abstract
{
    /// <summary>
    /// Represents store for device component multiple-call methods.
    /// </summary>
    /// <typeparam name="TEventArgsType">The type of the event args type.</typeparam>
    [Serializable]
    internal class MultipleCallMethodStore<TEventArgsType> where TEventArgsType : EventArgs
    {
        /// <summary>
        /// Multiple-call event handler.
        /// </summary>
        private Action<TEventArgsType> mobjMultipleCallMethods;

        /// <summary>
        /// Invokes the multiple call method.
        /// </summary>
        /// <param name="args">The args.</param>
        protected internal void InvokeMultipleCallMethods(TEventArgsType args)
        {
            // Raise All stored methods
            if (mobjMultipleCallMethods != null)
            {
                mobjMultipleCallMethods(args);
            }
        }

        /// <summary>
        /// Adds the multiple call method.
        /// </summary>
        /// <param name="objMethod">The obj method.</param>
        internal void AddMultipleCallMethod(Action<TEventArgsType> objMethod)
        {
            mobjMultipleCallMethods += objMethod;

        }

        /// <summary>
        /// Removes the multiple call method.
        /// </summary>
        /// <param name="objMethod">The obj method.</param>
        internal void RemoveMultipleCallMethod(Action<TEventArgsType> objMethod)
        {
            mobjMultipleCallMethods -= objMethod;

        }

        /// <summary>
        /// Determines whether [has event listeners].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has event listeners]; otherwise, <c>false</c>.
        /// </returns>
        internal bool HasEventListeners()
        {
            return mobjMultipleCallMethods != null && mobjMultipleCallMethods.GetInvocationList().Length > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.Abstract
{
    /// <summary>
    /// Represents store for device component single-call methods.
    /// </summary>
    /// <typeparam name="TEventArgsType">The type of the event args type.</typeparam>
    [Serializable]
    internal class SingleCallMethodStore<TEventArgsType> where TEventArgsType : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEventArgsType">The type of the event args type.</typeparam>
        private class ContextualData<TEventArgsType>
            where TEventArgsType : EventArgs
        {
            private object mobjContext;
            private EventHandler<TEventArgsType> mobjHandler;

            /// <summary>
            /// Initializes a new instance of the <see cref="SingleCallMethodStore&lt;TEventArgsType&gt;.ContextualData&lt;TEventArgsType&gt;"/> class.
            /// </summary>
            /// <param name="objContext">The obj context.</param>
            /// <param name="objHandler">The obj handler.</param>
            public ContextualData(object objContext, EventHandler<TEventArgsType> objHandler)
            {
                mobjContext = objContext;
                mobjHandler = objHandler;
            }

            /// <summary>
            /// Gets the context.
            /// </summary>
            internal object Context
            {
                get { return mobjContext; }
            }

            /// <summary>
            /// Gets the handler.
            /// </summary>
            internal EventHandler<TEventArgsType> Handler
            {
                get { return mobjHandler; }
            }
        }

        /// <summary>
        /// Stores typed EventHandlers by key. 
        /// </summary>
        private Dictionary<string, Action<TEventArgsType>> mobjMethodsIndexByMethodKey;
        private Dictionary<string, ContextualData<TEventArgsType>> mobjContextualMethodsIndexByMethodKey;

        /// <summary>
        /// Gets the contextual methods.
        /// </summary>
        private Dictionary<string, ContextualData<TEventArgsType>> ContextualMethods
        {
            get
            {
                if (mobjContextualMethodsIndexByMethodKey == null)
                {
                    mobjContextualMethodsIndexByMethodKey = new Dictionary<string, ContextualData<TEventArgsType>>();
                }

                return mobjContextualMethodsIndexByMethodKey;
            }
        }

        /// <summary>
        /// Gets the methods store.
        /// </summary>
        private Dictionary<string, Action<TEventArgsType>> Methods
        {
            get
            {
                // If does not exist, create a new store
                if (mobjMethodsIndexByMethodKey == null)
                {
                    mobjMethodsIndexByMethodKey = new Dictionary<string, Action<TEventArgsType>>();
                }
                return mobjMethodsIndexByMethodKey;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleCallMethodStore&lt;TEventArgsType&gt;"/> class.
        /// </summary>
        internal SingleCallMethodStore()
        {
        }

        /// <summary>
        /// Stores a single-call method.
        /// </summary>
        /// <param name="objMethod">The method.</param>
        /// <returns></returns>
        internal string StoreSingleCallMethod(Action<TEventArgsType> objMethod)
        {
            return StoreSingleCallMethod(null, objMethod);
        }

        internal string StoreContextualSingleCallMethod(object objThis, string strPrefix, EventHandler<TEventArgsType> objMethod)
        {
            if (objMethod != null)
            {
                // Create an identifier for the method
                string strMethodKey = Guid.NewGuid().ToString("N");

                // Store inside a dictionary
                ContextualMethods.Add(strMethodKey, new ContextualData<TEventArgsType>(objThis, objMethod));

                if (!string.IsNullOrEmpty(strPrefix))
                {
                    strMethodKey = strPrefix + "-" + strMethodKey;
                }

                // Return the newly created key
                return strMethodKey;
            }

            return null;
        }

        /// <summary>
        /// Stores a single-call method.
        /// </summary>
        /// <param name="objMethod">The method.</param>
        /// <returns></returns>
        internal string StoreSingleCallMethod(string strPrefix, Action<TEventArgsType> objMethod)
        {
            if (objMethod != null)
            {
                // Create an identifier for the method
                string strMethodKey = Guid.NewGuid().ToString("N");

                // Store inside a dictionary
                Methods.Add(strMethodKey, objMethod);

                if (!string.IsNullOrEmpty(strPrefix))
                {
                    strMethodKey = strPrefix + "-" + strMethodKey;
                }

                // Return the newly created key
                return strMethodKey;
            }

            return null;
        }

        /// <summary>
        /// Determines whether [has registered method] [the specified STR method key].
        /// </summary>
        /// <param name="strMethodKey">The STR method key.</param>
        /// <returns>
        ///   <c>true</c> if [has registered method] [the specified STR method key]; otherwise, <c>false</c>.
        /// </returns>
        internal bool HasRegisteredMethod(string strMethodKey)
        {
            // Checks if there's a registered method
            return Methods.ContainsKey(strMethodKey);
        }

        /// <summary>
        /// Invokes the contextual method.
        /// </summary>
        /// <param name="strMethodKey">The STR method key.</param>
        /// <param name="args">The args.</param>
        internal protected void InvokeContextualMethod(string strMethodKey, TEventArgsType args)
        {
            if (ContextualMethods.ContainsKey(strMethodKey))
            {
                ContextualData<TEventArgsType> objData = ContextualMethods[strMethodKey];

                objData.Handler(objData.Context, args);

                ContextualMethods.Remove(strMethodKey);
            }
        }

        /// <summary>
        /// Invokes the single call method.
        /// </summary>
        /// <param name="strMethodKey">The STR method key.</param>
        /// <param name="args">The args.</param>
        internal protected void InvokeSingleCallMethod(string strMethodKey, TEventArgsType args)
        {
            if (Methods.ContainsKey(strMethodKey))
            {
                // Invoke the method
                Methods[strMethodKey](args);

                // Remove the method after invocation
                Methods.Remove(strMethodKey);
            }
            else
            {
                // throw ???
            }
        }

        internal TContextType GetContaxt<TContextType>(string strMethodKey)
            where TContextType : class
        {
            if (ContextualMethods.ContainsKey(strMethodKey))
            {
                return ContextualMethods[strMethodKey].Context as TContextType;
            }

            return null;
        }


        /// <summary>
        /// Determines whether [has event listeners].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has event listeners]; otherwise, <c>false</c>.
        /// </returns>
        internal bool HasEventListeners()
        {
            return Methods.Count > 0;
        }
    }
}

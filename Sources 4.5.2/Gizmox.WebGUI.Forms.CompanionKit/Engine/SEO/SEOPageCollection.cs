using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;


namespace Gizmox.WebGUI.Forms.SEO
{
    /// <summary>
    /// 
    /// </summary>
    public class SEOPageCollection : IEnumerable<SEOPage>
    {
        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<SEOItem> mobjItems = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SEOPageCollection"/> class.
        /// </summary>
        /// <param name="objItems">The obj items.</param>
        internal SEOPageCollection(IEnumerable<SEOItem> objItems)
        {
            mobjItems = objItems;
        }

        /// <summary>
        /// 
        /// </summary>
        internal class SEOPageEnumerator : IEnumerator<SEOPage>
        {
            /// <summary>
            /// 
            /// </summary>
            private IEnumerator<SEOItem> mobjItems = null;

            /// <summary>
            /// Initializes a new instance of the <see cref="SEOPageEnumerator"/> class.
            /// </summary>
            /// <param name="objItems">The obj items.</param>
            internal SEOPageEnumerator(IEnumerator<SEOItem> objItems)
            {
                mobjItems = objItems;
            }

            #region IEnumerator<SEOPage> Members

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            /// <value></value>
            /// <returns>
            /// The element in the collection at the current position of the enumerator.
            /// </returns>
            public SEOPage Current
            {
                get
                {
                    return mobjItems.Current as SEOPage;
                }
            }

            #endregion

            #region IDisposable Members

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                mobjItems.Dispose();
            }

            #endregion

            #region IEnumerator Members

            object IEnumerator.Current
            {
                get
                {
                    return mobjItems.Current;
                }
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="T:System.InvalidOperationException">
            /// The collection was modified after the enumerator was created.
            /// </exception>
            public bool MoveNext()
            {
                // Loop until next item
                while (mobjItems.MoveNext())
                {
                    // If is next item
                    if (mobjItems.Current is SEOPage)
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            /// <exception cref="T:System.InvalidOperationException">
            /// The collection was modified after the enumerator was created.
            /// </exception>
            public void Reset()
            {
                mobjItems.Reset();
            }

            #endregion
        }

        #region IEnumerable<SEOPage> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<SEOPage> GetEnumerator()
        {
            return new SEOPageEnumerator(mobjItems.GetEnumerator());
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SEOPageEnumerator(mobjItems.GetEnumerator());
        }

        #endregion
    }

    /// <summary>
    /// The collection of non-container SEO items (not folder like)
    /// </summary>
    public class SEOPlainCollection : IEnumerable<SEOItem>
    {
        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<SEOItem> mobjItems = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SEOPlainCollection"/> class.
        /// </summary>
        /// <param name="objItems">The obj items.</param>
        internal SEOPlainCollection(IEnumerable<SEOItem> objItems)
        {
            mobjItems = objItems;
        }

        /// <summary>
        /// 
        /// </summary>
        internal class SEOPlainEnumerator : IEnumerator<SEOItem>
        {
            /// <summary>
            /// 
            /// </summary>
            private IEnumerator<SEOItem> mobjItems = null;

            /// <summary>
            /// Initializes a new instance of the <see cref="SEOPlainEnumerator"/> class.
            /// </summary>
            /// <param name="objItems">The obj items.</param>
            internal SEOPlainEnumerator(IEnumerator<SEOItem> objItems)
            {
                mobjItems = objItems;
            }

            #region IEnumerator<SEOItem> Members

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            /// <value></value>
            /// <returns>
            /// The element in the collection at the current position of the enumerator.
            /// </returns>
            public SEOItem Current
            {
                get
                {
                    return mobjItems.Current;
                }
            }

            #endregion

            #region IDisposable Members

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                mobjItems.Dispose();
            }

            #endregion

            #region IEnumerator Members

            object IEnumerator.Current
            {
                get
                {
                    return mobjItems.Current;
                }
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="T:System.InvalidOperationException">
            /// The collection was modified after the enumerator was created.
            /// </exception>
            public bool MoveNext()
            {
                // Loop until next item
                while (mobjItems.MoveNext())
                {
                    // If is next item
                    if (!(mobjItems.Current is SEOFolder))
                    {
                        return true;
                    }

                }
                return false;
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            /// <exception cref="T:System.InvalidOperationException">
            /// The collection was modified after the enumerator was created.
            /// </exception>
            public void Reset()
            {
                mobjItems.Reset();
            }

            #endregion
        }

        #region IEnumerable<SEOItem> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<SEOItem> GetEnumerator()
        {
            return new SEOPlainEnumerator(mobjItems.GetEnumerator());
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SEOPlainEnumerator(mobjItems.GetEnumerator());
        }

        #endregion
    }

}

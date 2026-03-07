#region Using

using System;
using System.Collections;
using System.Reflection;

#endregion

namespace Gizmox.WebGUI.Forms.Layout
{
    /// <summary>Represents a collection of objects.</summary>
    [Serializable()]
    public class ArrangedElementCollection : IList, ICollection, IEnumerable
    {
        private ArrayList mobjInnerList;
        internal static ArrangedElementCollection Empty;

        static ArrangedElementCollection()
        {
            ArrangedElementCollection.Empty = new ArrangedElementCollection(0);
        }

        internal ArrangedElementCollection()
        {
            this.mobjInnerList = new ArrayList(4);
        }

        internal ArrangedElementCollection(ArrayList innerList)
        {
            this.mobjInnerList = innerList;
        }

        private ArrangedElementCollection(int intSize)
        {
            this.mobjInnerList = new ArrayList(intSize);
        }

        private static void Copy(ArrangedElementCollection objSourceList, int intSourceIndex, ArrangedElementCollection objDestinationList, int intDestinationIndex, int intLength)
        {
            if (intSourceIndex < intDestinationIndex)
            {
                intSourceIndex += intLength;
                intDestinationIndex += intLength;
                while (intLength > 0)
                {
                    objDestinationList.InnerList[--intDestinationIndex] = objSourceList.InnerList[--intSourceIndex];
                    intLength--;
                }
            }
            else
            {
                while (intLength > 0)
                {
                    objDestinationList.InnerList[intDestinationIndex++] = objSourceList.InnerList[intSourceIndex++];
                    intLength--;
                }
            }
        }

        /// <summary>Copies the entire contents of this collection to a compatible one-dimensional <see cref="T:System.Array"></see>, starting at the specified index of the target array.</summary>
        /// <param name="objArray">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from the current collection. The array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        /// <exception cref="T:System.InvalidCastException">The type of the source element cannot be cast automatically to the type of array.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException">One of the following conditions has occurred:array is multidimensional.index is equal to or greater than the length of array.The number of elements in the source collection is greater than the available space from index to the end of array.</exception>
        /// <exception cref="T:System.ArgumentNullException">array is null.</exception>
        public void CopyTo(Array objArray, int index)
        {
            this.InnerList.CopyTo(objArray, index);
        }

        /// <summary>Determines whether two <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see> instances are equal.</summary>
        /// <returns>true if the specified <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see> is equal to the current <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see>; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see> to compare with the current <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see>.</param>
        public override bool Equals(object obj)
        {
            ArrangedElementCollection objCollection1 = obj as ArrangedElementCollection;
            if ((objCollection1 == null) || (this.Count != objCollection1.Count))
            {
                return false;
            }
            for (int intNum1 = 0; intNum1 < this.Count; intNum1++)
            {
                if (this.InnerList[intNum1] != objCollection1.InnerList[intNum1])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>Returns an enumerator for the entire collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for the entire collection.</returns>
        public virtual IEnumerator GetEnumerator()
        {
            return this.InnerList.GetEnumerator();
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A hash code for the current <see cref="T:Gizmox.WebGUI.Forms.Layout.ArrangedElementCollection"></see>.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal void MoveElement(IArrangedElement objElement, int intFromIndex, int intToIndex)
        {
            int intNum1 = intToIndex - intFromIndex;
            switch (intNum1)
            {
                case -1:
                case 1:
                    this.InnerList[intFromIndex] = this.InnerList[intToIndex];
                    break;

                default:
                    {
                        int intNum2 = 0;
                        int intNum3 = 0;
                        if (intNum1 > 0)
                        {
                            intNum2 = intFromIndex + 1;
                            intNum3 = intFromIndex;
                        }
                        else
                        {
                            intNum2 = intToIndex;
                            intNum3 = intToIndex + 1;
                            intNum1 = -intNum1;
                        }
                        ArrangedElementCollection.Copy(this, intNum2, this, intNum3, intNum1);
                        break;
                    }
            }
            this.InnerList[intToIndex] = objElement;

        }

        int IList.Add(object objValue)
        {
            return this.InnerList.Add(objValue);
        }

        void IList.Clear()
        {
            this.InnerList.Clear();
        }

        bool IList.Contains(object objValue)
        {
            return this.InnerList.Contains(objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.InnerList.IndexOf(objValue);
        }

        void IList.Insert(int index, object objValue)
        {
            throw new NotSupportedException();
        }

        void IList.Remove(object objValue)
        {
            this.InnerList.Remove(objValue);
        }

        void IList.RemoveAt(int index)
        {
            this.InnerList.RemoveAt(index);
        }

        /// <summary>Gets the number of elements in the collection.</summary>
        /// <returns>The number of elements currently contained in the collection.</returns>
        public virtual int Count
        {
            get
            {
                return this.InnerList.Count;
            }
        }

        internal ArrayList InnerList
        {
            get
            {
                return this.mobjInnerList;
            }
        }

        /// <summary>Gets a value indicating whether the collection is read-only.</summary>
        /// <returns>true if the collection is read-only; otherwise, false. The default is false.</returns>
        public virtual bool IsReadOnly
        {
            get
            {
                return this.InnerList.IsReadOnly;
            }
        }

        internal virtual IArrangedElement this[int index]
        {
            get
            {
                return (IArrangedElement)this.InnerList[index];
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return this.InnerList.IsSynchronized;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this.InnerList.SyncRoot;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return this.InnerList.IsFixedSize;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this.InnerList[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }
    }
}
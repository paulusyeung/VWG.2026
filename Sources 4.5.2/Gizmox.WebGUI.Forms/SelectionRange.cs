using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [TypeConverter(typeof(SelectionRangeConverter))]
    public sealed class SelectionRange
    {
        #region Fields (2)

        private DateTime end;
        private DateTime start;

        #endregion Fields

        #region Constructors (3)

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionRange"/> class.
        /// </summary>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        public SelectionRange(DateTime lower, DateTime upper)
        {
            this.start = DateTime.MinValue.Date;
            this.end = DateTime.MaxValue.Date;
            if (lower < upper)
            {
                this.start = lower.Date;
                this.end = upper.Date;
            }
            else
            {
                this.start = upper.Date;
                this.end = lower.Date;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionRange"/> class.
        /// </summary>
        /// <param name="range">The range.</param>
        public SelectionRange(SelectionRange range)
        {
            this.start = DateTime.MinValue.Date;
            this.end = DateTime.MaxValue.Date;
            this.start = range.start;
            this.end = range.end;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionRange"/> class.
        /// </summary>
        public SelectionRange()
        {
            this.start = DateTime.MinValue.Date;
            this.end = DateTime.MaxValue.Date;
        }

        #endregion Constructors

        #region Properties (2)

        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public DateTime End
        {
            get
            {
                return this.end;
            }
            set
            {
                this.end = value.Date;
            }
        }

        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public DateTime Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value.Date;
            }
        }

        #endregion Properties

        #region Methods (1)

        // Public Methods (1) 

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return ("SelectionRange: Start: " + this.start.ToString() + ", End: " + this.end.ToString());
        }

        #endregion Methods
    }


}

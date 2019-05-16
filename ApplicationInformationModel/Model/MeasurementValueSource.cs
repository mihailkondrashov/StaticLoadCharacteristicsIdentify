using System;
using System.Collections.Generic;

namespace ApplicationInformationModel.Model
{
    /// <summary>
    /// MeasurementValueSource describes the alternative sources updating a MeasurementValue
    /// </summary>
    public class MeasurementValueSource:IdentifiedObject
    {
        /// <summary>
        /// Collection of object of class AnalogValue
        /// </summary>
        public virtual ICollection<AnalogValue> AnalogValues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MeasurementValueSource() { }

        /// <summary>
        /// Constructor of class MeasurementValueSource
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        public MeasurementValueSource(Guid mRid, string name) : base(mRid, name)
        {

        }
    }
}
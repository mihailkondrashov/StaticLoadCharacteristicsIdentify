using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationInformationModel.Model
{
    /// <summary>
    /// AnalogValue represents an analog MeasurementValue
    /// </summary>
    public class AnalogValue:MeasurementValue
    {
        /// <summary>
        /// The value to supervise
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? Analog_MRID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? MeasurementValueSource_MRID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("Analog_MRID")]
        public virtual Analog Analog { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("MeasurementValueSource_MRID")]
        public virtual MeasurementValueSource MeasurementValueSource { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AnalogValue() { }

        /// <summary>
        /// Constructor of class AnalogValue
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="sensorAccuracy">The limit, expressed as a percentage of the sensor maximum, that errors will not exceed when the sensor is used under reference conditions</param>
        /// <param name="timeStamp">The time when the value was last updated</param>
        /// <param name="value">The value to supervise</param>
        public AnalogValue(Guid mRid, string name, double sensorAccuracy, DateTime timeStamp, double value) : base(mRid, name, sensorAccuracy, timeStamp)
        {
            this.Value = value;
        }
    }
}
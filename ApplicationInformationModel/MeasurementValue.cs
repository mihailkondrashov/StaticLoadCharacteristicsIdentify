using System;

namespace ApplicationInformationModel
{
    /// <summary>
    /// The current state for a measurement
    /// </summary>
    public class MeasurementValue:IdentifiedObject
    {
        /// <summary>
        /// The limit, expressed as a percentage of the sensor maximum, that errors will not exceed when the sensor is used under reference conditions
        /// </summary>
        public double SensorAccuracy { get; }

        /// <summary>
        /// The time when the value was last updated
        /// </summary>
        public DateTime TimeStamp { get; }

        /// <summary>
        /// Constructor of class MeasurementValue
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="sensorAccuracy">The limit, expressed as a percentage of the sensor maximum, that errors will not exceed when the sensor is used under reference conditions</param>
        /// <param name="timeStamp">The time when the value was last updated</param>
        public MeasurementValue(Guid mRid, string name, double sensorAccuracy, DateTime timeStamp) : base(mRid, name)
        {
            //TODO:Checking input argumenties
            this.SensorAccuracy = sensorAccuracy;
            this.TimeStamp = timeStamp;
        }
    }
}
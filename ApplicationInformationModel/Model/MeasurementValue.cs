using System;

namespace ApplicationInformationModel.Model
{
    /// <summary>
    /// The current state for a measurement
    /// </summary>
    public class MeasurementValue:IdentifiedObject
    {
        /// <summary>
        /// The limit, expressed as a percentage of the sensor maximum, that errors will not exceed when the sensor is used under reference conditions
        /// </summary>
        public double SensorAccuracy { get; } = 0.2;

        /// <summary>
        /// The time when the value was last updated
        /// </summary>
        public DateTime TimeStamp { get; }

        /// <summary>
        /// No parametrless constructor of class MeasurementValue
        /// </summary>
        public MeasurementValue() { }

        /// <summary>
        /// Constructor of class MeasurementValue
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="sensorAccuracy">The limit, expressed as a percentage of the sensor maximum, that errors will not exceed when the sensor is used under reference conditions</param>
        /// <param name="timeStamp">The time when the value was last updated</param>
        public MeasurementValue(Guid mRid, string name, double sensorAccuracy, DateTime timeStamp) : base(mRid, name)
        {
            SensorAccuracy = sensorAccuracy;
            TimeStamp = timeStamp;
        }
    }
}
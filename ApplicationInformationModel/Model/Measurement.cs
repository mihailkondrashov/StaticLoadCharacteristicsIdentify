using System;

namespace ApplicationInformationModel.Model
{
    /// <summary>
    /// A Measurement represents any measured, calculated or non-measured non-calculated quantity
    /// </summary>
    public class Measurement:IdentifiedObject
    {
        /// <summary>
        /// Specifies the type of Measurement, e.g. IndoorTemperature, OutDoorTemperature, BusVoltage, GeneratorVoltage, LineFlow etc
        /// </summary>
        public string MeasurementType { get; }

        /// <summary>
        /// Constructor of class Measurement
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="measurementType">Specifies the type of Measurement, e.g. IndoorTemperature, OutDoorTemperature, BusVoltage, GeneratorVoltage, LineFlow etc</param>
        public Measurement(Guid mRid, string name, string measurementType) : base(mRid, name)
        {
            #region CheckingInputArguments
            if (string.IsNullOrWhiteSpace(measurementType))
            {
                throw new ArgumentNullException("MeasurementType musn`t be null", nameof(measurementType));
            }
            #endregion

            this.MeasurementType = measurementType;
        }
    }
}
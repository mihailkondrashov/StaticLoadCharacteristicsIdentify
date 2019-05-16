using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationInformationModel.Model
{
    /// <summary>
    /// A Measurement represents any measured, calculated or non-measured non-calculated quantity
    /// </summary>
    public class Measurement:IdentifiedObject
    {
        /// <summary>
        /// Idectificator of MeasurementType (ForeignKey)
        /// </summary>
        public int MeasurementType_ID { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        [ForeignKey("MeasurementType_ID")]
        /// <summary>
        /// Specifies the type of Measurement, e.g. IndoorTemperature, OutDoorTemperature, BusVoltage, GeneratorVoltage, LineFlow etc
        /// </summary>
        public MeasurementType MeasurementType { get; set; }

        /// <summary>
        /// No parametrless contructor of class Measurement
        /// </summary>
        public Measurement() { }

        /// <summary>
        /// Constructor of class Measurement
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="measurementType">Specifies the type of Measurement, e.g. IndoorTemperature, OutDoorTemperature, BusVoltage, GeneratorVoltage, LineFlow etc</param>
        public Measurement(Guid mRid, string name, MeasurementType measurementType) : base(mRid, name)
        {
            this.MeasurementType = measurementType;
            this.MeasurementType_ID = measurementType.Id;
        }
    }
}
using System;

namespace ApplicationInformationModel
{
    /// <summary>
    /// Analog represents an analog Measurement
    /// </summary>
    public class Analog:Measurement
    {
        /// <summary>
        /// If true then this measurement is an active power, reactive power or current with the convention that a positive value measured at the Terminal means power is flowing into the related PowerSystemResource
        /// </summary>
        public bool PositiveFlowIn { get; }

        /// <summary>
        /// Normal value range minimum for any of the MeasurementValue.values
        /// </summary>
        public double MinValue { get; }

        /// <summary>
        /// Normal value range maximum for any of the MeasurementValue.values
        /// </summary>
        public double MaxValue { get; }

        /// <summary>
        /// Normal measurement value, e.g., used for percentage calculations
        /// </summary>
        public double NormalValue { get; }

        /// <summary>
        /// Constructor of class Analog
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="measurementType">Specifies the type of Measurement, e.g. IndoorTemperature, OutDoorTemperature, BusVoltage, GeneratorVoltage, LineFlow etc</param>
        /// <param name="positiveFlowIn">If true then this measurement is an active power, reactive power or current with the convention that a positive value measured at the Terminal means power is flowing into the related PowerSystemResource</param>
        /// <param name="minValue">Normal value range minimum for any of the MeasurementValue.values</param>
        /// <param name="maxValue">Normal value range maximum for any of the MeasurementValue.values</param>
        /// <param name="normalValue">Normal measurement value, e.g., used for percentage calculations</param>
        public Analog(Guid mRid, string name, string measurementType, bool positiveFlowIn, double minValue, double maxValue, double normalValue) : base(mRid, name, measurementType)
        {
            this.PositiveFlowIn = positiveFlowIn;
            this.MaxValue = maxValue;
            this.MinValue = minValue;
            this.NormalValue = normalValue;
        }
    }
}
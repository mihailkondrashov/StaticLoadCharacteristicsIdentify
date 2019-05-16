using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationInformationModel.Model
{
    /// <summary>
    /// Analog represents an analog Measurement
    /// </summary>
    public class Analog:Measurement
    {
        /// <summary>
        /// If true then this measurement is an active power, reactive power or current with the convention that a positive value measured at the Terminal means power is flowing into the related PowerSystemResource
        /// </summary>
        public bool PositiveFlowIn { get; set; }

        /// <summary>
        /// Normal value range minimum for any of the MeasurementValue.values
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// Normal value range maximum for any of the MeasurementValue.values
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// Normal measurement value, e.g., used for percentage calculations
        /// </summary>
        public double NormalValue { get; set; }

        /// <summary>
        /// Foreign property
        /// </summary>
        public Guid? EnergyConsumer_MRID { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        [ForeignKey("EnergyConsumer_MRID")]
        public virtual EnergyConsumer EnergyConsumer { get; set; }

        /// <summary>
        /// Collection of object of class AnalogValue
        /// </summary>
        public virtual ICollection<AnalogValue> AnalogValues { get; set; }

        /// <summary>
        /// No parameterless constructor of class Analog
        /// </summary>
        public Analog() { }

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
        public Analog(Guid mRid, string name, MeasurementType measurementType, bool positiveFlowIn, double minValue, double maxValue, double normalValue) : base(mRid, name, measurementType)
        {
            #region Checking Input Arguments
            if (minValue > normalValue)
            {
                throw new ArgumentException("Input argument 'minValue' mustn`t be more than 'nornValue'");
            }

            if (normalValue > maxValue)
            {
                throw new ArgumentException("Input argument 'normValue' mustn`t be more than 'maxValue'");
            }
            #endregion

            this.PositiveFlowIn = positiveFlowIn;
            this.MaxValue = maxValue;
            this.MinValue = minValue;
            this.NormalValue = normalValue;
        }

        /// <summary>
        /// Setting involves object of class EnergyConsumer
        /// </summary>
        /// <param name="energyConsumer">Object of class EnergyConsumer</param>
        public void SetEnergyConsumer(EnergyConsumer energyConsumer)
        {
            if (energyConsumer != null)
            {
                this.EnergyConsumer = energyConsumer;
                this.EnergyConsumer_MRID = EnergyConsumer.MRID;
            }
            else
            {
                throw new ArgumentNullException("Input argument 'energyConsumer' mustn`t be a null", nameof(energyConsumer));
            }
        }
    }
}
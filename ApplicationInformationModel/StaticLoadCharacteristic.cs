using System;

namespace ApplicationInformationModel
{
    /// <summary>
    /// Models the characteristic response of the load demand due to to changes in system conditions such as voltage and frequency
    /// </summary>
    public class StaticLoadCharacteristic : IdentifiedObject
    {
        /// <summary>
        ///  Indicates the exponential voltage dependency model (pVoltateExponent and qVoltageExponent) is to be used. Default is false
        /// </summary>
        public bool ExponentModel { get; } = false;

        /// <summary>
        /// Portion of active power load modeled as constant current
        /// </summary>
        public double PConstantCurrent { get; set; }

        /// <summary>
        /// Portion of reactive power load modeled as constant current
        /// </summary>
        public double QConstantCurrent { get; set; }

        /// <summary>
        /// Portion of active power load modeled as constant power
        /// </summary>
        public double PConstantPower { get; set; }

        /// <summary>
        /// Portion of reactive power load modeled as constant power
        /// </summary>
        public double QConstantPower { get; set; }

        /// <summary>
        /// Portion of active power load modeled as constant impedance
        /// </summary>
        public double PConstantImpendance { get; set; }

        /// <summary>
        /// Portion of reactive power load modeled as constant impedance
        /// </summary>
        public double QConstantImpendance { get; set; }

        /// <summary>
        /// Exponent of per unit frequency effecting active power
        /// </summary>
        public double PFrequencyExponent { get; set; }

        /// <summary>
        /// Exponent of per unit voltage effecting real power
        /// </summary>
        public double PVoltageExponent { get; set; }

        /// <summary>
        /// Exponent of per unit frequency effecting reactive power
        /// </summary>
        public double QFrequencyExponent { get; set; }

        /// <summary>
        /// Exponent of per unit voltage effecting reactive power
        /// </summary>
        public double QVoltageExponent { get; set; }

        /// <summary>
        /// Constructor of a class StaticLoadCharacteristic
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="qFrequencyExponent">Exponent of per unit frequency effecting reactive power</param>
        /// <param name="pFrequencyExponent">Exponent of per unit frequency effecting active power</param>
        /// <param name="exponentModel">Indicates the exponential voltage dependency model (pVoltateExponent and qVoltageExponent) is to be used</param>
        public StaticLoadCharacteristic(Guid mRid, string name, double qFrequencyExponent, double pFrequencyExponent, bool exponentModel) : base(mRid, name)
        {
            #region Checking Input Arguments
            if (qFrequencyExponent > 1 || qFrequencyExponent < 0)
            {
                throw new ArgumentOutOfRangeException("qFrequencyExponent mustn`t be less than 0 or more than 1", nameof(qFrequencyExponent));
            }
            if (pFrequencyExponent > 1 || pFrequencyExponent < 0)
            {
                throw new ArgumentOutOfRangeException("pFrequencyExponent mustn`t be less than 0 or more than 1", nameof(pFrequencyExponent));
            }
            #endregion

            this.PFrequencyExponent = pFrequencyExponent;
            this.QFrequencyExponent = qFrequencyExponent;
            this.ExponentModel = exponentModel;
        }

        /// <summary>
        /// Constructor of a class StaticLoadCharacteristic
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="pConstantCurrent">Portion of active power load modeled as constant current</param>
        /// <param name="pConstantImpendance">Portion of active power load modeled as constant impedance</param>
        /// <param name="pConstantPower">Portion of active power load modeled as constant power</param>
        /// <param name="qConstantCurrent">Portion of reactive power load modeled as constant current</param>
        /// <param name="qConstantImpendance">Portion of reactive power load modeled as constant impedance</param>
        /// <param name="qConstantPower">Portion of reactive power load modeled as constant power</param>
        /// <param name="qFrequencyExponent">Exponent of per unit frequency effecting reactive power</param>
        /// <param name="pFrequencyExponent">Exponent of per unit frequency effecting active power</param>
        public StaticLoadCharacteristic(
            Guid mRid, 
            string name, 
            double pConstantCurrent, 
            double pConstantImpendance, 
            double pConstantPower,
            double qConstantCurrent,
            double qConstantImpendance,
            double qConstantPower,
            double qFrequencyExponent,
            double pFrequencyExponent) : this(mRid, name,qFrequencyExponent,pFrequencyExponent,false)
        {
            #region Checking Input Arguments
            if (pConstantCurrent > 1 || pConstantCurrent < 0)
            {
                throw new ArgumentOutOfRangeException("pConstantCurrent mustn`t be less than 0 or more than 1", nameof(pConstantCurrent));
            }
            if (pConstantImpendance > 1 || pConstantImpendance < 0)
            {
                throw new ArgumentOutOfRangeException("pConstantImpendance mustn`t be less than 0 or more than 1", nameof(pConstantImpendance));
            }
            if (pConstantPower > 1 || pConstantPower < 0)
            {
                throw new ArgumentOutOfRangeException("pConstantPower mustn`t be less than 0 or more than 1", nameof(pConstantPower));
            }
            if (qConstantCurrent > 1 || qConstantCurrent < 0)
            {
                throw new ArgumentOutOfRangeException("qConstantCurrent mustn`t be less than 0 or more than 1", nameof(qConstantCurrent));
            }
            if (qConstantImpendance > 1 || qConstantImpendance < 0)
            {
                throw new ArgumentOutOfRangeException("qConstantImpendance mustn`t be less than 0 or more than 1", nameof(qConstantImpendance));
            }
            if (qConstantPower > 1 || qConstantPower < 0)
            {
                throw new ArgumentOutOfRangeException("qConstantPower mustn`t be less than 0 or more than 1", nameof(qConstantPower));
            }
            if ((pConstantCurrent + pConstantImpendance + pConstantPower) - 1 > 0.005)
            {
                throw new ArgumentException("Sum of coefficients pConstantCurrent, pConstantImpendance and pConstantPower must be equal to 1",nameof(pConstantCurrent));
            }
            if ((qConstantCurrent + qConstantImpendance + qConstantPower) - 1 > 0.005)
            {
                throw new ArgumentException("Sum of coefficients qConstantCurrent, qConstantImpendance and qConstantPower must be equal to 1", nameof(qConstantCurrent));
            }
            #endregion

            this.PConstantCurrent = pConstantCurrent;
            this.PConstantImpendance = pConstantImpendance;
            this.PConstantPower = pConstantPower;
            this.QConstantCurrent    = qConstantCurrent;
            this.QConstantImpendance = qConstantImpendance;
            this.QConstantPower      = qConstantPower;
        }

        public StaticLoadCharacteristic(
           Guid mRid,
           string name,
           double pVoltageExponent,
           double qVoltageExponent,
           double qFrequencyExponent,
           double pFrequencyExponent) : this(mRid, name, qFrequencyExponent, pFrequencyExponent, true)
        {
            #region Checking Input Arguments
            if (pVoltageExponent > 1 || pVoltageExponent < 0)
            {
                throw new ArgumentOutOfRangeException("pVoltageExponent mustn`t be less than 0 or more than 1", nameof(pVoltageExponent));
            }
            if (qVoltageExponent > 1 || qVoltageExponent < 0)
            {
                throw new ArgumentOutOfRangeException("qVoltageExponent mustn`t be less than 0 or more than 1", nameof(qVoltageExponent));
            }
            #endregion

            this.PVoltageExponent = pVoltageExponent;
            this.QVoltageExponent = qVoltageExponent;
        }
    }
}

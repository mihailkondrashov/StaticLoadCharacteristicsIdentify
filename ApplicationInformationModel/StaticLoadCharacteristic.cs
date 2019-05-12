using System;

namespace ApplicationInformationModel
{
    public class StaticLoadCharacteristic : IdentifiedObject
    {
        /// <summary>
        ///  Indicates the exponential voltage dependency model (pVoltateExponent and qVoltageExponent) is to be used
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
                throw new ArgumentNullException("qFrequencyExponent mustn`t be less 0 or more 1", nameof(qFrequencyExponent));
            }
            if (pFrequencyExponent > 1 || pFrequencyExponent < 0)
            {
                throw new ArgumentNullException("pFrequencyExponent mustn`t be less 0 or more 1", nameof(pFrequencyExponent));
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
                throw new ArgumentNullException("pConstantCurrent mustn`t be less 0 or more 1", nameof(pConstantCurrent));
            }
            if (pConstantImpendance > 1 || pConstantImpendance < 0)
            {
                throw new ArgumentNullException("pConstantImpendance mustn`t be less 0 or more 1", nameof(pConstantImpendance));
            }
            if (pConstantPower > 1 || pConstantPower < 0)
            {
                throw new ArgumentNullException("pConstantPower mustn`t be less 0 or more 1", nameof(pConstantPower));
            }
            if (qConstantCurrent > 1 || qConstantCurrent < 0)
            {
                throw new ArgumentNullException("qConstantCurrent mustn`t be less 0 or more 1", nameof(qConstantCurrent));
            }
            if (qConstantImpendance > 1 || qConstantImpendance < 0)
            {
                throw new ArgumentNullException("qConstantImpendance mustn`t be less 0 or more 1", nameof(qConstantImpendance));
            }
            if (qConstantPower > 1 || qConstantPower < 0)
            {
                throw new ArgumentNullException("qConstantPower mustn`t be less 0 or more 1", nameof(qConstantPower));
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
                throw new ArgumentNullException("pVoltageExponent mustn`t be less 0 or more 1", nameof(pVoltageExponent));
            }
            if (qVoltageExponent > 1 || qVoltageExponent < 0)
            {
                throw new ArgumentNullException("qVoltageExponent mustn`t be less 0 or more 1", nameof(qVoltageExponent));
            }
            #endregion

            this.PVoltageExponent = pVoltageExponent;
            this.QVoltageExponent = qVoltageExponent;
        }
    }
}

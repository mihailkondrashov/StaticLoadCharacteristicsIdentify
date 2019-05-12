using System;

namespace ApplicationInformationModel
{
    public class StaticLoadCharacteristic : IdentifiedObject
    {
        /// <summary>
        ///  Indicates the exponential voltage dependency model (pVoltateExponent and qVoltageExponent) is to be used
        /// </summary>
        public bool ExponentModel { get;}

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
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <param name="name"></param>
        public StaticLoadCharacteristic(Guid mRid, string name) : base(mRid, name)
        {
        }
    }
}

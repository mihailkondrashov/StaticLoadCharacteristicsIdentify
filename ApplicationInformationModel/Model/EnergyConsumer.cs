using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationInformationModel.Model
{
    /// <summary>
    /// Generic user of energy - a point of consumption on the power system model
    /// </summary>
    public class EnergyConsumer:IdentifiedObject
    {
        /// <summary>
        /// Number of individual customers represented by this Demand
        /// </summary>
        public int CustomerCount { get; set; }

        /// <summary>
        /// Active power of the load that is a fixed quantity
        /// </summary>
        public double Pfixed { get; set; }

        /// <summary>
        /// Fixed active power as per cent of load group fixed active power
        /// </summary>
        public double PfixedPct { get; set; }

        /// <summary>
        /// Reactive power of the load that is a fixed quantity
        /// </summary>
        public double Qfixed { get; set; }

        /// <summary>
        /// Fixed reactive power as per cent of load group fixed reactive power.
        /// </summary>
        public double QfixedPct { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StaticLoadCharacteristic> StaticLoadCharacteristics { get; set; }

        /// <summary>
        /// Constructor of class EnergyConsumer
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="customerCount">Number of individual customers represented by this Demand</param>
        /// <param name="pfixedPct">Fixed active power as per cent of load group fixed active power</param>
        /// <param name="qfixedPct">Fixed reactive power as per cent of load group fixed reactive power</param>
        public EnergyConsumer(Guid mRid, string name, int customerCount, double pfixedPct, double qfixedPct) : base(mRid, name)
        {
            #region CheckingInputArguments
            if (pfixedPct < 0)
            {
                throw new ArgumentOutOfRangeException("Value of pfixedPct mustn`t be less than 0", nameof(pfixedPct));
            }
            if (qfixedPct < 0)
            {
                throw new ArgumentOutOfRangeException("Value of qfixedPct mustn`t be less than 0", nameof(qfixedPct));
            }
            #endregion
            this.CustomerCount = customerCount;
            this.PfixedPct = pfixedPct;
            this.QfixedPct = qfixedPct;

        }

        /// <summary>
        /// Constructor of class EnergyConsumer
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="pfixed">Active power of the load that is a fixed quantity</param>
        /// <param name="qfixed">Reactive power of the load that is a fixed quantity</param>
        /// <param name="customerCount">Number of individual customers represented by this Demand</param>
        public EnergyConsumer(Guid mRid, string name, double pfixed, double qfixed, int customerCount) : base(mRid, name)
        {
            #region CheckingInputArguments
            if (pfixed < 0)
            {
                throw new ArgumentOutOfRangeException("Value of pfixed mustn`t be less than 0", nameof(pfixed));
            }
            if (qfixed < 0)
            {
                throw new ArgumentOutOfRangeException("Value of qfixed mustn`t be less than 0", nameof(qfixed));
            }
            #endregion

            this.Pfixed = pfixed;
            this.Qfixed = qfixed;
            this.CustomerCount = customerCount;
        }
    }
}
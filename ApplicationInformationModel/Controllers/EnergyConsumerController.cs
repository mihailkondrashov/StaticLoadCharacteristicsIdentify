using System;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class EnergyConsumerController
    {
        /// <summary>
        /// Current object of Class EnergyConsumer
        /// </summary>
        public EnergyConsumer CurrentEnergyConsumer { get; }

        /// <summary>
        /// Create new object of Class EnergyConsumer
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="customerCount">Number of individual customers represented by this Demand</param>
        /// <param name="pfixed">Active power of the load that is a fixed quantity</param>
        /// <param name="qfixed">Reactive power of the load that is a fixed quantity</param>
        /// <param name="pfixedPct">Fixed active power as per cent of load group fixed active power</param>
        /// <param name="qfixedPct">Fixed reactive power as per cent of load group fixed reactive power</param>
        public EnergyConsumerController(Guid mRid, string name, int customerCount, double pfixed, double qfixed, double pfixedPct, double qfixedPct)
        {
            using (var db = new ApplicationsContext())
            {
                CurrentEnergyConsumer = new EnergyConsumer(mRid, name, customerCount, pfixed, qfixed, pfixedPct, qfixedPct);
                db.EnergyConsumers.Add(CurrentEnergyConsumer);
                db.SaveChanges();
            }
        }
    }
}
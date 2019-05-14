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
        /// 
        /// </summary>
        public EnergyConsumer energyConsumer { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="customerCount"></param>
        /// <param name="pfixed"></param>
        /// <param name="qfixed"></param>
        /// <param name="pfixedPct"></param>
        /// <param name="qfixedPct"></param>
        public EnergyConsumerController(string name, int customerCount, double pfixed, double qfixed, double pfixedPct, double qfixedPct)
        {
            using (var db = new ApplicationsContext())
            {
                energyConsumer = new EnergyConsumer(Guid.NewGuid(), name, customerCount, pfixed, qfixed, pfixedPct, qfixedPct);
                db.EnergyConsumers.Add(energyConsumer);
                db.SaveChanges();
            }
        }
    }
}
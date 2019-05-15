using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationInformationModel.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInformationModel.Controllers.Tests
{
    [TestClass()]
    public class EnergyConsumerControllerTests
    {
        [TestMethod()]
        public void EnergyConsumerControllerTest()
        {
            Guid mRid = Guid.NewGuid();
            string name = "EnergyConsumerControllerTest";
            int customerCount = 10;
            double pfixed = 1;
            double qfixed = 1;
            double pfixedPct = 50;
            double qfixedPct = 50;

            var controller = new EnergyConsumerController(mRid,name,customerCount,pfixed,qfixed,pfixedPct,qfixedPct);

            using (var db = new ApplicationsContext())
            {
                var energyConsumer = db.EnergyConsumers.First(e => e.MRID == mRid);
                Assert.AreEqual(energyConsumer.Name,name);
                Assert.AreEqual(energyConsumer.CustomerCount, customerCount);
                Assert.AreEqual(energyConsumer.Pfixed, pfixed);
                Assert.AreEqual(energyConsumer.Qfixed, qfixed);
                Assert.AreEqual(energyConsumer.PfixedPct, pfixedPct);
                Assert.AreEqual(energyConsumer.QfixedPct, qfixedPct);
            }
        }
    }
}
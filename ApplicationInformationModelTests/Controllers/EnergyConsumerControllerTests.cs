using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
            //Act
            var controller = new EnergyConsumerController(mRid, name, customerCount, pfixed, qfixed, pfixedPct, qfixedPct);
            //Assert
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

        [TestMethod()]
        public void GetEnergyConsumerTest()
        {
            Guid mRid = Guid.NewGuid();
            string name = "GetEnergyConsumerTest";
            int customerCount = 10;
            double pfixed = 1;
            double qfixed = 1;
            double pfixedPct = 50;
            double qfixedPct = 50;
            //Act
            var controller = new EnergyConsumerController(mRid, name, customerCount, pfixed, qfixed, pfixedPct, qfixedPct);
            //Assert
            Assert.AreEqual(controller.GetEnergyConsumer(mRid).MRID,mRid);
        }

        [TestMethod()]
        public void GetInvolveStaticLoadCharacteristicsTest()
        {
            Guid staticLoadCharacteristicMRid = Guid.NewGuid();
            Guid energyConsumerMRid = Guid.NewGuid();
            var name = "SetEnergyConsumerTest";
            bool exponentModel = false;
            double pFrequencyExponent = 1;
            double qFrequencyExponent = 1;
            var staticLoadCharacteristicController = new StaticLoadCharacteristicController(staticLoadCharacteristicMRid, name, exponentModel, pFrequencyExponent, qFrequencyExponent);
            var energyConsumerController = new EnergyConsumerController(energyConsumerMRid, "SetEnergyConsumerTest", 1, 0.5, 0.5, 0.5, 0.5);
            //Act
            staticLoadCharacteristicController.SetEnergyConsumer(energyConsumerController.CurrentEnergyConsumer);
            //Assert
            Assert.AreEqual(energyConsumerController.GetInvolveStaticLoadCharacteristics(energyConsumerMRid).First().MRID, staticLoadCharacteristicMRid);
        }

        [TestMethod()]
        public void GetInvolveAnalogsTest()
        {
            Guid staticLoadCharacteristicMRid = Guid.NewGuid();
            Guid energyConsumerMRid = Guid.NewGuid();
            var name = "SetEnergyConsumerTest";
            bool exponentModel = false;
            double pFrequencyExponent = 1;
            double qFrequencyExponent = 1;
            var staticLoadCharacteristicController = new StaticLoadCharacteristicController(staticLoadCharacteristicMRid, name, exponentModel, pFrequencyExponent, qFrequencyExponent);
            var energyConsumerController = new EnergyConsumerController(energyConsumerMRid, "SetEnergyConsumerTest", 1, 0.5, 0.5, 0.5, 0.5);
            //Act
            staticLoadCharacteristicController.SetEnergyConsumer(energyConsumerController.CurrentEnergyConsumer);
            //Assert
            Assert.AreEqual(energyConsumerController.GetInvolveStaticLoadCharacteristics(energyConsumerMRid).First().MRID, staticLoadCharacteristicMRid);
        }
    }
}
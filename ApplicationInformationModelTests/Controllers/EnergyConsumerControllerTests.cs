using System;
using System.Linq;
using ApplicationInformationModel.Controllers;
using ApplicationInformationModel.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationInformationModelTests.Controllers
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
                var energyConsumer = db.EnergyConsumers.First(e => e.Name == name);
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
            Assert.AreEqual(controller.GetEnergyConsumers().FirstOrDefault(e=>e.MRID== controller.CurrentEnergyConsumer.MRID).MRID,mRid);
        }

        [TestMethod()]
        public void GetInvolveStaticLoadCharacteristicsTest()
        {
            Guid staticLoadCharacteristicMRid = Guid.NewGuid();
            Guid energyConsumerMRid = Guid.NewGuid();
            var name = "GetInvolveStaticLoadCharacteristicsTest";
            bool exponentModel = false;
            double pFrequencyExponent = 1;
            double qFrequencyExponent = 1;
            var staticLoadCharacteristicController = new StaticLoadCharacteristicController(staticLoadCharacteristicMRid, name, exponentModel, pFrequencyExponent, qFrequencyExponent);
            var energyConsumerController = new EnergyConsumerController(energyConsumerMRid, "GetInvolveStaticLoadCharacteristicsTest", 1, 0.5, 0.5, 0.5, 0.5);
            //Act
            staticLoadCharacteristicController.SetEnergyConsumer(energyConsumerController.CurrentEnergyConsumer);
            //Assert
            Assert.AreEqual(energyConsumerController.GetInvolveStaticLoadCharacteristics().First().MRID, staticLoadCharacteristicMRid);
        }

        [TestMethod()]
        public void GetInvolveAnalogsTest()
        {
            Guid energyConsumerMRid = Guid.NewGuid();
            Guid analogMrid = Guid.NewGuid();
            string name = "GetInvolveAnalogsTest";
            string measurementTypeName = "Active Power";
            bool positiveFlowIn = false;
            double minValue = 0;
            double maxValue = 200;
            double normalValue = 100;

            var analogController = new MeasurementController(analogMrid, name, measurementTypeName, positiveFlowIn, minValue, maxValue, normalValue);
            var energyConsumerController = new EnergyConsumerController(energyConsumerMRid, "GetInvolveAnalogsTest", 1, 0.5, 0.5, 0.5, 0.5);
            //Act
            analogController.SetEnergyConsumer(energyConsumerController.CurrentEnergyConsumer);
            //Assert
            Assert.AreEqual(energyConsumerController.GetInvolveAnalogs().First().MRID, analogMrid);
        }

        [TestMethod()]
        public void GetSubstationTest()
        {
            Guid mRidSubatation = Guid.NewGuid();
            string nameSubstation = "GetSubstationTest";

            var substation = new SubstationController(mRidSubatation, nameSubstation);

            Guid mRid = Guid.NewGuid();
            string name = "GetSubstationTest";
            int customerCount = 10;
            double pfixed = 1;
            double qfixed = 1;
            double pfixedPct = 50;
            double qfixedPct = 50;
            //Act
            var controller = new EnergyConsumerController(mRid, name, customerCount, pfixed, qfixed, pfixedPct, qfixedPct);
            controller.SetSubstation(substation.CurrentSubstation);
            //Assert
            Assert.AreEqual(mRidSubatation,controller.GetSubstation().MRID);

        }
    }
}
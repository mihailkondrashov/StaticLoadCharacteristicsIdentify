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
    public class StaticLoadCharacteristicControllerTests
    {
        [TestMethod()]
        public void SetNewStaticLoadCharacteristicDataTest()
        {
            //Arrange
            var name = "SetNewStaticLoadCharacteristicDataTest";
            bool exponentModel = false;
            double pFrequencyExponent = 1;
            double qFrequencyExponent = 1;
            double PConstantCurrent = 10;
            double PConstantImpendance = -9;
            double PConstantPower = 0;
            double QConstantCurrent = -10;
            double QConstantImpendance = 8;
            double QConstantPower = 3;
            var staticLoadCharacteristicController = new StaticLoadCharacteristicController(name, exponentModel, pFrequencyExponent, qFrequencyExponent);
            //Act
            staticLoadCharacteristicController.SetNewStaticLoadCharacteristicData(PConstantCurrent, PConstantImpendance, PConstantPower, QConstantCurrent, QConstantImpendance, QConstantPower);
            var list = staticLoadCharacteristicController.GetStaticLoadCharacteristics().First(s => s.Name == name);
            //Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(name,list.Name);
            Assert.AreEqual(pFrequencyExponent,list.PFrequencyExponent);
            Assert.AreEqual(qFrequencyExponent, list.QFrequencyExponent);
            Assert.AreEqual(PConstantCurrent, list.PConstantCurrent);
            Assert.AreEqual(PConstantImpendance, list.PConstantImpendance);
            Assert.AreEqual(PConstantPower, list.PConstantPower);
            Assert.AreEqual(QConstantCurrent, list.QConstantCurrent);
            Assert.AreEqual(QConstantImpendance, list.QConstantImpendance);
            Assert.AreEqual(QConstantPower, list.QConstantPower);
        }

        [TestMethod()]
        public void SetNewStaticLoadCharacteristicDataTest1()
        {
            //Arrange
            var name = "SetNewStaticLoadCharacteristicDataTest1";
            bool exponentModel = true;
            double pFrequencyExponent = 1;
            double qFrequencyExponent = 1;
            double pVoltageExponent = 10;
            double qVoltageExponent = -9;
            var staticLoadCharacteristicController = new StaticLoadCharacteristicController(name, exponentModel, pFrequencyExponent, qFrequencyExponent);
            ////Act
            staticLoadCharacteristicController.SetNewStaticLoadCharacteristicData(pVoltageExponent,qVoltageExponent);
            var list = staticLoadCharacteristicController.GetStaticLoadCharacteristics().First(s => s.Name == name);
            ////Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(name, list.Name);
            Assert.AreEqual(pFrequencyExponent, list.PFrequencyExponent);
            Assert.AreEqual(qFrequencyExponent, list.QFrequencyExponent);
            Assert.AreEqual(pVoltageExponent, list.PVoltageExponent);
            Assert.AreEqual(qVoltageExponent, list.QVoltageExponent);
        }

        [TestMethod()]
        public void SetEnergyConsumerTest()
        {
            //Arrange
            var name = "SetEnergyConsumerTest";
            bool exponentModel = false;
            double pFrequencyExponent = 1;
            double qFrequencyExponent = 1;
            var staticLoadCharacteristicController = new StaticLoadCharacteristicController(name, exponentModel, pFrequencyExponent, qFrequencyExponent);
            var energyConsumerController = new EnergyConsumerController("SetEnergyConsumerTest", 1, 0.5, 0.5, 0.5, 0.5);
            //Act
            staticLoadCharacteristicController.SetEnergyConsumer(energyConsumerController.energyConsumer);
            var list = staticLoadCharacteristicController.GetStaticLoadCharacteristics().First(s => s.Name == name);
            //Assert
            Assert.AreEqual(energyConsumerController.energyConsumer.MRID,list.EnergyConsumer_MRID);
        }
    }
}
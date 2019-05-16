using System;
using System.Linq;
using ApplicationInformationModel.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationInformationModelTests.Controllers
{
    [TestClass()]
    public class MeasurementControllerTests
    {
        [TestMethod()]
        public void GetAnalogTest()
        {
            Guid analogMrid = Guid.NewGuid();
            string name = "GetAnalogTest";
            string measurementTypeName = "Active Power";
            bool positiveFlowIn = false;
            double minValue = 0;
            double maxValue = 200;
            double normalValue = 100;

            var analogController = new MeasurementController(analogMrid,name,measurementTypeName,positiveFlowIn,minValue,maxValue,normalValue);
            var expectedAnalog = analogController.GetAnalogs().FirstOrDefault(a=>a.MRID == analogController.CurrentAnalog.MRID);
            Assert.AreEqual(expectedAnalog.MRID, analogMrid);
            Assert.AreEqual(analogController.GetMeasurementType(expectedAnalog.MeasurementType_ID).Name, measurementTypeName);
            Assert.AreEqual(expectedAnalog.Name, name);
            Assert.AreEqual(expectedAnalog.PositiveFlowIn, positiveFlowIn);
            Assert.AreEqual(expectedAnalog.MinValue, minValue);
            Assert.AreEqual(expectedAnalog.MaxValue, maxValue);
            Assert.AreEqual(expectedAnalog.NormalValue, normalValue);
        }

        [TestMethod()]
        public void GetInvolveAnalogValuesTest()
        {
            Guid analogMrid = Guid.NewGuid();
            string name = "GetInvolveAnalogValuesTest";
            string measurementTypeName = "Reactive Power";
            bool positiveFlowIn = false;
            double minValue = 0;
            double maxValue = 300;
            double normalValue = 200;

            Guid measurementValueMrid = Guid.NewGuid();
            string measurementValue_name = "GetInvolveAnalogValuesTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;

            var analogController = new MeasurementController(analogMrid, name, measurementTypeName, positiveFlowIn, minValue, maxValue, normalValue);
            var measurementValueController = new MeasurementValueController(measurementValueMrid, measurementValue_name, sensor, date, value);
            measurementValueController.SetAnalog(analogController.CurrentAnalog);

            Assert.AreEqual(analogController.GetInvolveAnalogValues().FirstOrDefault(a=>true).MRID, measurementValueController.CurrentAnalogValue.MRID);
        }

        [TestMethod()]
        public void SetEnergyConsumerTest()
        {
            Guid analogMrid = Guid.NewGuid();
            string name = "SetEnergyConsumerTest";
            string measurementTypeName = "Reactive Power";
            bool positiveFlowIn = false;
            double minValue = 0;
            double maxValue = 300;
            double normalValue = 200;

            Guid mRid = Guid.NewGuid();
            string name_energy = "SetEnergyConsumerTest";
            int customerCount = 10;
            double pfixed = 1;
            double qfixed = 1;
            double pfixedPct = 50;
            double qfixedPct = 50;
            //Act
            var controller = new EnergyConsumerController(mRid, name_energy, customerCount, pfixed, qfixed, pfixedPct, qfixedPct);
            var analogController = new MeasurementController(analogMrid, name, measurementTypeName, positiveFlowIn, minValue, maxValue, normalValue);
            analogController.SetEnergyConsumer(controller.CurrentEnergyConsumer);
            Assert.AreEqual(analogController.GetEnergyConsumer().MRID,mRid);
        }
    }
}
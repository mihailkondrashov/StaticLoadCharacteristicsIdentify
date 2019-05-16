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
    public class MeasurementControllerTests
    {
        [TestMethod()]
        public void GetAnalogTest()
        {
            Guid analog_MRID = Guid.NewGuid();
            string name = "GetAnalogTest";
            string measurementTypeName = "Active Power";
            bool positiveFlowIn = false;
            double minValue = 0;
            double maxValue = 200;
            double normalValue = 100;

            var analogController = new MeasurementController(analog_MRID,name,measurementTypeName,positiveFlowIn,minValue,maxValue,normalValue);
            var expectedAnalog = analogController.GetAnalog(analog_MRID);
            Assert.AreEqual(expectedAnalog.MRID, analog_MRID);
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
            Guid analog_MRID = Guid.NewGuid();
            string name = "GetInvolveAnalogValuesTest";
            string measurementTypeName = "Reactive Power";
            bool positiveFlowIn = false;
            double minValue = 0;
            double maxValue = 300;
            double normalValue = 200;//TODO:добавить проверку на min<=norm<=max

            Guid measurementValue_MRID = Guid.NewGuid();
            string measurementValue_name = "GetInvolveAnalogValuesTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;

            var analogController = new MeasurementController(analog_MRID, name, measurementTypeName, positiveFlowIn, minValue, maxValue, normalValue);
            var measurementValueController = new MeasurementValueController(measurementValue_MRID, measurementValue_name, sensor, date, value);
            measurementValueController.SetAnalog(analogController.CurrentAnalog);

            Assert.AreEqual(analogController.GetInvolveAnalogValues(analog_MRID).FirstOrDefault(a=>true).MRID, measurementValueController.CurrentAnalogValue.MRID);
        }

        [TestMethod()]
        public void GetEnergyConsumerTest()
        {
            Assert.Fail();
        }
    }
}
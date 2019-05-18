using System;
using System.Linq;
using ApplicationInformationModel.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationInformationModelTests.Controllers
{
    [TestClass()]
    public class MeasurementValueSourceControllerTests
    {
        [TestMethod()]
        public void GetInvolveAnalogValuesTest()
        {
            Guid measurementValueSourceMrid = Guid.NewGuid();
            string measurementValueSource_name = "GetInvolveAnalogValuesTest";

            Guid measurementValueMrid = Guid.NewGuid();
            string measurementValue_name = "GetInvolveAnalogValuesTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;

            Guid measurementValueMrid1 = Guid.NewGuid();

            var measurementValueSourceController = new MeasurementValueSourceController(measurementValueSourceMrid, measurementValueSource_name);

            var measurementValueController = new MeasurementValueController(measurementValueMrid, measurementValue_name, sensor, date, value);
            measurementValueController.SetMeasurementValueSource(measurementValueSourceController.CurrentMeasurementValueSource);
            measurementValueController = new MeasurementValueController(measurementValueMrid1, measurementValue_name, sensor, date, value);
            measurementValueController.SetMeasurementValueSource(measurementValueSourceController.CurrentMeasurementValueSource);

            Assert.AreEqual(measurementValueSourceController.GetInvolveAnalogValues().First(a=>a.MRID== measurementValueMrid).MRID, measurementValueMrid);
            Assert.AreEqual(measurementValueSourceController.GetInvolveAnalogValues().First(a => a.MRID == measurementValueMrid1).MRID, measurementValueMrid1);
        }
    }
}
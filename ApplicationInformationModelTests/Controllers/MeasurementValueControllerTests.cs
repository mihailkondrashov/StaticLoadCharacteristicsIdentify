using System;
using ApplicationInformationModel.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationInformationModelTests.Controllers
{
    [TestClass()]
    public class MeasurementValueControllerTests
    {

        [TestMethod()]
        public void SetMeasurementValueSourceTest()
        {
            Guid measurementValueSourceMrid = Guid.NewGuid();
            string measurementValueSource_name = "SetMeasurementValueSourceTest";

            Guid measurementValueMrid = Guid.NewGuid();
            string measurementValue_name = "SetMeasurementValueSourceTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;

            var measurementValueSourcecontroller = new MeasurementValueSourceController(measurementValueSourceMrid,measurementValueSource_name);
            var measurementValueController = new MeasurementValueController(measurementValueMrid,measurementValue_name,sensor,date,value);
            measurementValueController.SetMeasurementValueSource(measurementValueSourcecontroller.CurrentMeasurementValueSource);
            
            Assert.AreEqual(measurementValueSourcecontroller.CurrentMeasurementValueSource.MRID, measurementValueController.GetMeasurementValueSource().MRID);
            Assert.AreEqual(measurementValueController.CurrentAnalogValue.MRID, measurementValueMrid);
            Assert.AreEqual(measurementValueController.CurrentAnalogValue.Name, measurementValue_name);
            Assert.AreEqual(measurementValueController.CurrentAnalogValue.SensorAccuracy, sensor);
            Assert.AreEqual(measurementValueController.CurrentAnalogValue.TimeStamp, date);
            Assert.AreEqual(measurementValueController.CurrentAnalogValue.Value, value);
            measurementValueController.Delete();
            measurementValueSourcecontroller.Delete();
        }

        [TestMethod()]
        public void SetAnalogTest()
        {
            Guid analogMrid = Guid.NewGuid();
            string analog_name = "SetAnalogTest";
            string measurementTypeName = "Active Power";
            bool positiveFlowIn = false;
            double minValue = 0;
            double maxValue = 200;
            double normalValue = 100;

            Guid measurementValueMrid = Guid.NewGuid();
            string measurementValue_name = "SetAnalogTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;

            var analogController = new MeasurementController(analogMrid, analog_name,measurementTypeName,positiveFlowIn,minValue,maxValue,normalValue);
            var measurementValueController = new MeasurementValueController(measurementValueMrid, measurementValue_name, sensor, date, value);
            measurementValueController.SetAnalog(analogController.CurrentAnalog);

            Assert.AreEqual(analogController.CurrentAnalog.MRID, measurementValueController.GetAnalog().MRID);

            measurementValueController.Delete();
            analogController.Delete();
        }
    }
}
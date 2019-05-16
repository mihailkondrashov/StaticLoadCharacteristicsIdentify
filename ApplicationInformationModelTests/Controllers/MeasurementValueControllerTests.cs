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
    public class MeasurementValueControllerTests
    {

        [TestMethod()]
        public void SetMeasurementValueSourceTest()
        {
            Guid measurementValueSource_MRID = Guid.NewGuid();
            string measurementValueSource_name = "SetMeasurementValueSourceTest";

            Guid measurementValue_MRID = Guid.NewGuid();
            string measurementValue_name = "SetMeasurementValueSourceTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;

            var measurementValueSourcecontroller = new MeasurementValueSourceController(measurementValueSource_MRID,measurementValueSource_name);
            var measurementValueController = new MeasurementValueController(measurementValue_MRID,measurementValue_name,sensor,date,value);
            measurementValueController.SetMeasurementValueSource(measurementValueSourcecontroller.CurrentMeasurementValueSource);
            
            Assert.AreEqual(measurementValueSourcecontroller.CurrentMeasurementValueSource.MRID, measurementValueController.GetMeasurementValueSource(measurementValueController.CurrentAnalogValue.MRID).MRID);
            Assert.AreEqual(measurementValueController.CurrentAnalogValue.MRID, measurementValue_MRID);
            Assert.AreEqual(measurementValueController.CurrentAnalogValue.Name, measurementValue_name);
            Assert.AreEqual(measurementValueController.CurrentAnalogValue.SensorAccuracy, sensor);
            Assert.AreEqual(measurementValueController.CurrentAnalogValue.TimeStamp, date);
            Assert.AreEqual(measurementValueController.CurrentAnalogValue.Value, value);

        }

        [TestMethod()]
        public void SetAnalogTest()
        {
            Guid analog_MRID = Guid.NewGuid();
            string analog_name = "SetAnalogTest";
            string measurementTypeName = "Active Power";
            bool positiveFlowIn = false;
            double minValue = 0;
            double maxValue = 200;
            double normalValue = 100;

            Guid measurementValue_MRID = Guid.NewGuid();
            string measurementValue_name = "SetAnalogTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;

            var analogController = new MeasurementController(analog_MRID, analog_name,measurementTypeName,positiveFlowIn,minValue,maxValue,normalValue);
            var measurementValueController = new MeasurementValueController(measurementValue_MRID, measurementValue_name, sensor, date, value);
            measurementValueController.SetAnalog(analogController.CurrentAnalog);

            Assert.AreEqual(analogController.CurrentAnalog.MRID, measurementValueController.GetAnalog(measurementValueController.CurrentAnalogValue.MRID).MRID);
        }
    }
}
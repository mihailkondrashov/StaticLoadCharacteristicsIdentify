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
    public class DeskretizationValueControllerTests
    {

        [TestMethod()]
        public void GetDeskretizationValuesTest()
        {
            Guid deskretizationValueMrid = Guid.NewGuid();
            string measurementValue_name = "GetDeskretizationValuesTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;

            var deskretizationValue = new DeskretizationValueController(deskretizationValueMrid,measurementValue_name,sensor,date, value,1);

            var deskretizationValues = deskretizationValue.GetDeskretizationValues().FirstOrDefault(d=>d.MRID==deskretizationValueMrid);

            Assert.AreEqual(deskretizationValues.MRID,deskretizationValueMrid);
            Assert.AreEqual(deskretizationValues.Name, measurementValue_name);
        }

        [TestMethod()]
        public void SetMeasurementValueSourceTest()
        {
            Guid deskretizationValueMrid = Guid.NewGuid();
            string measurementValue_name = "SetMeasurementValueSourceTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;
            var deskretizationValue = new DeskretizationValueController(deskretizationValueMrid, measurementValue_name, sensor, date, value, 1);

            Guid measurementValueSourceMrid = Guid.NewGuid();
            string measurementValueSource_name = "SetMeasurementValueSourceTest";
            var measurementValueSourceController = new MeasurementValueSourceController(measurementValueSourceMrid, measurementValueSource_name);

            deskretizationValue.SetMeasurementValueSource(measurementValueSourceController.CurrentMeasurementValueSource);

            var deskretizationValues = deskretizationValue.GetDeskretizationValues().FirstOrDefault(d => d.MRID == deskretizationValueMrid);

            Assert.AreEqual(deskretizationValues.MRID, deskretizationValueMrid);
            Assert.AreEqual(deskretizationValues.MeasurementValueSource_MRID, measurementValueSourceMrid);

        }

        [TestMethod()]
        public void SetAnalogTest()
        {
            Guid deskretizationValueMrid = Guid.NewGuid();
            string measurementValue_name = "SetAnalogTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;
            var deskretizationValue = new DeskretizationValueController(deskretizationValueMrid, measurementValue_name, sensor, date, value, 1);

            Guid analogMrid = Guid.NewGuid();
            string name = "SetAnalogTest";
            string measurementTypeName = "Active Power";
            bool positiveFlowIn = false;
            double minValue = 0;
            double maxValue = 200;
            double normalValue = 100;

            var analogController = new MeasurementController(analogMrid, name, measurementTypeName, positiveFlowIn, minValue, maxValue, normalValue);

            deskretizationValue.SetAnalog(analogController.CurrentAnalog);

            var deskretizationValues = deskretizationValue.GetDeskretizationValues().FirstOrDefault(d => d.MRID == deskretizationValueMrid);

            Assert.AreEqual(deskretizationValues.MRID, deskretizationValueMrid);
            Assert.AreEqual(deskretizationValues.Analog_MRID, analogMrid);
        }
    }
}
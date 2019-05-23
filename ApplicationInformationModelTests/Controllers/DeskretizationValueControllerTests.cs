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

            var deskretizationValue = new DeskretizationValueController();


            Assert.Fail();
        }

        [TestMethod()]
        public void SetMeasurementValueSourceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetAnalogTest()
        {
            Assert.Fail();
        }
    }
}
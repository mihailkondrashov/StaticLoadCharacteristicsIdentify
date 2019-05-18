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
    public class SubstationControllerTests
    {
        [TestMethod()]
        public void GetSubstationsTest()
        {
            Guid mRid = Guid.NewGuid();
            string name = "GetSubstationsTest";

            var substation = new SubstationController(mRid,name);

            Assert.AreEqual(mRid, substation.GetSubstations()[0].MRID); 
        }
    }
}
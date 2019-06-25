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
            var mRid = Guid.NewGuid();
            const string name = "GetSubstationsTest";

            var substation = new SubstationController(mRid,name);

            Assert.AreEqual(mRid, substation.GetSubstations().FirstOrDefault(s=>s.MRID==mRid)?.MRID);

            substation.Delete();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    public class SubstationController
    {
        /// <summary>
        /// 
        /// </summary>
        public Substation CurrentSubstation { get; }

        /// <summary>
        /// 
        /// </summary>
        public SubstationController() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <param name="name"></param>
        public SubstationController(Guid mRid, string name)
        {
            using (var db = new ApplicationsContext())
            {
                CurrentSubstation = new Substation(mRid, name);
                db.Substations.Add(CurrentSubstation);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Substation> GetSubstations()
        {
            using (var db = new ApplicationsContext())
            {
                return db.Substations.Where(x => true).ToList();
            }
        }
    }
}
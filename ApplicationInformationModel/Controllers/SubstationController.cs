using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        /// <param name="substation"></param>
        public SubstationController(Substation substation)
        {
            CurrentSubstation = substation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <param name="name"></param>
        public SubstationController(Guid mRid, string name)
        {
            using (var db = new ApplicationsContext())
            {
                CurrentSubstation = GetSubstations().FirstOrDefault(vs => vs.Name == name) ??
                                                new Substation(mRid, name);

                db.Substations.AddOrUpdate(CurrentSubstation);
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<EnergyConsumer> GetInvolveEnergyConsumers()
        {
            using (var db = new ApplicationsContext())
            {
                return db.EnergyConsumers.Where(e => e.Substation_MRID == CurrentSubstation.MRID).ToList();
            }
        }

        /// <summary>
        /// Deleting current object Substation
        /// </summary>
        /// <exception cref="ObjectHasReferenceException"/>
        public void Delete()
        {
            using (var db = new ApplicationsContext())
            {
                db.Substations.Attach(CurrentSubstation);
                db.Substations.Remove(CurrentSubstation);
                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    throw new ObjectHasReferenceException($"{this}. The DELETE statement conflicted with the REFERENCE constraint");
                }
            }
        }
    }
}
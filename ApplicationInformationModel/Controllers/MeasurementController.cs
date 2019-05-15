using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    public class MeasurementController
    {
        /// <summary>
        /// 
        /// </summary>
        public Analog CurrentAnalog { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <param name="name"></param>
        /// <param name="measurementTypeName"></param>
        /// <param name="positiveFlowIn"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="normalValue"></param>
        public MeasurementController(Guid mRid, string name, string measurementTypeName, bool positiveFlowIn, double minValue, double maxValue, double normalValue)
        {
            using (var db = new ApplicationsContext())
            {
                var measurementType = db.MeasurementTypes.FirstOrDefault(t => t.Name == measurementTypeName) ?? new MeasurementType(measurementTypeName);
                CurrentAnalog = new Analog(mRid, name, measurementType, positiveFlowIn, minValue, maxValue,normalValue);
                db.Analogs.Add(CurrentAnalog);
                db.SaveChanges();
            }
        }

        public MeasurementType GetMeasurementType(int Id)
        {
            using (var db = new ApplicationsContext())
            {
                return db.MeasurementTypes.FirstOrDefault(t => t.Id == Id);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Analog GetAnalog(Guid mRID)
        {
            using (var db = new ApplicationsContext())
            {
                return db.Analogs.FirstOrDefault(e => e.MRID == mRID) ?? null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Analog> GetAnalogs()
        {
            using (var db = new ApplicationsContext())
            {
                return db.Analogs.Where(e => true).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <returns></returns>
        public List<AnalogValue> GetInvolveAnalogValues(Guid mRid)
        {
            using (var db = new ApplicationsContext())
            {
                return db.Analogs.FirstOrDefault(a => a.MRID == mRid).AnalogValues.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="energyConsumer"></param>
        public void GetEnergyConsumer(EnergyConsumer energyConsumer)
        {
            CurrentAnalog.SetEnergyConsumer(energyConsumer);
            Update();
        }

        /// <summary>
        /// Update current object of class CurrentAnalog
        /// </summary>
        public void Update()
        {
            using (ApplicationsContext db = new ApplicationsContext())
            {
                db.Analogs.AddOrUpdate(CurrentAnalog);
                db.SaveChanges();
            }
        }
    }
}
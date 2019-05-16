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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MeasurementType GetMeasurementType(int id)
        {
            using (var db = new ApplicationsContext())
            {
                return db.MeasurementTypes.FirstOrDefault(t => t.Id == id);
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
        /// <returns></returns>
        public List<AnalogValue> GetInvolveAnalogValues()
        {
            using (var db = new ApplicationsContext())
            {
                return db.AnalogValues.Where(a => a.Analog_MRID == CurrentAnalog.MRID).ToList();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="energyConsumer"></param>
        public void SetEnergyConsumer(EnergyConsumer energyConsumer)
        {
            CurrentAnalog.SetEnergyConsumer(energyConsumer);
            Update();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EnergyConsumer GetEnergyConsumer()
        {
            using (ApplicationsContext db = new ApplicationsContext())
            {
                return db.EnergyConsumers.FirstOrDefault(e => e.MRID == db.Analogs.FirstOrDefault(a => a.MRID == CurrentAnalog.MRID).EnergyConsumer_MRID);
            }
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
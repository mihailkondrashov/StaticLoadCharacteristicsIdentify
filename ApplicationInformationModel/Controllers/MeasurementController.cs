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
        /// Current object of class Analog
        /// </summary>
        public Analog CurrentAnalog { get; }

        /// <summary>
        /// Create new object of class Analog
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="measurementTypeName">Specifies the type of Measurement, e.g. IndoorTemperature, OutDoorTemperature, BusVoltage, GeneratorVoltage, LineFlow etc</param>
        /// <param name="positiveFlowIn">If true then this measurement is an active power, reactive power or current with the convention that a positive value measured at the Terminal means power is flowing into the related PowerSystemResource</param>
        /// <param name="minValue">Normal value range minimum for any of the MeasurementValue.values</param>
        /// <param name="maxValue">Normal value range maximum for any of the MeasurementValue.values</param>
        /// <param name="normalValue">Normal measurement value, e.g., used for percentage calculations</param>
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
        /// Getting object of class MeasurementType
        /// </summary>
        /// <param name="id">Identificator</param>
        /// <returns></returns>
        public MeasurementType GetMeasurementType(int id)
        {
            using (var db = new ApplicationsContext())
            {
                return db.MeasurementTypes.FirstOrDefault(t => t.Id == id);
            }
        }

        /// <summary>
        /// Getting objects of class Analog
        /// </summary>
        /// <returns>List of objects of class Analog</returns>
        public List<Analog> GetAnalogs()
        {
            using (var db = new ApplicationsContext())
            {
                return db.Analogs.Where(e => true).ToList();
            }
        }

        /// <summary>
        /// Getting list of involve objects of class AnalogValue 
        /// </summary>
        /// <returns>list of involve objects of class AnalogValue</returns>
        public List<AnalogValue> GetInvolveAnalogValues()
        {
            using (var db = new ApplicationsContext())
            {
                return db.AnalogValues.Where(a => a.Analog_MRID == CurrentAnalog.MRID).ToList();
            }
        }

        /// <summary>
        /// Setting object of class of EnergyConsumer
        /// </summary>
        /// <param name="energyConsumer">object of class of EnergyConsumer</param>
        public void SetEnergyConsumer(EnergyConsumer energyConsumer)
        {
            CurrentAnalog.SetEnergyConsumer(energyConsumer);
            Update();
        }

        /// <summary>
        ///  Getting objects of class EnergyConsumer
        /// </summary>
        /// <returns>objects of class EnergyConsumer</returns>
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
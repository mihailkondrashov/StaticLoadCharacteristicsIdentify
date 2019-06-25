using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    public class MeasurementValueController
    {
        /// <summary>
        /// Current object of class AnalogValue
        /// </summary>
        public AnalogValue CurrentAnalogValue { get; }

        /// <summary>
        /// Defaults constructor
        /// </summary>
        public MeasurementValueController() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="analogValue"></param>
        public MeasurementValueController(AnalogValue analogValue)
        {
            CurrentAnalogValue = analogValue;
        }


        /// <summary>
        /// Create new object of AnalogValue
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRID</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="sensorAccuracy">The limit, expressed as a percentage of the sensor maximum, that errors will not exceed when the sensor is used under reference conditions</param>
        /// <param name="timeStamp">The time when the value was last updated</param>
        /// <param name="value">The value to supervise</param>
        public MeasurementValueController(Guid mRid, string name, double sensorAccuracy, DateTime timeStamp, double value)
        {
            CurrentAnalogValue = new AnalogValue(mRid, name, sensorAccuracy, timeStamp, value);
            using (var db = new ApplicationsContext())
            {
                db.AnalogValues.Add(CurrentAnalogValue);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Getting list of objects of class AnalogValue
        /// </summary>
        /// <returns>List of objects of class AnalogValue</returns>
        public List<AnalogValue> GetMeasurementValues()
        {
            using (var db = new ApplicationsContext())
            {
                return db.AnalogValues.Where(a => true).ToList();
            }
        }

        /// <summary>
        /// Setting object of class measurementValueSource
        /// </summary>
        /// <param name="measurementValueSource">Object of class measurementValueSource</param>
        public void SetMeasurementValueSource(MeasurementValueSource measurementValueSource)
        {
            using (var db = new ApplicationsContext())
            {
                CurrentAnalogValue.MeasurementValueSource = measurementValueSource;
                CurrentAnalogValue.MeasurementValueSource_MRID = measurementValueSource.MRID;
                db.AnalogValues.AddOrUpdate(CurrentAnalogValue);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Getting Object of class measurementValueSource
        /// </summary>
        /// <returns>Object of class measurementValueSource</returns>
        public MeasurementValueSource GetMeasurementValueSource()
        {
            using (var db = new ApplicationsContext())
            {
                return db.MeasurementValueSources.FirstOrDefault(ms => ms.MRID == db.AnalogValues.FirstOrDefault(a => a.MRID == CurrentAnalogValue.MRID).MeasurementValueSource_MRID);
            }
        }

        /// <summary>
        /// Setting object of class Analog
        /// </summary>
        /// <param name="analog">Object of class Analog</param>
        public void SetAnalog(Analog analog)
        {
            using (var db = new ApplicationsContext())
            {
                CurrentAnalogValue.Analog = analog;
                CurrentAnalogValue.Analog_MRID = analog.MRID;
                db.AnalogValues.AddOrUpdate(CurrentAnalogValue);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Getting object of class Analog
        /// </summary>
        /// <returns>Object of class Analog</returns>
        public Analog GetAnalog()
        {
            using (var db = new ApplicationsContext())
            {
                return db.Analogs.FirstOrDefault(ms => ms.MRID == db.AnalogValues.FirstOrDefault(a => a.MRID == CurrentAnalogValue.MRID).Analog_MRID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ObjectHasReferenceException"/>
        public void Delete()
        {
            using (var db = new ApplicationsContext())
            {
                db.AnalogValues.Attach(CurrentAnalogValue);
                db.AnalogValues.Remove(CurrentAnalogValue);
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
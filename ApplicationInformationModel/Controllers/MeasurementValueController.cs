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
        /// 
        /// </summary>
        public AnalogValue CurrentAnalogValue { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <param name="name"></param>
        /// <param name="sensorAccuracy"></param>
        /// <param name="timeStamp"></param>
        /// <param name="value"></param>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AnalogValue> GetMeasurementValues()
        {
            using (var db = new ApplicationsContext())
            {
                return db.AnalogValues.Where(a => true).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measurementValueSource"></param>
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
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <returns></returns>
        public MeasurementValueSource GetMeasurementValueSource( Guid mRid)
        {
            using (var db = new ApplicationsContext())
            {
                return db.MeasurementValueSources.FirstOrDefault(ms => ms.MRID == db.AnalogValues.FirstOrDefault(a => a.MRID == mRid).MeasurementValueSource_MRID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="analog"></param>
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
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <returns></returns>
        public Analog GetAnalog(Guid mRid)
        {
            using (var db = new ApplicationsContext())
            {
                return db.Analogs.FirstOrDefault(ms => ms.MRID == db.AnalogValues.FirstOrDefault(a => a.MRID == mRid).Analog_MRID);
            }
        }
    }
}
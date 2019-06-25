using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    public class DeskretizationValueController
    {
        /// <summary>
        /// 
        /// </summary>
        public DeskretizationValue CurrentDeskretizationValue { get; }

        /// <summary>
        /// 
        /// </summary>
        public DeskretizationValueController() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deskretizationValue"></param>
        public DeskretizationValueController(DeskretizationValue deskretizationValue)
        {
            CurrentDeskretizationValue = deskretizationValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <param name="name"></param>
        /// <param name="sensorAccuracy"></param>
        /// <param name="timeStamp"></param>
        /// <param name="value"></param>
        /// <param name="flag"></param>
        public DeskretizationValueController(Guid mRid, string name, double sensorAccuracy, DateTime timeStamp, double value, int flag)
        {
            CurrentDeskretizationValue = new DeskretizationValue(mRid, name, sensorAccuracy, timeStamp,value, flag);

            using (var db = new ApplicationsContext())
            {
                db.DeskretizationValues.Add(CurrentDeskretizationValue);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DeskretizationValue> GetDeskretizationValues()
        {
            using (var db = new ApplicationsContext())
            {
                return db.DeskretizationValues.Where(d => true).ToList();
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
                CurrentDeskretizationValue.MeasurementValueSource = measurementValueSource;
                CurrentDeskretizationValue.MeasurementValueSource_MRID = measurementValueSource.MRID;
                db.DeskretizationValues.AddOrUpdate(CurrentDeskretizationValue);
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
                return db.MeasurementValueSources.FirstOrDefault(ms => ms.MRID == db.DeskretizationValues.FirstOrDefault(a => a.MRID == CurrentDeskretizationValue.MRID).MeasurementValueSource_MRID);
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
                CurrentDeskretizationValue.Analog = analog;
                CurrentDeskretizationValue.Analog_MRID = analog.MRID;
                db.DeskretizationValues.AddOrUpdate(CurrentDeskretizationValue);
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
                return db.Analogs.FirstOrDefault(ms => ms.MRID == db.DeskretizationValues.FirstOrDefault(a => a.MRID == CurrentDeskretizationValue.MRID).Analog_MRID);
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
                db.DeskretizationValues.Attach(CurrentDeskretizationValue);
                db.DeskretizationValues.Remove(CurrentDeskretizationValue);
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
using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    public class MeasurementValueSourceController
    {
        /// <summary>
        /// 
        /// </summary>
        public MeasurementValueSource CurrentMeasurementValueSource { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <param name="name"></param>
        public MeasurementValueSourceController(Guid mRid, string name)
        {
            CurrentMeasurementValueSource = new MeasurementValueSource(mRid,name);

            using (var db = new ApplicationsContext())
            {
                db.MeasurementValueSources.Add(CurrentMeasurementValueSource);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MeasurementValueSource> GetMeasurementValueSources()
        {
            using (var db = new ApplicationsContext())
            {
                return db.MeasurementValueSources.Where(ms => true).ToList();
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
                return db.MeasurementValueSources.FirstOrDefault(a => a.MRID == CurrentMeasurementValueSource.MRID).AnalogValues.ToList();
            }
        }
    }
}
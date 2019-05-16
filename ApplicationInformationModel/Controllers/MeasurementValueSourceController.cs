using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    /// <summary>
    /// Controller of class MeasurementValueSource
    /// </summary>
    public class MeasurementValueSourceController
    {
        /// <summary>
        /// Current object of class MeasurementValueSource
        /// </summary>
        public MeasurementValueSource CurrentMeasurementValueSource { get; }

        /// <summary>
        /// Create new object of class MeasurementValueSource
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
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
        /// Getting list of objects 0f class MeasurementValueSource
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
        /// Getting list of involve objects of class AnalogValue
        /// </summary>
        /// <returns>list of involve objects of class AnalogValue</returns>
        public List<AnalogValue> GetInvolveAnalogValues()
        {
            using (var db = new ApplicationsContext())
            {
                return db.MeasurementValueSources.FirstOrDefault(a => a.MRID == CurrentMeasurementValueSource.MRID).AnalogValues.ToList();
            }
        }
    }
}
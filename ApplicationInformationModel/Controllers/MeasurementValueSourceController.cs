using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    public class MeasurementValueSourceController
    {
        public MeasurementValueSource CurrentMeasurementValueSource { get; }

        public MeasurementValueSourceController(Guid mRid, string name)
        {
            CurrentMeasurementValueSource = new MeasurementValueSource(mRid,name);

            using (var db = new ApplicationsContext())
            {
                db.MeasurementValueSources.Add(CurrentMeasurementValueSource);
                db.SaveChanges();
            }
        }

        public List<AnalogValue> GetInvolveAnalogValues(Guid mRid)
        {
            using (var db = new ApplicationsContext())
            {
                return db.MeasurementValueSources.FirstOrDefault(a => a.MRID == mRid).AnalogValues.ToList();
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace ApplicationInformationModel.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class DeskretizationValue:AnalogValue
    {
        /// <summary>
        /// 
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// No parametrless constructor of class MeasurementValue
        /// </summary>
        public DeskretizationValue() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <param name="name"></param>
        /// <param name="sensorAccuracy"></param>
        /// <param name="timeStamp"></param>
        /// <param name="flag"></param>
        public DeskretizationValue(Guid mRid, string name, double sensorAccuracy, DateTime timeStamp, double value ,int flag):base (mRid, name, sensorAccuracy, timeStamp,value)
        {
            Flag = flag;
        }
    }
}
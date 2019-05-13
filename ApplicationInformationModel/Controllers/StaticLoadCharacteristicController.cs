using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    public class StaticLoadCharacteristicController
    {
        /// <summary>
        /// 
        /// </summary>
        private StaticLoadCharacteristic staticLoadCharacteristic { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="exponentModel"></param>
        /// <param name="pFrequencyExponent"></param>
        /// <param name="qFrequencyExponent"></param>
        public StaticLoadCharacteristicController(string name, bool exponentModel, double pFrequencyExponent, double qFrequencyExponent)
        {
            using (ApplicationsContext db = new ApplicationsContext())
            {
                staticLoadCharacteristic = new StaticLoadCharacteristic(Guid.NewGuid(), name, qFrequencyExponent, pFrequencyExponent, exponentModel);
                db.StaticLoadCharacteristics.Add(staticLoadCharacteristic);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConstantCurrent"></param>
        /// <param name="pConstantImpendance"></param>
        /// <param name="pConstantPower"></param>
        /// <param name="qConstantCurrent"></param>
        /// <param name="qConstantImpendance"></param>
        /// <param name="qConstantPower"></param>
        public void SetNewStaticLoadCharacteristicData(double pConstantCurrent, double pConstantImpendance, double pConstantPower, double qConstantCurrent, double qConstantImpendance, double qConstantPower)
        {
            if (staticLoadCharacteristic.ExponentModel)
            {
                throw new Exception("This object of class StaticLoadCharacteristic has exponential voltage dependency model (pVoltateExponent and qVoltageExponent)");
            }
            staticLoadCharacteristic.SetNewStaticLoadCharacteristicData(pConstantCurrent, pConstantImpendance, pConstantPower, qConstantCurrent, qConstantImpendance, qConstantPower);
            Update();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pVoltageExponent"></param>
        /// <param name="qVoltageExponent"></param>
        public void SetNewStaticLoadCharacteristicData(double pVoltageExponent, double qVoltageExponent)
        {
            if (!staticLoadCharacteristic.ExponentModel)
            {
                throw new Exception("This object of class StaticLoadCharacteristic hasn`t exponential voltage dependency model (pVoltateExponent and qVoltageExponent)");
            }
            staticLoadCharacteristic.SetNewStaticLoadCharacteristicData(pVoltageExponent, qVoltageExponent);
            Update();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="energyConsumer"></param>
        public void SetEnergyConsumer(EnergyConsumer energyConsumer)
        {
            staticLoadCharacteristic.SetEnergyConsumer(energyConsumer);
            Update();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Update()
        {
            using (ApplicationsContext db = new ApplicationsContext())
            {
                db.StaticLoadCharacteristics.Attach(staticLoadCharacteristic);
                db.StaticLoadCharacteristics.Remove(staticLoadCharacteristic);
                db.SaveChanges();
                db.StaticLoadCharacteristics.Add(staticLoadCharacteristic);
                db.SaveChanges();
            }
        }

    }
}
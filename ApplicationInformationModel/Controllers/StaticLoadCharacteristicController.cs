using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    public class StaticLoadCharacteristicController
    {
        /// <summary>
        /// Currents object of class StaticLoadCharacteristic
        /// </summary>
        private StaticLoadCharacteristic CurrentStaticLoadCharacteristic { get; }

        /// <summary>
        /// Defalts constructor
        /// </summary>
        public StaticLoadCharacteristicController() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staticLoadCharacteristic"></param>
        public StaticLoadCharacteristicController(StaticLoadCharacteristic staticLoadCharacteristic)
        {
            CurrentStaticLoadCharacteristic = staticLoadCharacteristic;
        }

        /// <summary>
        /// Create new object of class StaticLoadCharacteristic
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        /// <param name="exponentModel">Indicates the exponential voltage dependency model (pVoltateExponent and qVoltageExponent) is to be used</param>
        /// <param name="pFrequencyExponent">Exponent of per unit frequency effecting active power</param>
        /// <param name="qFrequencyExponent">Exponent of per unit frequency effecting reactive power</param>
        public StaticLoadCharacteristicController(Guid mRid, string name, bool exponentModel, double pFrequencyExponent, double qFrequencyExponent)
        {
            using (ApplicationsContext db = new ApplicationsContext())
            {
                CurrentStaticLoadCharacteristic = db.StaticLoadCharacteristics.FirstOrDefault(s=>s.Name==name) ?? new StaticLoadCharacteristic(mRid, name, qFrequencyExponent, pFrequencyExponent, exponentModel);
                db.StaticLoadCharacteristics.AddOrUpdate(CurrentStaticLoadCharacteristic);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Add additionals attribuities pConstantCurrent, pConstantImpendance, pConstantPower, qConstantCurrent, qConstantImpendance and qConstantPower
        /// </summary>
        /// <param name="pConstantCurrent">Portion of active power load modeled as constant current</param>
        /// <param name="pConstantImpendance">Portion of active power load modeled as constant impedance</param>
        /// <param name="pConstantPower">Portion of active power load modeled as constant power</param>
        /// <param name="qConstantCurrent">Portion of reactive power load modeled as constant current</param>
        /// <param name="qConstantImpendance">Portion of reactive power load modeled as constant impedance</param>
        /// <param name="qConstantPower">Portion of reactive power load modeled as constant power</param>
        public void SetNewStaticLoadCharacteristicData(double pConstantCurrent, double pConstantImpendance, double pConstantPower, double qConstantCurrent, double qConstantImpendance, double qConstantPower)
        {
            #region Checking attribut of ExponentModel
            if (CurrentStaticLoadCharacteristic.ExponentModel)
            {
                throw new Exception("This object of class StaticLoadCharacteristic has exponential voltage dependency model (pVoltateExponent and qVoltageExponent)");
            }
            #endregion
            CurrentStaticLoadCharacteristic.SetNewStaticLoadCharacteristicData(pConstantCurrent, pConstantImpendance, pConstantPower, qConstantCurrent, qConstantImpendance, qConstantPower);
            Update();
        }

        /// <summary>
        /// Add additionals attribuities pVoltageExponent and qVoltageExponent
        /// </summary>
        /// <param name="pVoltageExponent">Exponent of per unit voltage effecting reactive power</param>
        /// <param name="qVoltageExponent">Exponent of per unit voltage effecting real power</param>
        public void SetNewStaticLoadCharacteristicData(double pVoltageExponent, double qVoltageExponent)
        {
            #region Checking attribut of ExponentModel
            if (!CurrentStaticLoadCharacteristic.ExponentModel)
            {
                throw new Exception("This object of class StaticLoadCharacteristic hasn`t exponential voltage dependency model (pVoltateExponent and qVoltageExponent)");
            }
            #endregion
            CurrentStaticLoadCharacteristic.SetNewStaticLoadCharacteristicData(pVoltageExponent, qVoltageExponent);
            Update();
        }

        /// <summary>
        /// Setting object of class EnergyConsumer
        /// </summary>
        /// <param name="energyConsumer">Object of class EnergyConsumer</param>
        public void SetEnergyConsumer(EnergyConsumer energyConsumer)
        {
            CurrentStaticLoadCharacteristic.SetEnergyConsumer(energyConsumer);
            Update();
        }

        /// <summary>
        /// Update current object of class StaticLoadCharacteristics
        /// </summary>
        public void Update()
        {
            using (ApplicationsContext db = new ApplicationsContext())
            {
                db.StaticLoadCharacteristics.AddOrUpdate(CurrentStaticLoadCharacteristic);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Getting full list of object of class StaticLoadCharacteristic
        /// </summary>
        /// <returns>List of object of class StaticLoadCharacteristic</returns>
        public List<StaticLoadCharacteristic> GetStaticLoadCharacteristics()
        {
            using (var db = new ApplicationsContext())
            {
                return db.StaticLoadCharacteristics.Where(s => true).ToList();
            }
        }

        /// <summary>
        /// Deleting object of class StaticLoadCharacteristic
        /// </summary>
        /// <param name="staticLoadCharacteristic">Object of class StaticLoadCharacteristic</param>
        public void Delete(StaticLoadCharacteristic staticLoadCharacteristic)
        {
            using (var db = new ApplicationsContext())
            {
                db.StaticLoadCharacteristics.Attach(staticLoadCharacteristic);
                db.StaticLoadCharacteristics.Remove(staticLoadCharacteristic);
                db.SaveChanges();
            }
        }

    }
}
using System;
using System.Linq;
using ApplicationInformationModel.Controllers;
using ApplicationInformationModel.Model;


namespace CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrange
            Guid staticLoadCharacteristicMRid = Guid.NewGuid();
            Guid energyConsumerMRid = Guid.NewGuid();
            var name = "SetEnergyConsumerTest";
            bool exponentModel = false;
            double pFrequencyExponent = 1;
            double qFrequencyExponent = 1;
            var staticLoadCharacteristicController = new StaticLoadCharacteristicController(staticLoadCharacteristicMRid, name, exponentModel, pFrequencyExponent, qFrequencyExponent);
            var energyConsumerController = new EnergyConsumerController(energyConsumerMRid, "SetEnergyConsumerTest", 1, 0.5, 0.5, 0.5, 0.5);
            //Act
            staticLoadCharacteristicController.SetEnergyConsumer(energyConsumerController.CurrentEnergyConsumer);
            var list = staticLoadCharacteristicController.GetStaticLoadCharacteristics().First(s => s.MRID == staticLoadCharacteristicMRid);
            //Assert
            staticLoadCharacteristicController.Delete();
            energyConsumerController.Delete();
        }
    }
}

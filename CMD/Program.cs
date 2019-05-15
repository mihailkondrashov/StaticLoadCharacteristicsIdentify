using System;
using ApplicationInformationModel.Controllers;
using ApplicationInformationModel.Model;

namespace CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticLoadCharacteristicController control = new StaticLoadCharacteristicController(Guid.NewGuid(), "Тест", true , 1,1);
            EnergyConsumerController energyConsumerController = new EnergyConsumerController(Guid.NewGuid(), "Фидер 1", 1, 0.5, 0.5, 0.5, 0.5);

            control.SetNewStaticLoadCharacteristicData(1,10);
            control.SetEnergyConsumer(energyConsumerController.CurrentEnergyConsumer);
            var list = control.GetStaticLoadCharacteristics();
        }
    }
}

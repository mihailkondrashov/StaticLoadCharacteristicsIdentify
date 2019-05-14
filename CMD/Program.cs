using System;
using ApplicationInformationModel.Controllers;
using ApplicationInformationModel.Model;

namespace CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticLoadCharacteristicController control = new StaticLoadCharacteristicController("Тест", false , 1,1);
            EnergyConsumerController energyConsumerController = new EnergyConsumerController("Фидер 1", 1, 0.5, 0.5, 0.5, 0.5);

            control.SetNewStaticLoadCharacteristicData(1,0,0,1,0,0);
            control.SetEnergyConsumer(energyConsumerController.energyConsumer);
            var list = control.GetStaticLoadCharacteristics();
        }
    }
}

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
            var list1 = energyConsumerController.GetInvolveStaticLoadCharacteristics();

            var a =energyConsumerController.GetEnergyConsumers();


            var analog = new MeasurementController(Guid.NewGuid(),"Analog1","Active Power" ,true,0,5,3);
            var listOfAnalog = analog.GetInvolveAnalogValues();


            Guid measurementValueSource_MRID = Guid.NewGuid();
            string measurementValueSource_name = "SetMeasurementValueSourceTest";

            Guid measurementValue_MRID = Guid.NewGuid();
            string measurementValue_name = "SetMeasurementValueSourceTest";
            double sensor = 0.2;
            DateTime date = DateTime.Now;
            double value = 10;

            var measurementValueSourcecontroller = new MeasurementValueSourceController(measurementValueSource_MRID, measurementValueSource_name);
            var measurementValueController = new MeasurementValueController(measurementValue_MRID, measurementValue_name, sensor, date, value);
            measurementValueController.SetMeasurementValueSource(measurementValueSourcecontroller.CurrentMeasurementValueSource);
        }
    }
}

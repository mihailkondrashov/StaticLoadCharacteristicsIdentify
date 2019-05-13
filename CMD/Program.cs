using System;
using ApplicationInformationModel.Controllers;
using ApplicationInformationModel.Model;

namespace CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticLoadCharacteristicController control = new StaticLoadCharacteristicController("Тест", false , 0,0);

            control.SetNewStaticLoadCharacteristicData(1,0,0,1,0,0);

            

        }
    }
}

using System.Data.Entity;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    public class ApplicationsContext : DbContext
    {
        public ApplicationsContext(): base("ApplicationDB") { }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<EnergyConsumer> EnergyConsumers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<StaticLoadCharacteristic> StaticLoadCharacteristics { get; set; }
    }
}
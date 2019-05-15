using System.Data.Entity;
using ApplicationInformationModel.Model;

namespace ApplicationInformationModel.Controllers
{
    public class ApplicationsContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public ApplicationsContext(): base("ApplicationDB") { }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<EnergyConsumer> EnergyConsumers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<StaticLoadCharacteristic> StaticLoadCharacteristics { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Analog> Analogs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<AnalogValue> AnalogValues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<MeasurementValueSource> MeasurementValueSources { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<MeasurementType> MeasurementTypes { get; set; }
    }
}
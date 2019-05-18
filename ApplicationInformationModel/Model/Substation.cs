using System;
using System.Collections;
using System.Collections.Generic;

namespace ApplicationInformationModel.Model
{
    public class Substation:IdentifiedObject
    {
        /// <summary>
        /// 
        /// </summary>
        public ICollection<EnergyConsumer> EnergyConsumers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Substation() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mRid"></param>
        /// <param name="name"></param>
        public Substation(Guid mRid, string name) : base(mRid, name) { }
    }
}
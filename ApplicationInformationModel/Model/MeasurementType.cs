using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationInformationModel.Model
{
    /// <summary>
    /// Type of measurement 
    /// </summary>
    public class MeasurementType
    {
        /// <summary>
        /// Identificator
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Object name of type of measurement 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection of object of class Analog
        /// </summary>
        public virtual ICollection<Analog> Analogs { get; set; }

        /// <summary>
        /// No parametrless constructor of class MeasurementType
        /// </summary>
        public MeasurementType() { }

        /// <summary>
        /// Constructor of class 
        /// </summary>
        /// <param name="name">Object name of type of measurementType </param>
        public MeasurementType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>Object name of type of measurementType</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
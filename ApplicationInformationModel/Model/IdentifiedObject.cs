using System;
using System.CodeDom;
using System.ComponentModel.DataAnnotations;

namespace ApplicationInformationModel.Model
{
    /// <summary>
    /// This is a root class to provide common naming attributes for all classes needing naming attributes
    /// </summary>
    public abstract class IdentifiedObject
    {
        /// <summary>
        /// The aliasName is free text human readable name of the object alternative to IdentifiedObject.name
        /// </summary>
        public string AliasName { get; set; } = String.Empty;

        /// <summary>
        /// The description is a free human readable text describing or naming the object
        /// </summary>
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// The localName is a human readable name of the object
        /// </summary>
        public string LocalName { get; set; } = String.Empty;

        [Key]
        /// <summary>
        /// A Model Authority issues mRIDs
        /// </summary>
        public Guid MRID { get; set; }

        /// <summary>
        /// The name is a free text human readable name of the object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  The pathname is a system unique name composed from all IdentifiedObject.localNames in a naming hierarchy path from the object to the root
        /// </summary>
        public string PathName { get; set; } = String.Empty;

        /// <summary>
        /// Constructor of class IdentifiedObject
        /// </summary>
        /// <param name="mRid">A Model Authority issues mRIDs</param>
        /// <param name="name">The name is a free text human readable name of the object</param>
        public IdentifiedObject(Guid mRid, string name)
        {
            #region Checking Input Arguments
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of object mustn`t be null", nameof(name));
            }
            #endregion
            this.MRID = mRid;
            this.Name = name;
        }

        /// <summary>
        /// No parameterless constructor of class IdentifiedObject 
        /// </summary>
        public IdentifiedObject() { }

        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
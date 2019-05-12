using System;

namespace ApplicationInformationModel
{
    /// <summary>
    /// 
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

        /// <summary>
        /// A Model Authority issues mRIDs
        /// </summary>
        public Guid MRID { get; }

        /// <summary>
        /// The name is a free text human readable name of the object
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///  The pathname is a system unique name composed from all IdentifiedObject.localNames in a naming hierarchy path from the object to the root
        /// </summary>
        public string PathName { get; set; } = String.Empty;

        public IdentifiedObject(Guid mRid, string name)
        {
            this.MRID = mRid;
            this.Name = name;
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace ApplicationInformationModel.Controllers
{
    /// <summary>
    /// An exception is thrown if the deleting object has a foreign key reference. 
    /// </summary>
    public class ObjectHasReferenceException:ApplicationException
    {
        public ObjectHasReferenceException() { }

        public ObjectHasReferenceException(string message) : base(message) { }

        public ObjectHasReferenceException(string message, Exception inner) : base(message, inner) { }

        protected ObjectHasReferenceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
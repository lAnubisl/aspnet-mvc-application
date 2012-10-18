using System;
using System.Xml.Serialization;

namespace DomainService.DomainModels
{
    [Serializable]
    public abstract class DomainObject : IDomainObject
    {
        #region IDomainObject Members

        [XmlElement("Id")]
        public virtual long Id { get; set; }

        /// <summary>
        /// Transient objects are not associated with an item already in storage.
        /// For instance, an Entity is transient if its ID is 0.
        /// </summary>
        public virtual bool IsTransient()
        {
            return Id.Equals(default(long));
        }

        #endregion

        /// <summary>
        /// Must be provided to properly compare two objects
        /// </summary>
        public abstract override int GetHashCode();

        public override bool Equals(object obj)
        {
            var compareTo = obj as DomainObject;

            // Since the IDs aren't the same, either of them must be transient to 
            // compare business value signatures
            return (compareTo != null) &&
                  (HasSameNonDefaultIdAs(compareTo) ||
                   ((IsTransient() || compareTo.IsTransient()) && HasSameBusinessSignatureAs(compareTo)));
        }

        /// <summary>
        /// If object is null then 0 will be returned, otherwise GetHashCode method 
        /// will be called.
        /// </summary>
        /// <typeparam name="T">Type of object on which this method will operate on.</typeparam>
        /// <param name="obj">Object on which this method will be operate.</param>
        /// <returns>0 if object is null, otherwise result of GetHashCode method call.</returns>
        protected static int GetSafelyHashCode<T>(T obj) where T : class
        {
            return obj != null ? obj.GetHashCode() : 0;
        }

        private bool HasSameBusinessSignatureAs(DomainObject compareTo)
        {
            if (compareTo == null)
            {
                throw new ArgumentNullException("compareTo");
            }

            return GetHashCode().Equals(compareTo.GetHashCode());
        }

        /// <summary>
        /// Returns true if self and the provided persistent object have the same ID values 
        /// and the IDs are not of the default ID value
        /// </summary>
        private bool HasSameNonDefaultIdAs(DomainObject compareTo)
        {
            if (compareTo == null)
            {
                throw new ArgumentNullException("compareTo");
            }

            return (!Id.Equals(default(long))) && Id.Equals(compareTo.Id);
        }
    }
}
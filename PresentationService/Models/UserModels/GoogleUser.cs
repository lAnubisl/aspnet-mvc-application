using System.Runtime.Serialization;

namespace PresentationService.Models.UserModels
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "This class is needed for JSON deserialization from the google service"), DataContract]
    internal class GoogleUser : IServiceUser
    {
        [DataMember]
        private string email;

        [DataMember(Name = "given_name")]
        private string firstName;

        [DataMember(Name = "family_name")]
        private string lastName;

        /// <summary>
        /// Empty constructor requires for json deserialization
        /// </summary>
        public GoogleUser()
        {
        }

        internal GoogleUser(string email, string firstName, string lastName)
        {
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string Email
        {
            get { return email; }
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }
    }
}
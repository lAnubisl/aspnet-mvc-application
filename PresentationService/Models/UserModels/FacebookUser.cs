using System.Runtime.Serialization;

namespace PresentationService.Models.UserModels
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "This class is needed for JSON deserialization from the facebook service"), DataContract]
    internal class FacebookUser : IServiceUser
    {
        [DataMember]
        private string email;

        [DataMember(Name = "first_name")]
        private string firstName;

        [DataMember(Name = "last_name")]
        private string lastName;

        /// <summary>
        /// Empty constructor is needed for JSON deserialization
        /// </summary>
        public FacebookUser()
        {
        }

        public FacebookUser(string email, string firstName, string lastName)
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
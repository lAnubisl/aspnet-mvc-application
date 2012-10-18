namespace DomainService.DomainModels
{
    public class RegisteredUser : User
    {
        public virtual string Password { get; set; }
    }
}

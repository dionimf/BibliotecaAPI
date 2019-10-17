namespace MF.Domain.Entities
{
    public class Contact
    {
        public string PhoneNumber { get; protected set; }
        public string Email { get; protected set; }

        protected Contact()
        {
        }
        public Contact(string phoneNumber, string email)
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }

        
    }
}
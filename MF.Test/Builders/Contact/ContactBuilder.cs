namespace MF.Test.Builders.Contact
{
    public class ContactBuilder
    {
        private string _phoneNumber;
        private string _email;

        public Domain.Entities.Contact Build()
        {
            return new Domain.Entities.Contact(phoneNumber:_phoneNumber,email:_email);
        }

        public ContactBuilder WithPhoneNumber(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
            return this;
        }

        public ContactBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }
    }
}
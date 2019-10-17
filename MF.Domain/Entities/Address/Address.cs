namespace MF.Domain.Entities
{
    public class Address
    {
        public string PostalCode { get; protected set; }
        public string AddressLine { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string Country { get; protected set; }

        protected Address()
        {
        }

        public Address(string postalCode, string addressLine, string city, string state, string country)
        {
            PostalCode = postalCode;
            AddressLine = addressLine;
            City = city;
            State = state;
            Country = country;
        }
    }
}
namespace MF.Test.Builders.Address
{
    public class AddressBuilder
    {
        private string _postalCode;
        private string _addressLine;
        private string _city;
        private string _state;
        private string _country;

        public Domain.Entities.Address Build()
        {
            return new Domain.Entities.Address(postalCode:_postalCode,addressLine:_addressLine,city:_city,state:_state,country:_country);
        }

        public AddressBuilder WithPostalCode(string postalConde)
        {
            _postalCode = postalConde;
            return this;
        }

        public AddressBuilder WithAddressLine(string addressLine)
        {
            _addressLine = addressLine;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            _state = state;
            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            _country = country;
            return this;
        }
    }
}
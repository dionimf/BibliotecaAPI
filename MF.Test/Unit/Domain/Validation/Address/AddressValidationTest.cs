using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using MF.Domain.Validation;
using Xunit;

namespace MF.Test.Unit.Domain.Validation.Address
{
    public class AddressValidationTest
    {
        [Theory]
        [InlineData("saddsdasdad", false)]
        [InlineData("544454", false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("88960000", true)]
        public async Task MustCheckPostalCodeValid(string postalCode, bool result)
        {
            var model = new AddressValidation();
            var address = new MF.Domain.Entities.Address(postalCode, "rua geral", "Blumenau", "SC", "BR");
            var addressValidate = model.Validate(address).IsValid;
            addressValidate.Should().Be(result);
        }
        [Theory]
        [InlineData("rua ghost", true)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        public async Task MustCheckPostalCodeAdrressLineValid(string adrresLine, bool result)
        {
            var model = new AddressValidation();
            var address = new MF.Domain.Entities.Address("89600111", adrresLine, "Blumenau", "SC", "BR");
            var addressValidate = model.Validate(address).IsValid;
            addressValidate.Should().Be(result);
        }

        [Theory]
        [InlineData("Blumenau", true)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        public async Task MustCheckCityValid(string city, bool result)
        {
            var model = new AddressValidation();
            var address = new MF.Domain.Entities.Address("89600111", "rua geral", city, "SC", "BR");
            var addressValidate = model.Validate(address).IsValid;
            addressValidate.Should().Be(result);
        }

        [Theory]
        [InlineData("RS", true)]
        [InlineData("sc", true)]
        [InlineData("Brasilia", false)]
        [InlineData("q", false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        public async Task MustCheckStateValid(string state, bool result)
        {
            var model = new AddressValidation();
            var address = new MF.Domain.Entities.Address("89600111", "rua geral", "Blumenau", state, "BR");
            var addressValidate = model.Validate(address).IsValid;
            addressValidate.Should().Be(result);
        }

        [Theory]
        [InlineData("US", true)]
        [InlineData("br", true)]
        [InlineData("brasil", false)]
        [InlineData("q", false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        public async Task MustCheckCountryValid(string country, bool result)
        {
            var model = new AddressValidation();
            var address = new MF.Domain.Entities.Address("89600111", "rua geral", "Blumenau", "SC", country);
            var addressValidate = model.Validate(address).IsValid;
            addressValidate.Should().Be(result);
        }
    }
}
using System.Threading.Tasks;
using FluentAssertions;
using MF.Domain.Validation;
using MF.Test.Builders.Address;
using MF.Test.Builders.Contact;
using Xunit;

namespace MF.Test.Unit.Domain.Validation.User
{
    public class UserValidationTest
    {
        [Theory]
        [InlineData("",false)]
        [InlineData(" ",false)]
        [InlineData("Venus",true)]
        public async Task MustCheckFistNameValid(string firstName, bool result)
        {
            var model = new UserValidation();
            var user = new MF.Domain.Entities.User.User(firstName, "zen", "diozen", "15651dsa5", 0, ContactUser(), AddressUser(), true);
            var userValid = model.Validate(user).IsValid;
            userValid.Should().Be(result);
        }
        [Theory]
        [InlineData("",false)]
        [InlineData(" ",false)]
        [InlineData("Chaos",true)]
        public async Task MustCheckLastNameValid(string lastName, bool result)
        {
            var model = new UserValidation();
            var user = new MF.Domain.Entities.User.User("dio", lastName, "diozen", "1211551ads", 0, ContactUser(), AddressUser(), true);
            var userValid = model.Validate(user).IsValid;
            userValid.Should().Be(result);
        }
        [Theory]
        [InlineData("",false)]
        [InlineData("s",false)]
        [InlineData(" ",false)]
        [InlineData("4534354",true)]
        [InlineData("saddsdasdad515",true)]
        [InlineData("saddsdasdad",true)]
        public async Task MustCheckLoginValid(string login, bool result)
        { var model = new UserValidation();
            var user = new MF.Domain.Entities.User.User("dio", "zen", login, "1234dfs", 0, ContactUser(), AddressUser(), true);
            var userValid = model.Validate(user).IsValid;
            userValid.Should().Be(result);
        }
        [Theory]
        [InlineData("",false)]
        [InlineData("e",false)]
        [InlineData(" ",false)]
        [InlineData("saddsdasdad",true)]
        [InlineData("saddsda4524",true)]
        public async Task MustCheckPasswordValid(string password,bool result)
        { var model = new UserValidation();
            var user = new MF.Domain.Entities.User.User("Dio", "Zen", "diozen", password, 0, ContactUser(), AddressUser(), true);
            var userValid = model.Validate(user).IsValid;
            userValid.Should().Be(result);
        }

        public MF.Domain.Entities.Contact ContactUser()
        {
            return new ContactBuilder().WithPhoneNumber("4899998888").WithEmail("dioni@dioni.com").Build();
        }

        public MF.Domain.Entities.Address AddressUser()
        {
            return new AddressBuilder().WithPostalCode("88960111").WithAddressLine("rua atg").WithCity("gods").WithState("SC").WithCountry("BR").Build();
        }
    }
}
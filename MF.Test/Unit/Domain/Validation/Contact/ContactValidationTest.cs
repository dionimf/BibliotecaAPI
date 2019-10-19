using System.Threading.Tasks;
using FluentAssertions;
using MF.Domain.Validation;
using Xunit;

namespace MF.Test.Unit.Domain.Validation.Contact
{
    public class ContactValidationTest
    {
        [Theory]
        [InlineData("5555555555555555555555555555555",false)]
        [InlineData("55555",false)]
        [InlineData("48999281203",true)]
        public async Task MustCheckPhoneNumberValid(string phoneNumber,bool result)
        {
            var model = new ContactValidation();
            var contact = new MF.Domain.Entities.Contact(phoneNumber,"dionimf@unesc.net");
            var contactValidate = model.Validate(contact).IsValid;
            contactValidate.Should().Be(result);
        }

        [Theory]
        [InlineData("saddsdasdad",false)]
        [InlineData("544454",false)]
        [InlineData("dionimf@unesc.net",true)]
        public async Task MustCheckEmailValid(string email,bool result)
        {
            var model = new ContactValidation();
            var contact = new MF.Domain.Entities.Contact("48999995555",email);
            var contactValidate = model.Validate(contact).IsValid;
            contactValidate.Should().Be(result);}
    }
}
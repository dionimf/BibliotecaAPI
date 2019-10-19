using System;
using System.Threading.Tasks;
using FluentAssertions;
using MF.Test.Builders.Address;
using MF.Test.Builders.Contact;
using MF.Test.Builders.User;
using Xunit;

namespace MF.Test.Unit.Domain.Entities.User
{
    public class UserTest
    {
        [Fact]
        public async Task MustInactivateUser()
        {
            var user = new UserBuilder().Active().Build();
            user.Disable();
            user.Active.Should().BeFalse();
        }
        [Fact]
        public async Task MustUpdateUser()
        {
            var userId = Guid.NewGuid();
            var user= new UserBuilder().WithId(userId).WithFirstName("Dioni").WithLastName("Machado").WithLogin("dioni")
                .WithPassword("123456").WithLevel(0)
                .WithContact(new ContactBuilder().WithPhoneNumber("48999281203").WithEmail("dionimf@unesc.net").Build())
                .WithAddress(new AddressBuilder().WithPostalCode("89062101").WithAddressLine("rua").WithCity("blumenau")
                    .WithState("sc")
                    .WithCountry("br").Build())
                .Active().Build();
            var contact = new ContactBuilder().WithPhoneNumber("48999281203").WithEmail("dionimf@unesc.net").Build();
            var address = new AddressBuilder().WithPostalCode("89062101").WithAddressLine("rua").WithCity("blumenau")
                .WithState("sc")
                .WithCountry("br").Build();
            user.Update("avell","leva","avell","54321",2,contact,address,false);
            user.FirstName.Should().Be("avell");
            user.LastName.Should().Be("leva");
            user.Login.Should().Be("avell");
            user.Level.Should().Be(2);
            user.Contact.Should().BeEquivalentTo(contact);
            user.Address.Should().BeEquivalentTo(address);
            user.Active.Should().BeFalse();
        }
    }
}
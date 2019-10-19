using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MF.Application.Models.Address;
using MF.Application.Models.Contact;
using MF.Application.Models.User;
using MF.Application.Services.User;
using MF.Domain.Interfaces;
using MF.Test.Builders.Address;
using MF.Test.Builders.Contact;
using MF.Test.Builders.User;
using NSubstitute;
using Xunit;

namespace MF.Test.Unit.Application.Service.User
{
    public class UserServiceTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _userService = new UserService(_userRepository);
        }
        [Fact]
        public async Task MustCreateUser()
        {
            var model = new UserRequestModel()
            {
                FirstName = "avell",
                LastName = "american",
                Login = "avellm",
                Password = "0213456",
                Level = 2,
                Contact = new ContactRequestModel()
                {
                    PhoneNumber = "4799995555",
                    Email = "avell@unesc.net"
                },
                Address = new AddressRequestModel()
                {
                    PostalCode = "88960000",
                    AddressLine = "avenida",
                    City = "Sombrio",
                    State = "RS",
                    Country = "JP"
                },
                Active = true
            };
            await _userService.Create(model);
            await _userRepository.Received(1).Create(Arg.Is<MF.Domain.Entities.User.User>(i =>
                i.FirstName == "avell"
                && i.LastName == "american"
                && i.Login == "avellm"
                && i.Password == "0213456"
                && i.Level == 2
                && i.Contact.PhoneNumber == "4799995555"
                && i.Contact.Email == "avell@unesc.net"
                && i.Address.PostalCode == "88960000"
                && i.Address.AddressLine == "avenida"
                && i.Address.City == "Sombrio"
                && i.Address.State == "RS"
                && i.Address.Country == "JP"
                && i.Active == true
            ));
        }

        [Fact]
        public async Task MustUpdateUser()
        {
            var userId = Guid.NewGuid();
            var user = UserForTest(userId);
            _userRepository.GetById(userId).Returns(user);
            var model = new UserRequestModel()
            {
                FirstName = "avell",
                LastName = "american",
                Login = "avellm",
                Password = "0213456",
                Level = 1,
                Contact = new ContactRequestModel()
                {
                    PhoneNumber = "4799995555",
                    Email = "avell@unesc.net"
                },
                Address = new AddressRequestModel()
                {
                    PostalCode = "88960000",
                    AddressLine = "avenida",
                    City = "Sombrio",
                    State = "RS",
                    Country = "JP"
                },
                Active = true
            };
            await _userService.Update(userId, model);

            await _userRepository.Received(1).Update(userId,
                Arg.Is<MF.Domain.Entities.User.User>(i =>
                    i.FirstName == "avell"
                    && i.LastName == "american"
                    && i.Login == "avellm"
                    && i.Password == "0213456"
                    && i.Level == 1
                    && i.Contact.PhoneNumber == "4799995555"
                    && i.Contact.Email == "avell@unesc.net"
                    && i.Address.PostalCode == "88960000"
                    && i.Address.AddressLine == "avenida"
                    && i.Address.City == "Sombrio"
                    && i.Address.State == "RS"
                    && i.Address.Country == "JP"
                    && i.Active == true
                ));
        }

        [Fact]
        public async Task MustInactivateUser()
        {
            var userId = Guid.NewGuid();
            var user = UserForTest(userId);
            _userRepository.GetById(userId).Returns(user);
            await _userService.Delete(userId);
            await _userRepository.Received(1).Update(userId,
                Arg.Is<MF.Domain.Entities.User.User>(i =>
                    i.FirstName == user.FirstName
                    && i.LastName == user.LastName
                    && i.Login == user.Login
                    && i.Password == user.Password
                    && i.Level == user.Level
                    && i.Contact.PhoneNumber == user.Contact.PhoneNumber
                    && i.Contact.Email == user.Contact.Email
                    && i.Address.PostalCode == user.Address.PostalCode
                    && i.Address.AddressLine == user.Address.AddressLine
                    && i.Address.City == user.Address.City
                    && i.Address.State == user.Address.State
                    && i.Address.Country == user.Address.Country
                    && i.Active == false
                ));
        }

        [Fact]
        public async Task MustGetAllUsers()
        {
            var userIdA = Guid.NewGuid();
            var userIdB = Guid.NewGuid();
            var userA = new UserBuilder().WithId(userIdA).WithFirstName("Dioni").WithLastName("Machado")
                .WithLogin("dioni")
                .WithPassword("123456").WithLevel(0)
                .WithContact(new ContactBuilder().WithPhoneNumber("48999281203").WithEmail("dionimf@unesc.net").Build())
                .WithAddress(new AddressBuilder().WithPostalCode("89062101").WithAddressLine("rua").WithCity("blumenau")
                    .WithState("sc")
                    .WithCountry("br").Build())
                .Active().Build();


            var userB = new UserBuilder().WithId(userIdB).WithFirstName("Avell").WithLastName("Merchant")
                .WithLogin("avell")
                .WithPassword("123456").WithLevel(0)
                .WithContact(new ContactBuilder().WithPhoneNumber("48999555599").WithEmail("avell@unesc.net").Build())
                .WithAddress(new AddressBuilder().WithPostalCode("88960000").WithAddressLine("rio").WithCity("timbo")
                    .WithState("sp")
                    .WithCountry("us").Build())
                .Active().Build();
            var listUsers = new List<MF.Domain.Entities.User.User>();
            listUsers.Add(userA);
            listUsers.Add(userB);
            _userRepository.GetAll().Returns(listUsers.AsQueryable());
            var users = await _userService.GetAll();
            users.Should().HaveCount(2);
            users[0].FirstName.Should().Be(userA.FirstName);
            users[0].LastName.Should().Be(userA.LastName);
            users[0].Login.Should().Be(userA.Login);
            users[0].Password.Should().Be(userA.Password);
            users[0].Level.Should().Be(userA.Level);
            users[0].Contact.Should().BeEquivalentTo(userA.Contact);
            users[0].Address.Should().BeEquivalentTo(userA.Address);
            users[0].Active.Should().Be(userA.Active);
            users[1].FirstName.Should().Be(userB.FirstName);
            users[1].LastName.Should().Be(userB.LastName);
            users[1].Login.Should().Be(userB.Login);
            users[1].Password.Should().Be(userB.Password);
            users[1].Level.Should().Be(userB.Level);
            users[1].Contact.Should().BeEquivalentTo(userB.Contact);
            users[1].Address.Should().BeEquivalentTo(userB.Address);
            users[1].Active.Should().Be(userB.Active);
        }

        [Fact]
        public async Task MustGetByIdUser()
        {
            var userId = Guid.NewGuid();
            var user = UserForTest(userId);
            /*
            var contact = new ContactBuilder().WithPhoneNumber("48999281203").WithEmail("dionimf@unesc.net").Build();
            var address = new AddressBuilder().WithPostalCode("89062101").WithAddressLine("rua").WithCity("blumenau").WithState("sc").WithCountry("br").Build();
            var user = new UserBuilder().WithFirstName("").WithLastName("").WithLogin("").WithPassword("").WithLevel(0).WithContact(contact).WithAddress(address).Active().Build();
            */

            _userRepository.GetById(userId).Returns(user);
            var userReturn = await _userRepository.GetById(userId);
            userReturn.FirstName.Should().Be(user.FirstName);
            userReturn.LastName.Should().Be(user.LastName);
            userReturn.Login.Should().Be(user.Login);
            userReturn.Password.Should().Be(user.Password);
            userReturn.Level.Should().Be(user.Level);
            userReturn.Contact.Should().BeEquivalentTo(user.Contact);
            userReturn.Address.Should().BeEquivalentTo(user.Address);
            userReturn.Active.Should().Be(user.Active);
            userReturn.Id.Should().Be(user.Id);
        }

        [Fact]
        public async Task MustCheckUserAbsent()
        {
            var userId = Guid.NewGuid();
            var userReturn = await _userRepository.GetById(userId);
            userReturn.Should().BeNull();
        }

        private MF.Domain.Entities.User.User UserForTest(Guid id)
        {
            return new UserBuilder().WithId(id).WithFirstName("Dioni").WithLastName("Machado").WithLogin("dioni")
                .WithPassword("123456").WithLevel(0)
                .WithContact(new ContactBuilder().WithPhoneNumber("48999281203").WithEmail("dionimf@unesc.net").Build())
                .WithAddress(new AddressBuilder().WithPostalCode("89062101").WithAddressLine("rua").WithCity("blumenau")
                    .WithState("sc")
                    .WithCountry("br").Build())
                .Active().Build();
        }
    }
}
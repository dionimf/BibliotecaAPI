using System;
using MF.Domain.Entities;

namespace MF.Test.Builders.User
{
    public class UserBuilder
    {
        private Guid _id;
        private string _firstName;
        private string _lastName;
        private string _login;
        private string _password;
        private int _level;
        private Domain.Entities.Contact _contact;
        private Domain.Entities.Address _address;
        private bool _active;

        public Domain.Entities.User.User Build()
        {
            return new Domain.Entities.User.User(firstName:_firstName,lastName:_lastName,login:_login,password:_password,
                level:_level,contact:_contact,address:_address,active:_active)
            {
                Id = _id
            };
        }

        public UserBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
        public UserBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }
        public UserBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public UserBuilder WithLogin(string login)
        {
            _login = login;
            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public UserBuilder WithLevel(int level)
        {
            _level = level;
            return this;
        }

        public UserBuilder WithContact(Domain.Entities.Contact contact)
        {
            _contact = contact;
            return this;
        }

        public UserBuilder WithAddress(Domain.Entities.Address address)
        {
            _address = address;
            return this;
        }

        public UserBuilder Active()
        {
            _active = true;
            return this;
        }

        public UserBuilder Inative()
        {
            _active = false;
            return this;
        }
    }
}
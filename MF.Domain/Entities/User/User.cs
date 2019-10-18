using System;
using FluentValidation.Results;
using MF.Domain.Validation;

namespace MF.Domain.Entities.User
{
    public class User : BaseEntity
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public Contact Contact { get; protected set; }
        public Address Address { get; protected set; }
        public bool Active { get;protected set; }

        enum Level : int
        {
            Hire = 0,
            Management = 1,
            Admin = 2
        }
        protected User()
        {
        }
        public User(string firstName, string lastName, string login, string password, Contact contact, Address address, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Contact = contact;
            Address = address;
            Active = active;
        }

        public void Disable()
        {
            Active = false;
        }

        public void Update(string firstName, string lastName, string login, string password, Contact contact,
            Address address, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Contact = contact;
            Address = address;
            Active = active;
        }

        public ValidationResult IsValid()
        {
            return new UserValidation().Validate(this);
        }
        

        
    }
}
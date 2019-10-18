using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MF.Application.Models.Address;
using MF.Application.Models.Contact;
using MF.Application.Models.User;
using MF.Domain.Entities;
using MF.Domain.Interfaces;

namespace MF.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public List<string> Notifications { get; }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Notifications = new List<string>();
        }

        public async Task Create(UserRequestModel request)
        {
            var user = new Domain.Entities.User.User(request.FirstName, request.LastName, request.Login,
                request.Password, ReturnContact(request.Contact),
                ReturnAddress(request.Address), request.Active
            );
            var validUser = user.IsValid();
            if (validUser.IsValid)
            {
                await _userRepository.Create(user);
            }
            else
            {
                Notifications.AddRange(validUser.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }

        public async Task Update(Guid id, UserRequestModel request)
        {
            var user = await _userRepository.GetById(id);
            user.Update(request.FirstName, request.LastName, request.Login, request.Password, ReturnContact(request.Contact),
                ReturnAddress(request.Address), request.Active);
            var validUser = user.IsValid();
            if (validUser.IsValid)
            {
                await _userRepository.Update(id, user);
            }
            else
            {
                Notifications.AddRange(validUser.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }

        public async Task Delete(Guid id)
        {
            var user = await _userRepository.GetById(id);
            user.Disable();
            var validUser = user.IsValid();
            if (validUser.IsValid)
            {
                await _userRepository.Update(id, user);
            }
            else
            {
                Notifications.AddRange(validUser.Errors.Select(x => x.ErrorMessage).ToList());
            }
            
        }

        public async Task<UserResponseModel> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            return JoinFields(user);
        }

        public async Task<IList<UserResponseModel>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.Select(s => JoinFields(s)).ToList();
        }

        private Contact ReturnContact(ContactModel request)
        {
            return new Contact(
                request.PhoneNumber,
                request.Email
                );
        }

        private Address ReturnAddress(AddressModel request)
        {
            return new Address(
                request.PostalCode,
                request.AddressLine,
                request.City,
                request.State,
                request.Country);
        }

        private UserResponseModel JoinFields(Domain.Entities.User.User user)
        {
            return new UserResponseModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password,
                Contact = new ContactRequestModel
                {
                    PhoneNumber = user.Contact.PhoneNumber,
                    Email = user.Contact.Email
                },
                Address = new AddressRequestModel
                {
                    PostalCode = user.Address.PostalCode,
                    AddressLine =user.Address.AddressLine,
                    City = user.Address.City,
                    State =user.Address.State,
                    Country = user.Address.Country
                },
                Active = user.Active
            };
        }
        public bool IsValid()
        {
            return !Notifications.Any();
        }

        public List<string> GetNotfications()
        {
            return Notifications;
        }
    }
}
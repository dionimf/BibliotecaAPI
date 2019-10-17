using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MF.Application.Models.User;
using MF.Domain.Interfaces;
namespace MF.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Create(UserRequestModel request)
        {
            var user = new Domain.Entities.User.User(request.FirstName, request.LastName, request.Login, request.Password, request.Contact,
                request.Address, request.Active
            );
            await _userRepository.Create(user);
        }

        public async Task Update(Guid id, UserRequestModel request)
        {
            var user = await _userRepository.GetById(id);
            user.Update(request.FirstName, request.LastName, request.Login, request.Password, request.Contact,
                request.Address, request.Active);
            await _userRepository.Update(id, user);
        }

        public async Task Delete(Guid id)
        {
            var user = await _userRepository.GetById(id);
            user.Disable();
            await _userRepository.Update(id, user);
        }

        public async Task<UserResponseModel> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            return new UserResponseModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password,
                Contact = user.Contact,
                Address = user.Address,
                Active = user.Active  
            };
        }

        public async Task<IList<UserResponseModel>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.Select(s => new UserResponseModel()
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                Login = s.Login,
                Password = s.Password,
                Contact = s.Contact,
                Address = s.Address,
                Active = s.Active
            }).ToList();
        }
    }
}
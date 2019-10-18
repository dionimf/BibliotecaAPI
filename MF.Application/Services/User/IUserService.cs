using System.Collections.Generic;
using MF.Application.Models.User;

namespace MF.Application.Services.User
{
    public interface IUserService : IGenericService<UserRequestModel, UserResponseModel>
    {
        bool IsValid();
        List<string> GetNotfications();
    }
}
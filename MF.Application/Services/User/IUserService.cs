using MF.Application.Models.User;

namespace MF.Application.Services.User
{
    public interface IUserService : IGenericService<UserRequestModel, UserResponseModel>
    {
    }
}
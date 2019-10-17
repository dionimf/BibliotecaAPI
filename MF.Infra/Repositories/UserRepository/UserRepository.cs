using MF.Domain.Entities.User;
using MF.Domain.Interfaces;
using MF.Infra.Context;
using MF.Infra.Repositories.GenericRepository;

namespace MF.Infra.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(MainContext dbContext):base(dbContext){}
        
    }
}
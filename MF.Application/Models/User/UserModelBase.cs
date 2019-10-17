using MF.Domain.Entities;

namespace MF.Application.Models.User
{
    public class UserModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }
    }
}
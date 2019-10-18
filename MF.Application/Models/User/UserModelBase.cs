using MF.Application.Models.Address;
using MF.Application.Models.Contact;
using MF.Domain.Entities;

namespace MF.Application.Models.User
{
    public class UserModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ContactRequestModel Contact { get; set; }
        public AddressRequestModel Address { get; set; }
        public bool Active { get; set; }
    }
}
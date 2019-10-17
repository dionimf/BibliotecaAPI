using System;

namespace MF.Domain.Entities
{
    public class User
    {
        protected User()
        {
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        enum Level : int
        {
            Hire = 0,
            Management = 1,
            Admin = 2
        }
        
    }
}
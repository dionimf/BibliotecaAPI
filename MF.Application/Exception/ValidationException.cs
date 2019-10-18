using System.Collections.Generic;

namespace MF.Application.Exception
{
    public class ValidationException : System.Exception
    {
        public List<string> Notifications = new List<string>();

        public ValidationException(IEnumerable<string> exceptions)
        {
            Notifications.AddRange(exceptions);
        }

        public ValidationException(string exception)
        {
            Notifications.Add(exception);
        }
    }
}
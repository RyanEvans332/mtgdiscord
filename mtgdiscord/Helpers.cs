using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgdiscord
{
    public static class ConsoleEx
    {
        public static void WriteLine(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow.ToString()}]: {message}");
        }
    }

    public class UserFriendlyError : Exception 
    {
        public UserFriendlyError(string message) : base(message) {}
    }
}

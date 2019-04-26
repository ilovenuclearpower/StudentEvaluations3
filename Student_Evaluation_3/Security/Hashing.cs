using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt;

namespace Student_Evaluation_3.Security
{
    public class Hashing
    {
        public static string GenerateRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string input)
        {
            return BCrypt.Net.BCrypt.Verify(password, input);
        }
    }
}

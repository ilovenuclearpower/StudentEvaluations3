using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
namespace Student_Evaluation_3.Models
{
    public enum Role
    {
        Student, Instructor, Coordinator, Chairman
    }
    public class User
    {
        [ScaffoldColumn(false)]
        public int UserID { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get => password; set => password = Security.Hashing.HashPassword(value); }

        private string password;

    }
}

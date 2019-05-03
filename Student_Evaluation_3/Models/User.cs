using System.Security.Claims;
using System.Data.Data
namespace Student_Evaluation_3.Models
{
    public enum Role
    {
        Student, Instructor, Coordinator, Chairman
    }
    public class User
    {
        [System.ComponentModel.DataAnnotations.ScaffoldColumn(false)]
        public int UserID { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get => password; set => password = value; }

        private string password;

    }
}

namespace Student_Evaluation_3.Models
{
    public enum Role
    {
        Student, Instructor, Coordinator, Chairman
    }
    public class User
    {

        public int id { get; set; }

        private string password;

        private void SetPassword(string value)
        {
            password = Security.Hashing.HashPassword(value);
        }

}

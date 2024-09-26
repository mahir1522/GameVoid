namespace PROG3050_Team_Project.Models
{
    public static class Admin
    {
        public static string UserName = "admin";
        public static string Password = "test@1234";

        public static bool ValidateAdmin(string username, string password)
        {
            return UserName == username && Password == password;  
        }
    }
}

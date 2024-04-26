using System.ComponentModel.DataAnnotations;

namespace Poker.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
                
        public User(int userId, string name, string phone, string password)
        {
            UserId = userId;
            Name = name;
            Phone = phone;
            Password = password;
        }
    }
}
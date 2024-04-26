using System.ComponentModel.DataAnnotations;

namespace Poker.Entities
{
    public class Mesa_Poker
    {
        [Key]
        public int TableId { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }

        public Mesa_Poker (string name, int? userId) 
        {
            Name = name;
            UserId = userId;
        }
    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poker.Entities
{
    public class Mesa(List<int> user_id, int table_id)
    {
        [Key]
        public int id_mesa { get; set; }
        public List<int> User_id { get; set; } = user_id;
        public int Table_id { get; set; } = table_id;
    }
}

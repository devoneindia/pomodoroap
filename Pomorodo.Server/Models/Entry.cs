using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomorodo.Server.Models
{
    [Table("entry_time")]
    public class Entry
    {
        [Key]
        [Column("entry_id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("start_time")]
        public DateTime StartTime { get; set; }
        [Column("end_time")]
        public DateTime EndTime { get; set; }
     

    }
}

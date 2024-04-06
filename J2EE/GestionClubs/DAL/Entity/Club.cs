using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    [Table("Clubs")]
    public class Club
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } = string.Empty;
        public string Description {  get; set; }=string.Empty;
        public DateTime DateTime { get; set; }

        
    }
}

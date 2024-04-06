using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    [Table("Activites")]
    public class Activite
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("IdClub")]
        public int IdClub { get; set; }
        
    }
}


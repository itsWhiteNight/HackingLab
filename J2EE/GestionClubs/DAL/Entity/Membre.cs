using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    [Table("Membres")]
    public class Membre
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        [MaxLength(4)]
        public int Annee { get; set; }
        public string Filiere { get; set; }
        public int Groupe {  get; set; }
        [ForeignKey("IdClub")]
        public int idClub { get; set; }
        

        
    }
}

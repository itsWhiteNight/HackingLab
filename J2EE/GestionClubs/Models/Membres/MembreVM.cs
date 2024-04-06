

namespace Models.Membres
{
    public class MembreVM
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Annee {  get; set; }
        public string Filiere { get; set; }
        public int Groupe {  get; set; }

        public int IdClub { get; set; }
        

    }
}

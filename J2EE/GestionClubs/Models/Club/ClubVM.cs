using Models.Membres;
using Models.Activites;

namespace Models.Club
{
    public  class ClubVM
    {
        public int Id { get; set; }
        public string Nom {  get; set; }
        public string Description{ get; set; }
        public DateTime DateCreation {  get; set; }
        
    }
}

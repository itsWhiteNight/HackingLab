using DAL.Repos;
using Models.Membres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using Models.Club;
using Models.Activites;

namespace BLL
{
    public class ClubService
    {
        public List<ClubVM> ListeClub()
        {
            var list = new List<ClubVM>();
            ClubRepos repos = new ClubRepos();



            foreach (var item in repos.GetAll())
            {

                ClubVM obj = new ClubVM()
                {
                    Id=item.Id,
                    Nom = item.Nom,
                    Description = item.Description,
                    DateCreation=item.DateTime
                   

                };
                list.Add(obj);
            }

            return list;
        }
        public void Ajouter(ClubVM obj)
        {


            var club = new Club();
            var repos = new ClubRepos();
            club.Id = obj.Id;
            club.Nom = obj.Nom;
            club.Description = obj.Description;
            club.DateTime = obj.DateCreation;
           
            repos.Create(club);


        }
        public void Supprimer(int id)
        {
            var repos = new ClubRepos();
            
            repos.Delete(id);
        }
        public void Modifier(ClubVM obj)
        {
            var repos = new ClubRepos();
            Club clubAModifier = repos.Read(obj.Id);
            if (clubAModifier != null)
            {
                clubAModifier.Description = obj.Description;
                clubAModifier.Nom = obj.Nom;
                clubAModifier.DateTime = obj.DateCreation;
                repos.Update(clubAModifier);
            }
            

        }
        public ClubVM Trouver(int id)
        {
            var repos = new ClubRepos();
            Club club = repos.Read(id);

            if (club == null)
            {
                return null;
            }

            ClubVM clubVM = new ClubVM
            {
                Id = id,
                Nom = club.Nom,
                Description = club.Description,
                DateCreation = club.DateTime
            };

            return clubVM;
        }
        public int NbrClubs()
        {
            var repos = new ClubRepos();
            return repos.CountClub();
        }


    }

}

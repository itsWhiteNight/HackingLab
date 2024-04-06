using DAL.Entity;
using DAL.Repos;
using Models.Activites;
using Models.Membres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ActiviteService
    {
        public List<ActiviteVM> ActiviteParClub(int idClub)
        {
            var list = new List<ActiviteVM>();
            ActiviteRepos repos = new ActiviteRepos();



            foreach (var item in repos.GetAll().Where(a => a.IdClub == idClub))
            {

                ActiviteVM obj = new ActiviteVM()
                {
                    Id=item.Id,
                    Nom = item.Nom,
                    Description = item.Description,
                    IdClub = item.IdClub

                };
                list.Add(obj);
            }

            return list;
        }
        public void Ajouter(ActiviteVM obj)
        {

        
            var activite = new Activite();
            var repos = new ActiviteRepos();
            activite.Id = obj.Id;
            activite.Nom = obj.Nom;
            activite.Description = obj.Description;
            activite.IdClub = obj.IdClub;
            repos.Create(activite);


        }
        public List<ActiviteVM> ListActiviteVM()
        {
            //Pour recupere la liste des Activites
            var activiteRepos = new ActiviteRepos();


            List<ActiviteVM> listViewModels = new List<ActiviteVM>();

            foreach (var item in activiteRepos.GetAll())
            {
                ActiviteVM activite = new ActiviteVM();
                activite.Id = item.Id;
                activite.Nom = item.Nom;
                activite.Description = item.Description;
                activite.IdClub = item.IdClub;

                listViewModels.Add(activite);
            }
            return listViewModels;
        }
        public void Supprimer(int Id)
        {
            var repos = new ActiviteRepos();
            repos.Delete(Id);
        }
        public ActiviteVM Trouver(int id)
        {
            var repos = new ActiviteRepos();
            Activite activite = repos.Read(id);

            if (activite == null)
            {
                throw new InvalidOperationException("Activite non trouvée");
            }

            ActiviteVM activiteVM = new ActiviteVM
            {
                Id = id,
                Nom = activite.Nom,
                Description = activite.Description,
                IdClub = activite.IdClub
            };

            return activiteVM;
        }

        public void Modifier(ActiviteVM obj)
        {
            var repos = new ActiviteRepos();
            Activite activiteAModifier = repos.Read(obj.Id);

            if (activiteAModifier == null)
            {
                throw new InvalidOperationException("Activite à modifier non trouvée");
            }


            activiteAModifier.Nom = obj.Nom;
            activiteAModifier.Description = obj.Description;
            activiteAModifier.IdClub = obj.IdClub;
            

            repos.Update(activiteAModifier);
        }
        public int nbrActivite()
        {
            var repos = new ActiviteRepos();
            return repos.CountActivite();
        }

    }
}

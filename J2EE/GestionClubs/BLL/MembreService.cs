using DAL.Entity;
using DAL.Repos;
using Models.Club;
using Models.Membres;
namespace BLL
{
    public class MembreService
    {

        public List<MembreVM> MembreParClub(int idClub)
        {
            var list = new List<MembreVM>();
            MembreRepos repos = new MembreRepos();



            foreach (var item in repos.GetAll().Where(a=>a.idClub==idClub))
            {

                MembreVM obj = new MembreVM()
                {
                    Id=item.Id,
                    Nom = item.Nom,
                    Prenom = item.Prenom,
                    Annee = item.Annee,
                    Filiere = item.Filiere,
                    Groupe = item.Groupe,
                    IdClub = item.idClub

                };
                list.Add(obj);
            }

            return list;
        }

        public void Ajouter(MembreVM obj)
        {
            var membre=new Membre();
            var repos=new MembreRepos();
            membre.Id = obj.Id;
            membre.Nom = obj.Nom;
            membre.Prenom= obj.Prenom;
            membre.Annee = obj.Annee;
            membre.Filiere= obj.Filiere;
            membre.Groupe= obj.Groupe;
            membre.idClub = obj.IdClub;
            repos.Create(membre);


        }
        public List<MembreVM> ListMembreVM()
        {
            //Pour recupere la liste des Membres
            var MembreRepos = new MembreRepos();


            List<MembreVM> listViewModels = new List<MembreVM>();

            foreach (var item in MembreRepos.GetAll())
            {
                MembreVM MembreVModel = new MembreVM();
                MembreVModel.Id = item.Id;
                MembreVModel.Nom = item.Nom;
                MembreVModel.Prenom = item.Prenom;
                MembreVModel.Annee = item.Annee;
                MembreVModel.Filiere = item.Filiere;
                MembreVModel.Groupe = item. Groupe;
                MembreVModel.IdClub = item.idClub;
                listViewModels.Add(MembreVModel);
            }
            return listViewModels;
        }
        public void Supprimer(int Id)
        {
            var repos = new MembreRepos();
            repos.Delete(Id);
        }
        public MembreVM Trouver(int id)
        {
            var repos = new MembreRepos();
            Membre membre = repos.Read(id);

            if (membre == null)
            {
                throw new InvalidOperationException("Membre non trouvé");
            }

            MembreVM membreVM = new MembreVM
            {
                Id = id,
                Nom = membre.Nom,
                Annee = membre.Annee,
                Filiere = membre.Filiere,
                Groupe = membre.Groupe,
                IdClub = membre.idClub
            };

            return membreVM;
        }

        public void Modifier(MembreVM obj)
        {
            var repos = new MembreRepos();
            Membre membreAModifier = repos.Read(obj.Id);

            if (membreAModifier == null)
            {
                throw new InvalidOperationException("Membre à modifier non trouvé");
            }

           
            membreAModifier.Annee = obj.Annee;
            membreAModifier.Filiere = obj.Filiere;
            membreAModifier.Groupe = obj.Groupe;
            membreAModifier.idClub = obj.IdClub;

            repos.Update(membreAModifier);
        }

        public int nbrMembre()
        {
            var repos=new MembreRepos();
            return repos.nbrMembre();
        }


    }

}

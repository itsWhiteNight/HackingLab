using DAL.Entity;
using DAL.Repos;
using Models.Authentification;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UtilisateurService
    {
        public UserSessionVM? VerifierCompte(UserAuthVM obj)
        {
            UtilisateurService utilisateurService = new UtilisateurService();
            var result = utilisateurService.Trouver(obj.Compte,obj.MotPasse);
            if (result != null)
            {
                UserSessionVM userSession = new UserSessionVM();
                userSession.AdresseMail = result.Compte;
                userSession.Id = result.Id;
                userSession.Nom = result.Nom;
                return userSession;
            }
            return null;
        }
        public void Ajouter(UtilisateurVM obj)
        {


            var user = new Utilisateur();
            var repos = new UtilisateurRepos();
            user.Id= obj.Id;
            user.Nom = obj.Nom;
            user.Prenom= obj.Prenom;
            user.Compte = obj.Compte;
            user.MotPasse = obj.MotPasse;
            

            repos.Create(user);
            
        }
        public Utilisateur Trouver(String compte,String mdp)
        {
            var repos = new UtilisateurRepos();
            Utilisateur user = repos.All().Where(a =>  a.Compte == compte && a.MotPasse==mdp).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            

            return user;
        }
    }
}

using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UtilisateurRepos
    {
        public List<Utilisateur> All()
        {
            MonDbContext dbContext = new MonDbContext();
            return dbContext.Utilisateurs.ToList();
        }
        public void Create(Utilisateur c)
        {
            MonDbContext db = new MonDbContext();
            db.Utilisateurs.Add(c);
            db.SaveChanges();

        }
        public Utilisateur Read(int id)
        {
            MonDbContext dbContext = new MonDbContext();
            return dbContext.Utilisateurs.Find(id);
        }
    }
}

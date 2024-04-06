using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    public class MembreRepos
    {
        public void Create(Membre m)
        {
            MonDbContext db = new MonDbContext();
            db.Membres.Add(m);
            db.SaveChanges();
            
        }
        
        public Membre Read(int id)
        {
            MonDbContext db = new MonDbContext();
            return db.Membres.Find(id);
        }
        public void Delete(int id)
        {
            MonDbContext db = new MonDbContext();
            Membre membre = Read(id);
            db.Membres.Remove(membre);
            db.SaveChanges();
        }
        public void Update(Membre m)
        {
            MonDbContext db=new MonDbContext();
            db.Membres.Update(m);
                db.SaveChanges();
        }
        public List<Membre> GetAll()
        {
            MonDbContext db = new MonDbContext();
            return db.Membres.ToList();
        }
        public int nbrMembre()
        {
            MonDbContext db = new MonDbContext();
            return db.Membres.Count();

        }

    }
}

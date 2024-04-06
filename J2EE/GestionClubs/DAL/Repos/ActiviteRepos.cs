using DAL.Entity;

namespace DAL.Repos
{
    public class ActiviteRepos
    {
        public void Create(Activite a)
        {
            MonDbContext db = new MonDbContext();
            db.Activites.Add(a);
            db.SaveChanges();
        }
        public Activite Read(int id)
        {
            MonDbContext db = new MonDbContext();
            return db.Activites.Find(id);
        }
        public void Delete(int idActivite)
        {
            MonDbContext db=new MonDbContext();
            Activite activite = Read(idActivite);
            db.Activites.Remove(activite);
            db.SaveChanges();
        }
        public void Update(Activite a)
        {
            MonDbContext db = new MonDbContext();
            db.Activites.Update(a);
            db.SaveChanges();
        }
        public List<Activite> GetAll()
        {
            MonDbContext db = new MonDbContext();
            return db.Activites.ToList();
        }
        public int CountActivite()
        {
            MonDbContext db = new MonDbContext();
            return db.Activites.Count();
        }

    }
}

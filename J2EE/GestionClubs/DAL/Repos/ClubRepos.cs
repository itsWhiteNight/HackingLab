using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    public class ClubRepos
    {
        public void Create(Club c)
        {
            MonDbContext db= new MonDbContext();
            db.Clubs.Add(c);
            db.SaveChanges();

        }
        public Club Read(int id)
        {
            MonDbContext db = new MonDbContext();
            return db.Clubs.Find(id);
        }
        public void Delete(int id)
        {
            MonDbContext db = new MonDbContext();
            Club club=Read(id);
            if(club!= null)
            {
                var membre=db.Membres.Where(c=>c.Id==id).ToList();
                foreach(var mem in membre)
                {
                    db.Membres.Remove(mem);
                }
                var activite = db.Activites.Where(c => c.Id == id).ToList();
                foreach (var act in activite)
                {
                    db.Activites.Remove(act);
                }
            }
            
            db.Clubs.Remove(club);
            db.SaveChanges();

           
        }
        public void Update(Club club)
        {
            MonDbContext db = new MonDbContext();
            db.Clubs.Update(club);
            db.SaveChanges();
        }

        public List<Club> GetAll()
        {
            MonDbContext db = new MonDbContext();
            return db.Clubs.ToList();
        }
        public int CountClub()
        {
            MonDbContext db=new MonDbContext();
            return db.Clubs.Count();
        }
        
    }
}

using Microsoft.AspNetCore.Mvc;
using BLL;
using Models.Membres;
using Models.Club;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using GestionClub.Controllers;

namespace GestionClubs.Controllers
{
    [Authorize]
    public class MembreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult listClub()
        {
            
            ClubService clubService = new ClubService();

            ViewBag.IdClub = clubService.ListeClub();

            

                return View();

            
        }
        public IActionResult list(int id)
        {
            MembreService membreService = new MembreService();
            
            
            if(id !=0)
            {
                ViewBag.nbrMembre = membreService.nbrMembre();
                return View(membreService.MembreParClub(id));

            }
            
                
            
            else
            {
                return View(null);
            }
        }

        public ActionResult Create()
        {
            ClubService clubService = new ClubService();
           
            ViewData["Titre"] = "Creation de membre";

            ViewBag.IdClub = clubService.ListeClub();
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MembreVM model)
        {
            ClubController club=new ClubController();

            try
            {
                MembreService service = new MembreService();
                service.Ajouter(model);
                return RedirectToAction("list", "Club");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            MembreService membreService = new MembreService();
            
            ViewData["Titre"] = "Supression d'un membre";
           
            membreService.Supprimer(id);
            return RedirectToAction("list", "Club");
        }
        public ActionResult Edit(int id)
        {
            MembreService membreService = new MembreService();
            ClubService club=new ClubService();

            ViewBag.IdClub=club.ListeClub();
            ViewData["Titre"] = "Modifier un membre";


            MembreVM memb = membreService.Trouver(id);
            

            return View(memb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MembreVM membre)
        {
            try
            {
                ClubService club = new ClubService();

                ViewBag.IdClub = club.ListeClub();
                MembreService service = new MembreService();
                service.Modifier(membre);
                return RedirectToAction("list", "Club");
            }
            catch
            {
                return View(nameof(Edit), membre);
            }
        }











    }
}
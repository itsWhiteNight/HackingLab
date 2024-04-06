using BLL;
using Microsoft.AspNetCore.Mvc;
using Models.Club;
using Models.Membres;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;

namespace GestionClub.Controllers
{
    [Authorize]
    
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult list()
        {
            ClubService clubService = new ClubService();

            ViewBag.nombreClub = clubService.NbrClubs();
                return View(clubService.ListeClub());

        }
        public ActionResult Create()
        {

            ViewData["Titre"] = "Creation de Club";


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClubVM model)
        {
            


            try
            {
                ClubService service = new ClubService();
                service.Ajouter(model);
                return RedirectToAction(nameof(list));
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Delete(int id)
        {
            ClubService clubService = new ClubService();

            ViewData["Titre"] = "Supression de club";
            clubService.Supprimer(id);
            return RedirectToAction(nameof(list));
        }
        
        
        public ActionResult Edit(int id)
        {
            ClubService clubService = new ClubService();

            ViewData["Titre"] = "Modifier un club";

           
            ClubVM club = clubService.Trouver(id);

            TempData["Id"] = id;
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClubVM club)
        {
            try
            {
                club.Id = (int)TempData["Id"];
                ClubService service = new ClubService();
                service.Modifier(club);
                return RedirectToAction(nameof(list));
            }
            catch
            {
                return View(nameof(Edit), club);
            }
        }




    }
}

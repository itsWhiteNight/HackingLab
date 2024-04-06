using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Activites;
using Models.Membres;

namespace GestionClub.Controllers
{
    [Authorize]
    public class ActiviteController : Controller
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
            ActiviteService activiteService = new ActiviteService();
            ClubService clubService = new ClubService();

            ViewBag.Clubs = clubService.ListeClub();

            if (id != 0)
            {
                ViewBag.nbrActivite = activiteService.nbrActivite();
                return View(activiteService.ActiviteParClub(id));
            }

                

            else
            {
                return View(null);
            }
        }
        public ActionResult Create()
        {
            ClubService clubService = new ClubService();

            ViewData["Titre"] = "Creation d'activites";

            ViewBag.IdClub = clubService.ListeClub();


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActiviteVM model)
        {


            try
            {
                ActiviteService service = new ActiviteService();
                service.Ajouter(model);
                return RedirectToAction("list","Club");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            ActiviteService activiteService = new ActiviteService();

            ViewData["Titre"] = "Supression d'une activité";
            activiteService.Supprimer(id);
            return RedirectToAction("list", "Club");
        }
        public ActionResult Edit(int id)
        {
            ActiviteService activiteService = new ActiviteService();
            ClubService club = new ClubService();

            ViewBag.IdClub = club.ListeClub();
            ViewData["Titre"] = "Modifier une activité";


            ActiviteVM act = activiteService.Trouver(id);


            return View(act);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ActiviteVM activite)
        {
            try
            {
                ClubService club = new ClubService();

                ViewBag.IdClub = club.ListeClub();
                ActiviteService service = new ActiviteService();
                service.Modifier(activite);
                return RedirectToAction("list", "Club");
            }
            catch
            {
                return View(nameof(Edit), activite);
            }
        }


    }
}

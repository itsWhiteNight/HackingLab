using BLL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Models.Authentification;
using System.Security.Claims;
using Models.Club;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestionClub.Controllers
{
    
    public class AuthController : Controller
    {
        
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Club");
            return View();
        }


        [HttpPost]
        public IActionResult Index(UserAuthVM model)
        {
            UtilisateurService utilisateurService = new UtilisateurService();
            var us = utilisateurService.VerifierCompte(model);

            if (us != null)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.Email, us.AdresseMail),
                    new Claim("Societe","EMSI"),
                    new Claim(ClaimTypes.Name, us.Nom),
                    new Claim(ClaimTypes.NameIdentifier, us.Id.ToString()),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                    
                };
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Club");
            }

            

            ViewData["ValidateMessage"] = "user not found";
            return View();
        }
        public ActionResult Create()
        {

            ViewData["Titre"] = "Creation d'un administrateur";


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UtilisateurVM model)
        {


            try
            {
                UtilisateurService service = new UtilisateurService();
                service.Ajouter(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Logout()
        {
            // Déconnexion de l'utilisateur
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirection vers une page après la déconnexion (par exemple, la page d'accueil)
            return RedirectToAction("Index", "Auth");
        }

    }
}

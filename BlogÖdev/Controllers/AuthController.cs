using BlogÖdev.Models.Data;
using BlogÖdev.Models.Entities;
using BlogÖdev.ViewModels.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogÖdev.Controllers
{
    public class AuthController : Controller
    {
        private readonly DatabaseContext _context;

        public AuthController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login(string yonlen)
        {
            ViewBag.yonlen = yonlen;
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login(LoginViewModel model, string yonlen)
        {
            if(ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.Username.Equals(model.Username) && x.Password.Equals(model.Password));
                if (user is not null)
                {
                    HttpContext.Session.SetString("userId", user.Id.ToString());
                    HttpContext.Session.SetString("username", user.Username);
                    if (string.IsNullOrEmpty(yonlen))
                        return RedirectToAction("Index", "Home");
                    else
                        return RedirectToAction(yonlen);
                }
                else
                    ModelState.AddModelError("", "No such user was found!");
            }
            return View();

        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login", "Auth");
        }
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                if(!_context.Users.Any(x => x.Username.Equals(user.Username)))
                {
                    var newUser = new User(user.Username, user.Password);
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                    TempData["message"] = "Successfully registered..!";
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    ModelState.AddModelError("", "Such a user already exists..!");
                }
                
            }
            return View();
        }


    }
}

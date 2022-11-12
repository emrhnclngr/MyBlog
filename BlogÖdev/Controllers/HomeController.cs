using BlogÖdev.Filters;
using BlogÖdev.Models;
using BlogÖdev.Models.Data;
using BlogÖdev.ViewModels.Article;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogÖdev.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Articles
                .OrderByDescending(x => x.CreatedTime)
                .Take(20)
                .Select(x => new ArticleViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    AuthorName = x.Author.Username,
                    AuthorId = x.AuthorId.ToString(),
                    ArticlePicture = string.IsNullOrEmpty(x.ArticlePicture) ? "null.png" : x.ArticlePicture,
                    Content = x.Content,
                    CreatedTime = x.CreatedTime
                }).ToList();
            return View(list);
        }
        [LoggedUser]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [LoggedUser]
        public IActionResult Profile(int id)
        {
            //var user = _context.Articles.FirstOrDefault(I => I.Id == id && I.AuthorId.ToString().Equals(HttpContext.Session.GetString("userId")));
            //if (user is not null)
            //{
            //    ViewData["error"] = "User not found!";
            //    return View();
            //}

            var list = _context.Articles
                .OrderByDescending(x => x.CreatedTime)
                .Take(20)
                .Select(x => new ArticleViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    AuthorName = x.Author.Username,
                    AuthorId = x.AuthorId.ToString(),
                    ArticlePicture = string.IsNullOrEmpty(x.ArticlePicture) ? "null.png" : x.ArticlePicture,
                    Content = x.Content,
                    CreatedTime = x.CreatedTime
                }).ToList();
            return View(list);

        }
        public IActionResult Overview(int id)
        {
            var list = _context.Articles.Where(x => x.Id == id)
                .Select(x => new ArticleViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    AuthorName = x.Author.Username,
                    AuthorId = x.AuthorId.ToString(),
                    ArticlePicture = string.IsNullOrEmpty(x.ArticlePicture) ? "null.png" : x.ArticlePicture,
                    Content = x.Content,
                    CreatedTime = x.CreatedTime
                }).ToList();
            return View(list);
        }
    }
}

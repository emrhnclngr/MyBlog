using BlogÖdev.Filters;
using BlogÖdev.Managers;
using BlogÖdev.Models.Data;
using BlogÖdev.Models.Entities;
using BlogÖdev.ViewModels.Article;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace BlogÖdev.Controllers
{
    [LoggedUser]
    public class ArticleController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArticleController(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Create(string yonlen)
        {
            ViewBag.yonlen = yonlen;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateViewModel model, string yonlen)
        {
            if(ModelState.IsValid)
            {
                var article = new Article()
                {
                    Title = model.Title,
                    Content = model.Content,
                    AuthorId = int.Parse(HttpContext.Session.GetString("userId")),
                    ArticlePicture = model.ArticlePicture.GetUniqueNameAndSavePhotoToDisk(_webHostEnvironment)
                };
                _context.Articles.Add(article);
                _context.SaveChanges();
                TempData["message"] = "Article Created.";
                return Redirect(yonlen);
            }
            else return View(model);

        }
        
        public IActionResult Delete (int id)
        {
            var sil = _context.Articles.Find(id);
            _context.Articles.Remove(sil);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var updatedArticle = _context.Articles.FirstOrDefault(I => I.Id == id && I.AuthorId.ToString().Equals(HttpContext.Session.GetString("userId")));
            var model = new UpdateViewModel()
            {
                Id = updatedArticle.Id,
                Title = updatedArticle.Title,
                Content = updatedArticle.Content,
                ArticlePicture = updatedArticle.ArticlePicture
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(UpdateViewModel updateViewModel)
        {
            Article article = _context.Articles.FirstOrDefault(I => I.Id == updateViewModel.Id && I.AuthorId.ToString().Equals(HttpContext.Session.GetString("userId")));

            if(article is null)
            {
                ViewData["error"] = "Edit Failed";
                return View();
            }

            article.Title = updateViewModel.Title;
            article.Content = updateViewModel.Content;

            if(updateViewModel.NewImage is not null)
            {
                article.ArticlePicture = updateViewModel.NewImage.GetUniqueNameAndSavePhotoToDisk(_webHostEnvironment);
                FileManager.RemoveImageFromDisk(updateViewModel.ArticlePicture, _webHostEnvironment);
            }

            //article = updateViewModel.ArticlePicture;
            //article.Id = updateViewModel.Id;
            //_context.Articles.Update(article);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
       

    }
}

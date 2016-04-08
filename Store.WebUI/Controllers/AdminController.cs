using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Abstract;
using Store.Domain.Entities;

namespace Store.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IWareRepository repository;

        public AdminController(IWareRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Wares);
        }
        public ViewResult Edit(int wareId)
        {
            Ware ware = repository.Wares
                .FirstOrDefault(g => g.WareId == wareId);
            return View(ware);
        }
        [HttpPost]
        public ActionResult Edit(Ware ware, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    ware.ImageMimeType = image.ContentType;
                    ware.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(ware.ImageData, 0, image.ContentLength);
                }
                repository.SaveWare(ware);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", ware.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(ware);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Ware());
        }
        [HttpPost]
        public ActionResult Delete(int wareId)
        {
            Ware deletedGame = repository.DeleteWare(wareId);
            if (deletedGame != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" был удален",
                    deletedGame.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
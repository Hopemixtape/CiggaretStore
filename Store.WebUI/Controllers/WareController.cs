using System.Linq;
using System.Web.Mvc;
using Store.Domain.Abstract;
using Store.Domain.Entities;
using Store.WebUI.Models;

namespace Store.WebUI.Controllers
{
    public class WareController : Controller
    {
        private IWareRepository repository;
        public int pageSize = 4;

        public WareController(IWareRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category,int page = 1)
        {
            WaresListViewModel model = new WaresListViewModel
            {
                Wares = repository.Wares
            .Where(p => category == null || p.Category == category)
            .OrderBy(ware => ware.WareId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
        repository.Wares.Count() :
        repository.Wares.Where(game => game.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
        public FileContentResult GetImage(int wareId)
        {
            Ware ware = repository.Wares
                .FirstOrDefault(g => g.WareId == wareId);

            if (ware != null)
            {
                return File(ware.ImageData, ware.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
    

using Microsoft.AspNetCore.Mvc;
using TravelUp.Data;
using TravelUp.Models;

namespace TravelUp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ActionResult List()
        {
            var items = _itemRepository.GetAllItems();
            return View(items);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _itemRepository.AddItem(item);
                return RedirectToAction("List");
            }
            return View(item);
        }
    }
}

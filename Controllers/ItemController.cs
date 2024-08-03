using System.Collections.Generic;
using AJAX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAX.Controllers
{
    public class ItemController : Controller
    {
        private static List<Item> items = new List<Item>();

        [HttpGet]
        public ActionResult Index()
        {
            return View(items);
        }

        [HttpPost]
        public JsonResult AddItem(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Json(new { success = false, message = "Item name cannot be empty." });
            }

            var newItem = new Item { Id = items.Count + 1, Name = name };
            items.Add(newItem);

            return Json(new { success = true, item = newItem });
        }
    }
}

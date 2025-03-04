using System.Linq;
using System.Net;
using System.Web.Mvc;
using BakeryApp.Models;

namespace BakeryApp.Controllers
{
    public class BakeryItemsController : Controller
    {
        private BakeryDBEntities1 db = new BakeryDBEntities1();

        public ActionResult Index()
        {
            var bakeryItems = db.BakeryItems.ToList();
            return View(bakeryItems);
        }
    }
}

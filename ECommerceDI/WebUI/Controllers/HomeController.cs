using System.Web.Mvc;
using DomainLogic;
using SqlDataAccess;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var isPreferredCustomer =
                User.IsInRole("PreferredCustomer");
            var service = new ProductService();
            var products =
                service.GetFeaturedProducts(isPreferredCustomer);
            ViewData["Products"] = products;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
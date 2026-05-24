using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Headings()
        {

            var headinglist = hm.GetList();
            ViewBag.ContentList = hm.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id= 0 )
        {
            var contentlist =cm.GetList();
            return PartialView(contentlist);
        }
    }
}

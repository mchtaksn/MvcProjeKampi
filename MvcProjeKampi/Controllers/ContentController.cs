using BusinessLayer.Concrete;
using DataAccessLayer.Contrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {

        ContentManager cm = new ContentManager(new EFContentDal());

        public IActionResult Index()
        {
            //Context c = new Context();
            //var headingvalues = c.Contents.Include(x => x.WriterID).ToList();
            return View();

        }
        public ActionResult ContentByHeading(int id)
        {
            //Context c = new Context();
            //var contentvalues = c.Contents.Include(x => x.Writer)
            //    .Where(x => x.HeadingID==id).ToList();
            //return View(contentvalues);

            var contentvalues = cm.GetListByID(id);
            return View(contentvalues);
        }
    }
}

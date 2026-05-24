using BusinessLayer.Concrete;
using DataAccessLayer.Contrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Conctete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        Context c = new Context();
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDAl());
        public IActionResult WriterProfile(int id=0)
        {
            string   p = HttpContext.Session.GetString("WriterMail");
            id= c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.a = id;
            var writervalue=wm.GetByID(id);
            return View(writervalue);
        }
        public ActionResult MyHeading()
        {
           
            //id = 4;
            string p = HttpContext.Session.GetString("WriterMail");
            var writeridinfo = c.Writers.Where(x=>x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
            
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            
            List<SelectListItem> valuescategory = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.vlc = valuescategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string d = HttpContext.Session.GetString("WriterMail");
            var writeridinfo = c.Writers.Where(x => x.WriterMail == d).Select(y => y.WriterID).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

            p.WriterID = writeridinfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
           
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valuescategory = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.vlc = valuescategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteWriter(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading()
        {
            var headings = hm.GetList();
            return View(headings);
        }
        
    }
}

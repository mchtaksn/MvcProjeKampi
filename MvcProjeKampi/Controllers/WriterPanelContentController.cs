using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataAccessLayer.Contrete;
using EntityLayer.Conctete;
namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {

        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        public IActionResult MyContent()
        {
            
            string p = HttpContext.Session.GetString("WriterMail");
            var writeridinfo = c.Writers.Where(x=>x.WriterMail == p).Select(y=>y.WriterID).FirstOrDefault();
            //ViewBag.d = p;
            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = HttpContext.Session.GetString("WriterMail");
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate= DateTime.Parse (DateTime.Now.ToShortDateString());
            p.ContentStatus = true;
            p.WriterID = writeridinfo;
             cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }

}

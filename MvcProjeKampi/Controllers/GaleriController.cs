using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GaleriController : Controller
    {
        ImageFileManager ifm = new ImageFileManager(new EFImageFileDal());
        public IActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.viewcompenents
{
    public class MessageeListMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

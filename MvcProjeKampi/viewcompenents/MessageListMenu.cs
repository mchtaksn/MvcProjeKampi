using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampi.viewcompenents
{
    public class MessageListMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

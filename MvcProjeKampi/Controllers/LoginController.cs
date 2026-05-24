using DataAccessLayer.Contrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using EntityLayer.Conctete;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
            public async Task<IActionResult> Index(Admin admin) 
        {
            Context c = new Context();
            var adminuser =c.Admins.FirstOrDefault(x=>x.AdminUserName == admin.AdminUserName && x.AdminPassword==admin.AdminPassword);
            if (adminuser !=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, adminuser.AdminUserName),
                    new Claim(ClaimTypes.Role,adminuser.AdminRole)
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Heading");
            }

            return View();

        }
        
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> WriterLogin(Writer writer)
        {
            Context c = new Context();
            var writerinfo = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPasword == writer.WriterPasword);
            if (writerinfo != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, writerinfo.WriterMail),
                    //new Claim(ClaimTypes.Role,adminuser.AdminRole)
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("MyContent", "WriterPanelContent");
            }

            return RedirectToAction("WriterLogin");
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("WriterLogin", "Login");
        }
    }
}

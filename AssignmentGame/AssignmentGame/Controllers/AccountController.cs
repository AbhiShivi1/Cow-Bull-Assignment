using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AssignmentGame.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            GameController.counter = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new AccountEntities())
            {
                bool isValid = context.User.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("CowAndBull", "Game");
                }

                ModelState.AddModelError("", "Invalid username and password");
                return View();

            }

        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (var context = new AccountEntities())
            {
                context.User.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
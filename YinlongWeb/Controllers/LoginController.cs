using Microsoft.AspNetCore.Mvc;
using YinlongWeb.Models;
using YinlongWeb.Services;

namespace YinlongWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            SecurityService ss = new SecurityService();
            if (ss.isValid(userModel))
            {
                return View("LoginSuccess", userModel);
            }
            else
            {
                return View("LoginFail", userModel);
            }
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ProcessRegister(UserModel users)
        {
            Userdao userobj = new Userdao();
            userobj.Insert(users);
            return View("Index");
        }

    }
}

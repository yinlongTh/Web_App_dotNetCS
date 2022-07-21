using Microsoft.AspNetCore.Mvc;
using YinlongWeb.Models;
using YinlongWeb.Services;

namespace YinlongWeb.Controllers
{
    public class meController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SkillDetail()
        {
            SkillDAO skills = new SkillDAO();
            List<SkillModel> allskill = skills.GetAllSkills();
            return View("Skill",allskill);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using YinlongWeb.Models;
using YinlongWeb.Services;

namespace YinlongWeb.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            TeamDAO teamDAO = new TeamDAO();
            return View(teamDAO.GetAllMembers());
        }

        public IActionResult ShowDetails(int id)
        {
            TeamDAO member = new TeamDAO();
            TeamModel foundMember = member.GetMemberById(id);
            return View("ShowDetails",foundMember);
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using YinlongWeb.Models;
using YinlongWeb.Services;

namespace YinlongWeb.Controllers
{
    [ApiController]
    [Route("api1/")]

    public class TeamControllerAPI : ControllerBase
    {
        TeamDAO repository;

        public TeamControllerAPI()
        {
            repository = new TeamDAO();

        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamModel>> Index()
        {
            return repository.GetAllMembers();
        }

    }
}

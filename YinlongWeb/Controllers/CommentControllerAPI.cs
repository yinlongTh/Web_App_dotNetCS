using Microsoft.AspNetCore.Mvc;
using YinlongWeb.Models;
using YinlongWeb.Services;

namespace YinlongWeb.Controllers
{
    [ApiController]
    [Route("api/")]

    public class CommentControllerAPI : ControllerBase
    {
        CommentDAO repository;

        public CommentControllerAPI()
        {
            repository = new CommentDAO();
        
        }


        [HttpGet]
        public ActionResult<IEnumerable<CommentModel>> Index()
        {
            return repository.GetAllComments();
        }

    }
}

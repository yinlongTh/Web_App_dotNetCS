using Microsoft.AspNetCore.Mvc;
using YinlongWeb.Models;
using YinlongWeb.Services;

namespace YinlongWeb.Controllers
{
    public class CommentController : Controller
    {

        public IActionResult Index()
        {
            CommentDAO comments = new CommentDAO();
            return View(comments.GetAllComments());
        }

        public IActionResult Create()
        {
            return View("CommentForm");
        }

        public IActionResult ProcessCreate(CommentModel comments)
        {
            CommentDAO commentobj = new CommentDAO();
            commentobj.Insert(comments);
            return View("Index",commentobj.GetAllComments());

        }





    }
}

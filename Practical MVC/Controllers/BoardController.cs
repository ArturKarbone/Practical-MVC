using Microsoft.AspNetCore.Mvc;
using WebApplication5.Services;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class BoardController : Controller
    {
        private readonly BoardService service;
        public BoardController(BoardService service)
        {
            this.service = service;
        }
        public IActionResult Index(int id)
        {
            return View(service.GetBoard(id));
        }

        public IActionResult AddCard(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCard(AddCard model)
        {
            if (ModelState.IsValid)
            {
                service.AddCard(model);
                return RedirectToAction(nameof(Index), new {Id = model.BoardId});
            }
            else
            {
                return View(model);
            }
        }
    }
}
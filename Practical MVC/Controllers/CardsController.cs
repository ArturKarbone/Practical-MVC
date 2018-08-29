using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practical_MVC.ViewModels;
using WebApplication5.Services;

namespace Practical_MVC.Controllers
{
    public class CardsController : Controller
    {
        private readonly BoardService boardsService;
        public CardsController(BoardService boardsService)
        {
            this.boardsService = boardsService ?? throw new ArgumentNullException($"{nameof(boardsService)} is null");
        }
        public IActionResult Details(int id)
        {
            return View(boardsService.GetCard(id));
        }

        [HttpPost]
        public IActionResult Update(CardDetails model)
        {
            if (ModelState.IsValid)
            {
                boardsService.UpdateCard(model);
                TempData["Message"] = "Card has been saved";
                return RedirectToAction(nameof(Details), new { Id = model.Id });
            }
            else
            {
                return View("Details", model);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Services;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly Services.BoardService service;

        public HomeController(BoardService service)
        {
            this.service = service ?? throw new ArgumentNullException($"{nameof(service)} is null");
        }

        public IActionResult Index()
        {
            var boardList = service.ListBoards();

            return View(boardList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewBoard board)
        {
            service.Add(board);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
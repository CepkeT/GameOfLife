using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly GameOfLife _game;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _game = new GameOfLife();
    }

    public IActionResult Index()
    {
        return View(_game.GetBoard());
    }

    public IActionResult UpdateBoard()
    {
        _game.UpdateBoard();
        return PartialView("_GameBoard", _game.GetBoard());
    }
}

using GamersParadise.DataAccess.Repository.IRepository;
using GamersParadise.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamersParadise.Areas.Admin.Controllers;

public class GameController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public GameController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Game> gameList = _unitOfWork.Game.GetAll().ToList();
        return View(gameList);
    }
}
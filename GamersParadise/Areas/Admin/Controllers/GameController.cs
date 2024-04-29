using GamersParadise.DataAccess.Repository.IRepository;
using GamersParadise.Models.Models;
using GamersParadise.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamersParadise.Areas.Admin.Controllers;
[Area("Admin")]
public class GameController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public GameController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        List<Game> gameList = _unitOfWork.Game.GetAll(includeProperties: "Genre").ToList();
        return View(gameList);
    }

    //public IActionResult Upsert(int? gameId)
    //{
    //    IEnumerable<SelectListItem> genreList = _unitOfWork.Genre.GetAll().Select(g => new SelectListItem
    //    {
    //        Text = g.Name,
    //        Value = g.Id.ToString()
    //    });
    //    GameViewModel gameViewModel = new GameViewModel()
    //    {
    //        Game = new Game(),
    //        GenreList = genreList
    //    };
    //    if (gameId == 0 || gameId == null)
    //    {
    //        return View(gameViewModel);
    //    }
    //    else
    //    {
    //        gameViewModel.Game = _unitOfWork.Game.Get(g => g.Id == gameId);
    //        return View(gameViewModel);
    //    }
    //}

    //[HttpPost]
    //public IActionResult Upsert(GameViewModel gameViewModel, IFormFile file)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        string wwwRootPath = _webHostEnvironment.WebRootPath;
    //        if (file != null)
    //        {
    //            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
    //            string gamePath = Path.Combine(wwwRootPath, "images", "game");

    //            Directory.CreateDirectory(gamePath);

    //            string filePath = Path.Combine(gamePath, fileName);

    //            if (!string.IsNullOrEmpty(gameViewModel.Game.ImageUrl))
    //            {
    //                var oldImagePath = Path.Combine(wwwRootPath, gameViewModel.Game.ImageUrl.TrimStart('\\'));
    //                if (System.IO.File.Exists(oldImagePath))
    //                {
    //                    System.IO.File.Delete(oldImagePath);
    //                }
    //            }

    //            using (var fileStream = new FileStream(filePath, FileMode.Create))
    //            {
    //                file.CopyTo(fileStream);
    //            }

    //            gameViewModel.Game.ImageUrl = Path.Combine("images", "game", fileName);
    //        }
    //        else
    //        {
    //            gameViewModel.Game.ImageUrl = Path.Combine("images", "default.jpg");
    //        }

    //        if (gameViewModel.Game.Id == 0)
    //        {
    //            _unitOfWork.Game.Add(gameViewModel.Game);
    //        }
    //        else
    //        {
    //            _unitOfWork.Game.Update(gameViewModel.Game);
    //        }

    //        _unitOfWork.Save();
    //        TempData["success"] = "Game saved successfully";
    //        return RedirectToAction("Index", "Game");
    //    }
    //    else
    //    {
    //        gameViewModel.GenreList = _unitOfWork.Genre.GetAll().Select(g => new SelectListItem
    //        {
    //            Text = g.Name,
    //            Value = g.Id.ToString()
    //        });
    //    }

    //    return View();
    //}

    public IActionResult Upsert(int? id)
    {
        IEnumerable<SelectListItem> genreList = _unitOfWork.Genre.GetAll().Select(g => new SelectListItem
        {
            Text = g.Name,
            Value = g.Id.ToString()
        });
        //ViewBag.CategoryList = categoryList;
        //ViewData["CategoryList"] = categoryList;
        GameViewModel gameViewModel = new GameViewModel()
        {
            GenreList = genreList,
            Game = new Game()
        };
        if (id == null || id == 0)
        {
            return View(gameViewModel); // Create
        }
        else
        {
            gameViewModel.Game = _unitOfWork.Game.Get(g => g.Id == id);
            return View(gameViewModel);
        }
    }
    [HttpPost]
    public IActionResult Upsert(GameViewModel gameViewModel, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            TempData["success"] = "Game created succesfully";
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string gamePath = Path.Combine(wwwRootPath, @"images\game");
                if (!string.IsNullOrEmpty(gameViewModel.Game.ImageUrl))
                {
                    var oldImagePath = Path.Combine(wwwRootPath, gameViewModel.Game.ImageUrl.Trim('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(gamePath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                gameViewModel.Game.ImageUrl = @"images\game\" + fileName;
            }

            if (gameViewModel.Game.Id == 0)
            {
                _unitOfWork.Game.Add(gameViewModel.Game);
            }
            else
            {
                _unitOfWork.Game.Update(gameViewModel.Game);
            }

            _unitOfWork.Save();
            return RedirectToAction("Index", "Game");
        }
        else
        {
            gameViewModel.GenreList = _unitOfWork.Game.GetAll().Select(c => new SelectListItem
            {
                Text = c.Genre.Name,
                Value = c.Id.ToString()
            });
        }
        return View();
    }

    public IActionResult Delete(int? gameId)
    {
        if (gameId == null || gameId == 0)
        {
            return NotFound();
        }

        Game? game = _unitOfWork.Game.Get(g => g.Id == gameId);
        if (game == null)
        {
            return NotFound();
        }

        return View(game);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? gameId)
    {
        Game? game = _unitOfWork.Game.Get(g => g.Id == gameId);
        if (game == null)
        {
            return NotFound();
        }

        _unitOfWork.Game.Delete(game);
        _unitOfWork.Save();
        TempData["success"] = "Game deleted successfully";
        return RedirectToAction("Index", "Game");
    }
}
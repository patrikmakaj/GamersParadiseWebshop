using GamersParadise.DataAccess.Repository.IRepository;
using GamersParadise.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamersParadise.Areas.Admin.Controllers;

public class GenreController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public GenreController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Genre> genreList = _unitOfWork.Genre.GetAll().ToList();
        return View(genreList);
    }

    public IActionResult Upsert(int? genreId)
    {
        if (genreId == null || genreId == 0)
        {
            return View(new Genre());
        }
        else
        {
            Genre genre = _unitOfWork.Genre.Get(g => g.Id == genreId);
            return View(genre);
        }
    }
    
    [HttpPost]
    public IActionResult Upsert(Genre genre)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Genre.Update(genre);
            _unitOfWork.Save();
            TempData["success"] = "Genre saved successfully";
            return RedirectToAction("Index", "Genre");
        }
        return View(genre);
    }

    
    public IActionResult Delete(int? genreId)
    {
        if (genreId == null || genreId == 0)
        {
            return NotFound();
        }
        Genre genre = _unitOfWork.Genre.Get(c => c.Id == genreId);
        if (genre == null)
        {
            return NotFound();
        }
        return View(genre);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? genreId)
    {
        Genre genre = _unitOfWork.Genre.Get(c => c.Id == genreId);
        if (genre == null)
        {
            return NotFound();
        }
        _unitOfWork.Genre.Delete(genre);
        _unitOfWork.Save();
        TempData["success"] = "Genre deleted successfully";
        return RedirectToAction("Index", "Genre");
    }
}

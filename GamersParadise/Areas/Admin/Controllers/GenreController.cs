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
}
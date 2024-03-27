using GamersParadise.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamersParadise.Models.ViewModels;

public class GameViewModel
{
    public Game Game { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> GenreList { get; set; }
}
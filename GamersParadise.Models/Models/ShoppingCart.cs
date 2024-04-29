using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GamersParadise.Models.Models;

public class ShoppingCart
{
    [Key] public int Id { get; set; }
    public int Count { get; set; }
    public int GameId { get; set; }

    [ForeignKey("GameId")] [ValidateNever] public Game Game { get; set; }

    public string ApplicationUserId { get; set; }

    [ForeignKey("ApplicationUserId")]
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }
}
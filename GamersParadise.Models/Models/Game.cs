using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GamersParadise.Models.Models;

public class Game
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [DisplayName("Description")]
    public string Description { get; set; }

    public int GenreId { get; set; }
    
    [ForeignKey("GenreId")]
    [ValidateNever]
    public Genre Genre { get; set; }
    [ValidateNever]
    public string ImageUrl { get; set; }

    [DisplayName("Platform")]
    public string Platform { get; set; }

    [DisplayName("Publisher")]
    public string Publisher { get; set; }

    [Range(1D, 1000D)]
    public double Price { get; set; }

    [DisplayName("Age Rating")]
    public string AgeRating { get; set; }
}



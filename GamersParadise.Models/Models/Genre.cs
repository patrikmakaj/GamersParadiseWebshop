namespace GamersParadise.Models.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Genre
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1, 30)]
    public int DisplayOrder { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GamersParadise.Models.Models;

public class ApplicationUser : IdentityUser
{
    [Required] public string Name { get; set; }
    public string? StreetAddress { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }

    [ValidateNever]
    [ForeignKey("CompanyId")]
    public Company Company { get; set; }

    public int? CompanyId { get; set; }
}
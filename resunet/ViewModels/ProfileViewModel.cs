using System.ComponentModel.DataAnnotations;

public class ProfileViewModel
{
    [Required]
    public string? ProfileName { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    
}
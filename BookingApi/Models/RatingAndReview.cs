using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace BookingApi.Models;
[Table("Ratings")]
public class RatingAndReview
{
    public int Id { get; set; }
    [Required]
    [Range(1,10)]
    public int Rating { get; set; }
    
    public string Review { get; set; } = string.Empty;
    
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    
    [Required]
    public int PropertyId { get; set; }
    
    [ForeignKey("PropertyId")]
    public Property Property { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models;

[Table("PropertyAmenity")]
public class PropertyAmenity
{
    public int Id { get; set; }
    public string Name { get; set; } =string.Empty;
    public int PropertyAmenId { get; set; }
    [ForeignKey("PropertyAmenId")]
    public Property Property { get; set; }
}
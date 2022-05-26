using System.ComponentModel.DataAnnotations;

namespace gregslistmysql.Models
{
  public class House
  {
    public int Id { get; set; }
    [Required]
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int Levels { get; set; }
    public string ImgUrl { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
  }
}
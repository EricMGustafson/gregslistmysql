using System.ComponentModel.DataAnnotations;

namespace gregslistmysql.Models
{
  public class Car
  {
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string Make { get; set; }
    [Range(0, int.MaxValue)]
    public int Price { get; set; }
    public string Color { get; set; }
    [Url]
    public string ImgUrl { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
  }
}
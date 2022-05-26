using System.ComponentModel.DataAnnotations;

namespace gregslistmysql.Models
{
  public class Job
  {
    public int Id { get; set; }
    [Required]
    public string Company { get; set; }
    public string JobTitle { get; set; }
    public int Hours { get; set; }
    public int Rate { get; set; }
    public string Description { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
  }
}
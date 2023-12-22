using System.ComponentModel.DataAnnotations;

namespace Lab3.Model;

public class Taskk
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public string Tags { get; set; }
}

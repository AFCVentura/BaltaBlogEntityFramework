using System.ComponentModel.DataAnnotations.Schema;

namespace BaltaBlogEF.Models;


[Table("PostTag")]
public class PostTag
{
    public int PostId { get; set; }
    public int TagId { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;


namespace Models;

public class Category
{
    [Key]
    public int IdCategory { get; set; }
    [Required]
    public string? Name { get; set; }

    [JsonIgnore] 
    [IgnoreDataMember]
    public List<Dish>? Dishs { get; set; }

}

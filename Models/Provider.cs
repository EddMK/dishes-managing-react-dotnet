using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;


namespace Models;

public class Provider
{
    [Key]
    public int IdProvider { get; set; }

    public string? Name { get; set; }

    [JsonIgnore] 
    [IgnoreDataMember] 
    public List<Dish>? Dishs { get; set; }
}

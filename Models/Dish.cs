using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{

public class Dish
{
    [Key]
    public int IdDish { get; set; }
    [Required]
    public double Price { get; set; }

    [Required]
    public string? Label { get; set; }


    public Category? Category {get;set;}
    [ForeignKey("Category")]
    public int CategoryId {get;set;}



    public Provider? Provider{ get; set;}
    [ForeignKey("Provider")]
    public int ProviderId {get;set;}


}
}
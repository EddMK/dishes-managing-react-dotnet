namespace Models
{

    public class DishDto
    {
        public int IdDish { get; set; }
        public double Price { get; set; }
        public string? Label { get; set; }
        public int CategoryId {get;set;}
        public int ProviderId {get;set;}
    }
}
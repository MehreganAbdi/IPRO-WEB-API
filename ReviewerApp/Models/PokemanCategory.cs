namespace ReviewerApp.Models
{
    public class PokemanCategory
    {
        public int PokemanId { get; set; }
        public int CategoryId { get; set; }
        public Pokeman Pokeman { get; set; }
        public Category Category { get; set; }
        public ICollection<PokemanCategory> PokemanCategories { get; set; }
    }
}

﻿namespace ReviewerApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PokemanCategory> PokemanCategories { get; set; }
    }
}

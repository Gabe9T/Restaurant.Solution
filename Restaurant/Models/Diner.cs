using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Diner
    {
        public int DinerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specialty { get; set; }
        public int CuisineId {get; set;}
        public Cuisine Cuisine {get; set;}
    }
}
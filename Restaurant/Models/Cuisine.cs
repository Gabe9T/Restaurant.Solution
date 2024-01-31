using System.Collections.Generic;

namespace Restaurant.Models
{
    public class Cuisine
    {
        public int CuisineId { get; set; }
        public string Name { get; set; }
        public List<Diner> Diners {get; set;}
    }
}
using System.Collections.Generic;
using System.ComponentModel;


namespace Restaurant.Models
{
    public class Diner
    {
        public int DinerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specialty { get; set; }
        [DisplayName("Cuisine")]
        public int CuisineId {get; set;}
        public Cuisine Cuisine {get; set;}
    }
}
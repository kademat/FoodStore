using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodStore.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Calories { get; set; }
        public string Category { get; set; }
    }
}

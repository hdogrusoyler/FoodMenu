using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }

        public IEnumerable<FoodMenu> FoodMenus { get; set; }
    }
}

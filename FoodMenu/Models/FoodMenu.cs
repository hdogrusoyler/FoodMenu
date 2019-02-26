using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.Models
{
    public class FoodMenu
    {
        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}

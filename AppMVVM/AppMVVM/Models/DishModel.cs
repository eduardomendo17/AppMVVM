using System;
using System.Collections.Generic;
using System.Text;

namespace AppMVVM.Models
{
    public class DishModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }
        public string Picture { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Item
    {
        public int ItemId { set; get; }
        public String Name { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
        public string UrlImg { set; get; }                        

        public Item()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class ItemHolder
    {
        public int Id { set; get; }
        public int Count { set; get; }        
        public double AmountPrice { set; get; }   
        public int IdItem { set; get; }
        public Item Item { set; get; }

        public ItemHolder()
        {
          
        }
    }
}

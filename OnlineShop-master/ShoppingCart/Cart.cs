using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Cart
    {
        public int Id { set; get; }        
        public virtual ICollection<Item> ItemC { set; get; }
    }
}

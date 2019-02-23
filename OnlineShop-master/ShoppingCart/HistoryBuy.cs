using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class HistoryBuy
    {
        public int Id { set; get; }
        public int Count { set; get; }
        public double AmountPrice { set; get; }
        public string NameItem { set; get; }
        public DateTime DateTime { set; get; }
    }
}

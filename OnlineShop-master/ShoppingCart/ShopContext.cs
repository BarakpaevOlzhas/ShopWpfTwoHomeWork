namespace ShoppingCart
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
        }
        public DbSet<User> Users { set; get; }
        public DbSet<Item> Items { set; get; }        
        public DbSet<ItemHolder> ItemHolder { set; get; }
        public DbSet<HistoryBuy> HistoryBuy { set; get; }
    }
}
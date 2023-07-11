using Microsoft.EntityFrameworkCore;
using backend_asp.Models;
using MySql.EntityFrameworkCore.Extensions;


namespace backend_asp.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }
        public DbSet<Order>? Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=StockMarket;Uid=root;Pwd=root;", new MySqlServerVersion(new Version(8, 0, 21)));
            }
        }
    }
}

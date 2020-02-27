using System;
using Microsoft.EntityFrameworkCore;

namespace RayhanASPRestTest.Models
{
    public class OnlineOrderContext : DbContext
    {
        public OnlineOrderContext(DbContextOptions<OnlineOrderContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Order_items { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=ec2-54-197-34-207.compute-1.amazonaws.com;Database=d4t8neenkhvc5g;Username=tcxqjywttjcxgt;Password=d7199f399cfb12c1a5337293033d2fbe05fa5c8360f847d914cca6da511abea3; SSL Mode=Require;Trust Server Certificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<OrderItem>()
                .HasOne(p => p.Order)
                .WithMany(p => p.Order_detail)
                .HasForeignKey(p => p.Order_id);

            modelBuilder
                .Entity<OrderItem>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.Product_id);

            modelBuilder
                .Entity<Order>()
                .HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.User_id);

            modelBuilder
                .Entity<Order>()
                .HasOne(x => x.Driver)
                .WithMany()
                .HasForeignKey(x => x.Driver_id);

            modelBuilder
                .Entity<Order>()
                .HasMany(x => x.Order_detail);
        }
    }
}

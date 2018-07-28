using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IMS_2018_07_25.Models;

namespace IMS_2018_07_25.DAL
{
    public class InventoryContext:DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Markup> Markups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Markup>()
                .HasKey(m => new {m.ItemId, m.PricingId});

            modelBuilder.Entity<Inventory>()
                .HasKey(m => new { m.ItemId, m.LocationId});
        }
    }
}
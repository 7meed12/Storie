
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasOne(p => p.ProductBrand).WithMany()
        //        .HasForeignKey(p => p.ProductBrandId);
        //    modelBuilder.Entity<Product>().HasOne(p=>p.ProductType).WithMany().
        //        HasForeignKey(p => p.ProductTypeId);

        //}
        //public List<Product> SeedTestData()
        //{
        //    var tests = new List<Product>();
        //    using (StreamReader r = new StreamReader(@"../Infrastructure/Data/SeedData/products.json"))
        //    {
        //        string json = r.ReadToEnd();
        //        tests = JsonConvert.DeserializeObject<List<Product>>(json);
        //    }
        //    return tests;
        //}
    }
}
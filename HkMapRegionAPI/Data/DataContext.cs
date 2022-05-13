using GeoJSONAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoJSONAPI.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<GeoObject> GeoObjects { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<GeoObject>().HasKey(a => a.features.Select(b =>b.properties.OBJECTID)).HasName("PK_IGeoComModels");
        //}
    }
}

using Microsoft.EntityFrameworkCore;
using ToDoListQL.Models;

namespace ToDoQl.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<ItemData> Items { get; set; }
    public DbSet<ItemList> Lists { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ItemData>(entity =>
        {
            entity.HasOne(d => d.ItemList)
            .WithMany(l => l.ItemDatas)
            .HasForeignKey(d => d.ListId)
            .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
using Microsoft.EntityFrameworkCore;
using System;
namespace DocumentaryManagementWebApi.DataLayer.Models
{
    public class DocumentaryDbContext : DbContext
    {
        public DocumentaryDbContext(DbContextOptions<DocumentaryDbContext> options) : base(options)
        {
        }

        public DbSet<ActorModel> Actors { get; set; }
        public DbSet<DocumentaryModel> Documentaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorModel>().ToTable("Actors");
            modelBuilder.Entity<DocumentaryModel>().ToTable("Docuemntaries");
        }
    }
}
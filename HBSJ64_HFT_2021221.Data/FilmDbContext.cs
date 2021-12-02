using HBSJ64_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HBSJ64_HFT_2021221.Data
{
    public class FilmDbContext : DbContext
    {
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public FilmDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasOne(film => film.Actor).WithMany(actor => actor.Films).HasForeignKey(film => film.ActorId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasOne(film => film.Director).WithMany(director => director.Films).HasForeignKey(film => film.DirectorId).OnDelete(DeleteBehavior.Cascade);
            });

            Director d1 = new Director() { DirectorId = 1, Name = "Danny Boyle", Age = 64, Award = 20 };
            Director d2 = new Director() { DirectorId = 2, Name = "George Lucas", Age = 77, Award = 60 };
            Director d3 = new Director() { DirectorId = 3, Name = "Denis Villeneuve", Age = 54, Award = 21 };
            


            Film f1 = new Film() { FilmId = 1, Title = "Trainspotting", Genre = "Fekete komédia", DateOfPublish = 1996 };
            Film f2 = new Film() { FilmId = 2, Title = "Star Wars I. rész – Baljós árnyak", Genre = "Akció", DateOfPublish = 1999 };
            Film f3 = new Film() { FilmId = 3, Title = "Az elveszett frigyláda fosztogatói", Genre = "Akció", DateOfPublish = 1985 };
            Film f4 = new Film() { FilmId = 4, Title = "Dűne", Genre = "Sci-fi", DateOfPublish = 2021 };
            Film f5 = new Film() { FilmId = 5, Title = "Szárnyas fejvadász 2049", Genre = "Sci-fi", DateOfPublish = 2017 };

            Actor a1 = new Actor() { ActorId = 1, Name = "Ewan McGregor", Age = 50, Awards = 11 };
            Actor a2 = new Actor() { ActorId = 2, Name = "Harrison Ford", Age = 79, Awards = 12};
            Actor a3 = new Actor() { ActorId = 3, Name = "Zendaya", Age = 25, Awards = 19};
            Actor a4 = new Actor() { ActorId = 4, Name = "Ryan Gosling", Age = 41, Awards = 16};


            f1.DirectorId = d1.DirectorId;
            f1.ActorId = a1.ActorId;

            f2.DirectorId = d2.DirectorId;
            f2.ActorId = a1.ActorId;

            f3.DirectorId = d2.DirectorId;
            f3.ActorId= a2.ActorId;

            f4.DirectorId = d3.DirectorId;
            f4.ActorId = a3.ActorId;

            f5.DirectorId = d3.DirectorId;
            f5.ActorId = a4.ActorId;



           

            modelBuilder.Entity<Film>().HasData(f1, f2, f3, f4, f5);
            modelBuilder.Entity<Actor>().HasData(a1, a2, a3, a4);
            modelBuilder.Entity<Director>().HasData(d1, d2, d3);

        }
    }
}

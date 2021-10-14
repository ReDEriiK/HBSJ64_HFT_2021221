﻿using HBSJ64_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HBSJ64_HFT_2021221.Data
{
    public class FilmContext : DbContext
    {
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public FilmContext()
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
            Director d1 = new Director() { DirectorId = 1, Name = "Danny Boyle", Age = 64, Award = 20 };

            Film f1 = new Film() { FilmId = 1, Title = "Trainspotting", Genre = "Fekete komédia", DateOfPublish = 1996 };

            Actor a1 = new Actor() { ActorId = 1, Name = "Ewan McGregor", Age = 50, Awards = 11 };

            f1.DirectorId = d1.DirectorId;
            f1.MainActorId = a1.ActorId;




            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasOne(film => film.Actor).WithMany(actor => actor.Films).HasForeignKey(film => film.MainActorId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasOne(film => film.Director).WithMany(director => director.Films).HasForeignKey(film => film.DirectorId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Film>().HasData(f1);
            modelBuilder.Entity<Actor>().HasData(a1);
            modelBuilder.Entity<Director>().HasData(d1);

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Raw5MovieDb_WebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Raw5MovieDb_WebApi.Services
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Actor> actors { get; set; }
        public DbSet<AppSettings> appSettings { get; set; }
        public DbSet<BookmarkActor> bookmarkActors { get; set; }
        public DbSet<BookmarkTitle> bookmarkTitles { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<OmdbData> omdbData { get; set; }
        public DbSet<Title> titles { get; set; }
        public DbSet<TitleAkas> titleAkas { get; set; }
        public DbSet<TitleCrew> titleCrews { get; set; }
        public DbSet<TitleEpisode> titleEpisodes { get; set; }
        public DbSet<TitlePrincipals> titlePrincipals { get; set; }
        public DbSet<TitleRating>  titleRatings { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRating> userRatings { get; set; }
        public DbSet<UserSearchHistory> userSearchHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);     
            optionsBuilder.UseNpgsql("host=rawdata.ruc.dk;db=Raw5;uid=postgres;pwd=Tristan!");
            optionsBuilder.EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor>().ToTable("name_basics");
            modelBuilder.Entity<Actor>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<Actor>().Property(x => x.Primaryname).HasColumnName("primaryname");
            modelBuilder.Entity<Actor>().Property(x => x.Birthyear).HasColumnName("birthyear");
            modelBuilder.Entity<Actor>().Property(x => x.Deathyear).HasColumnName("deathyear");
            modelBuilder.Entity<Actor>().Property(x => x.Primaryprofession).HasColumnName("primaryprofession");
            modelBuilder.Entity<Actor>().Property(x => x.Knownfortitles).HasColumnName("knownfortitles");
            modelBuilder.Entity<Actor>().Property(x => x.Namerating).HasColumnName("namerating");


            modelBuilder.Entity<BookmarkActor>().ToTable("bookmark_actor");
            modelBuilder.Entity<BookmarkActor>().Property(x => x.Uconst).HasColumnName("uconst");
            modelBuilder.Entity<BookmarkActor>().Property(x => x.Nconst).HasColumnName("nconst");

            modelBuilder.Entity<BookmarkTitle>().ToTable("bookmark_title");
            modelBuilder.Entity<BookmarkTitle>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<BookmarkTitle>().Property(x => x.Uconst).HasColumnName("uconst");



            modelBuilder.Entity<Genre>().ToTable("genre");
            modelBuilder.Entity<Genre>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasColumnName("name");


            modelBuilder.Entity<Title>().ToTable("title_basics");
            modelBuilder.Entity<Title>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<Title>().Property(x => x.Titletype).HasColumnName("titletype");
            modelBuilder.Entity<Title>().Property(x => x.Primarytitle).HasColumnName("primarytitle");
            modelBuilder.Entity<Title>().Property(x => x.Originaltitle).HasColumnName("originaltitle");
            modelBuilder.Entity<Title>().Property(x => x.Isadult).HasColumnName("isadult");
            modelBuilder.Entity<Title>().Property(x => x.Startyear).HasColumnName("startyear");
            modelBuilder.Entity<Title>().Property(x => x.Endyear).HasColumnName("endyear");
            modelBuilder.Entity<Title>().Property(x => x.Runtimeminutes).HasColumnName("runtimeminutes");








            modelBuilder.Entity<OmdbData>().ToTable("omdb_data");
            modelBuilder.Entity<OmdbData>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<OmdbData>().Property(x => x.Poster).HasColumnName("poster");
            modelBuilder.Entity<OmdbData>().Property(x => x.Awards).HasColumnName("awards");
            modelBuilder.Entity<OmdbData>().Property(x => x.Plot).HasColumnName("plot");

            modelBuilder.Entity<TitleAkas>().ToTable("title_akas");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Titleid).HasColumnName("titleid");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Ordering).HasColumnName("Ordering");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Title).HasColumnName("Title");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Types).HasColumnName("types");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Attributes).HasColumnName("attributes");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Isoriginaltitle).HasColumnName("isoriginaltitle");













        }


    }
}

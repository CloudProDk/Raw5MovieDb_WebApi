using System;
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













        }


    }
}

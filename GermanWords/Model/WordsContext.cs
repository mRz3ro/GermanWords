using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GermanWords.Model
{
    class WordsContext : DbContext
    {

        public DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=GermanWords.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Word>().HasKey("Id");
            //modelBuilder.Entity<Word>().HasMany(w => w.RelatedWords);
            modelBuilder.Entity<Word>().Ignore(w => w.RelatedWords);

            modelBuilder.Entity<OtherForms>()
            .HasKey(of => new { of.NameId, of.OtherFormId });

            modelBuilder.Entity<Name>().HasBaseType<ArticleNameBase>();
            modelBuilder.Entity<Name>().Ignore(n => n.GroupedForms);
            modelBuilder.Entity<Name>().HasMany(n => n.OtherForms);

            modelBuilder.Entity<OtherForms>()
            .HasOne(of => of.Name)
            .WithMany(of => of.OtherForms)
            .HasForeignKey(of => of.NameId);

            modelBuilder.Entity<Article>().HasBaseType<ArticleNameBase>();
            modelBuilder.Entity<Verb>().HasBaseType<Word>();

            //base.OnModelCreating(modelBuilder);
        }
    }
}

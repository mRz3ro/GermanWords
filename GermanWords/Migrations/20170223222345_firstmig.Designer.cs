using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GermanWords.Model;

namespace GermanWords.Migrations
{
    [DbContext(typeof(WordsContext))]
    [Migration("20170223222345_firstmig")]
    partial class firstmig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("GermanWords.Model.OtherForms", b =>
                {
                    b.Property<long>("NameId");

                    b.Property<long>("OtherFormId");

                    b.HasKey("NameId", "OtherFormId");

                    b.HasIndex("OtherFormId");

                    b.ToTable("OtherForms");
                });

            modelBuilder.Entity("GermanWords.Model.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Example");

                    b.Property<int>("Number");

                    b.Property<string>("PtDescription");

                    b.Property<int>("WordType");

                    b.HasKey("Id");

                    b.ToTable("Words");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Word");
                });

            modelBuilder.Entity("GermanWords.Model.ArticleNameBase", b =>
                {
                    b.HasBaseType("GermanWords.Model.Word");

                    b.Property<int>("Genre");

                    b.ToTable("ArticleNameBase");

                    b.HasDiscriminator().HasValue("ArticleNameBase");
                });

            modelBuilder.Entity("GermanWords.Model.Verb", b =>
                {
                    b.HasBaseType("GermanWords.Model.Word");


                    b.ToTable("Verb");

                    b.HasDiscriminator().HasValue("Verb");
                });

            modelBuilder.Entity("GermanWords.Model.Article", b =>
                {
                    b.HasBaseType("GermanWords.Model.ArticleNameBase");

                    b.Property<int>("ArticleType");

                    b.ToTable("Article");

                    b.HasDiscriminator().HasValue("Article");
                });

            modelBuilder.Entity("GermanWords.Model.Name", b =>
                {
                    b.HasBaseType("GermanWords.Model.ArticleNameBase");

                    b.Property<long?>("ArticleId");

                    b.Property<string>("ChildName");

                    b.Property<string>("FatherName");

                    b.Property<string>("ImagePath");

                    b.Property<string>("MotherName");

                    b.Property<int>("Parental");

                    b.HasIndex("ArticleId");

                    b.ToTable("Name");

                    b.HasDiscriminator().HasValue("Name");
                });

            modelBuilder.Entity("GermanWords.Model.OtherForms", b =>
                {
                    b.HasOne("GermanWords.Model.Name", "Name")
                        .WithMany("OtherForms")
                        .HasForeignKey("NameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GermanWords.Model.Name", "OtherForm")
                        .WithMany()
                        .HasForeignKey("OtherFormId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GermanWords.Model.Name", b =>
                {
                    b.HasOne("GermanWords.Model.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SimpleUrlShortenerSPA.Models;

namespace SimpleUrlShortenerSPA.Migrations
{
    [DbContext(typeof(ShortenerDbContext))]
    partial class ShortenerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("SimpleUrlShortenerSPA.Models.ShortedUrlEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("ShortUrlSuffix");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("ShortedUrls");
                });
        }
    }
}

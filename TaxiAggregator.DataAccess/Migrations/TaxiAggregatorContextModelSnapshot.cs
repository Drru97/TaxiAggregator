﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxiAggregator.DataAccess;

namespace TaxiAggregator.DataAccess.Migrations
{
    [DbContext(typeof(TaxiAggregatorContext))]
    partial class TaxiAggregatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaxiAggregator.Domain.Models.HistoricalData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarType");

                    b.Property<double>("DestinationLatitude");

                    b.Property<double>("DestinationLongitude");

                    b.Property<double>("Distance");

                    b.Property<int?>("MaxPrice");

                    b.Property<int?>("MinPrice");

                    b.Property<DateTime>("OrderDate");

                    b.Property<double>("OriginLatitude");

                    b.Property<double>("OriginLongitude");

                    b.Property<int>("Price");

                    b.Property<double?>("SurgeMultiplier");

                    b.Property<string>("TaxiService");

                    b.HasKey("Id");

                    b.ToTable("StatisticalData");
                });
#pragma warning restore 612, 618
        }
    }
}

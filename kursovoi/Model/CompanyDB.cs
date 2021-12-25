using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace kursovoi.Model
{
    public partial class CompanyDB : DbContext
    {
        public CompanyDB()
            : base("name=CompanyDB")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<contract> contract { get; set; }
        public virtual DbSet<flat> flat { get; set; }
        public virtual DbSet<houses> houses { get; set; }
        public virtual DbSet<Individual> Individual { get; set; }
        public virtual DbSet<legalEntity> legalEntity { get; set; }
        public virtual DbSet<obje> obje { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tipecontract> tipecontract { get; set; }
        public virtual DbSet<worker> worker { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<client>()
                .HasMany(e => e.contract)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.clientFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .HasOptional(e => e.Individual)
                .WithRequired(e => e.client);

            modelBuilder.Entity<client>()
                .HasOptional(e => e.legalEntity)
                .WithRequired(e => e.client);


            modelBuilder.Entity<contract>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<obje>()
                .HasOptional(e => e.flat)
                .WithRequired(e => e.obje);

            modelBuilder.Entity<obje>()
                .HasOptional(e => e.houses)
                .WithRequired(e => e.obje);

            modelBuilder.Entity<Individual>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<Individual>()
                .Property(e => e.INN)
                .IsUnicode(false);

            modelBuilder.Entity<Individual>()
                .Property(e => e.passport)
                .IsUnicode(false);

            modelBuilder.Entity<legalEntity>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<legalEntity>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<legalEntity>()
                .Property(e => e.INN)
                .IsUnicode(false);

            modelBuilder.Entity<legalEntity>()
                .Property(e => e.KPP)
                .IsUnicode(false);

            modelBuilder.Entity<legalEntity>()
                .Property(e => e.director)
                .IsUnicode(false);

            modelBuilder.Entity<obje>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<obje>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<obje>()
                .Property(e => e.priceRent)
                .HasPrecision(19, 4);

            modelBuilder.Entity<obje>()
                .Property(e => e.priceBuy)
                .HasPrecision(19, 4);

            modelBuilder.Entity<obje>()
                .HasMany(e => e.contract)
                .WithRequired(e => e.obje)
                .HasForeignKey(e => e.objeFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipecontract>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tipecontract>()
                .HasMany(e => e.contract)
                .WithRequired(e => e.tipecontract)
                .HasForeignKey(e => e.contract_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<worker>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<worker>()
                .Property(e => e.post)
                .IsUnicode(false);

            modelBuilder.Entity<worker>()
                .HasMany(e => e.contract)
                .WithRequired(e => e.worker)
                .HasForeignKey(e => e.workerFK)
                .WillCascadeOnDelete(false);
        }
    }
}

using CobroSmart.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Infrastructure.Context
{
    public class CobroSmartContext : DbContext
    {
        public CobroSmartContext(DbContextOptions<CobroSmartContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<BlackList> BlackLists { get; set; }
        public DbSet<TokenRevocation> TokenRevocations { get; set; }
        public DbSet<FileByCompany> FilesByCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Company>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Employees>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Client>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Account>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Service>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<Payment>()
                .HasQueryFilter(a => !a.IsDeleted);

            modelBuilder.Entity<User>()
                .HasOne(e => e.Company)
                .WithOne(e => e.User)
                .HasForeignKey<Company>(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(e => e.Employees)
                .WithOne(e => e.User)
                .HasForeignKey<Employees>(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TokenRevocation)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Client)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Account)
                .WithOne(e => e.Company)
                .HasForeignKey (e => e.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Discount)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Interest)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.FileByCompany)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Service)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.AccountId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Client)
                .WithOne(e => e.Employees)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Service)
                .WithOne(e => e.Employees)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Service)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne(e => e.BlackList)
                .WithOne(e => e.Client)
                .HasForeignKey<BlackList>(e => e.ClientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.Payment)
                .WithOne(e => e.Service)
                .HasForeignKey(e => e.ServiceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.Payment)
                .WithOne(e => e.Discount)
                .HasForeignKey(e => e.DiscountId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Interest>()
                .HasMany(e => e.Payment)
                .WithOne(e => e.Interest)
                .HasForeignKey(e => e.InterestId)
                .IsRequired()
                .OnDelete (DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.EmailCompany)
                .IsUnique();

            modelBuilder.Entity<Employees>()
                .HasIndex(e => e.EmailEmployee)
                .IsUnique();

            modelBuilder.Entity<Service>()
                .Property(s => s.Status)
                .HasDefaultValue("Sin pago");

            modelBuilder.Entity<Service>()
                .Property(s => s.TotalInterest)
                .HasDefaultValue(0);
        }
    }
}

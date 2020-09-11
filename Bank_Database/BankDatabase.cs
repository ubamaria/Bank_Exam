using Bank_Database.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bank_Database
{
    public class BankDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-BUNOAQN\SQLEXPRESS;Initial Catalog=BankDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Bank> Banks { set; get; }
        public virtual DbSet<Deposit> Deposits { set; get; }
    }
}

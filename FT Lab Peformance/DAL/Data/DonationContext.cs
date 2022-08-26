/*using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    internal class DonationContext : DbContext
    {
        public DonationContext()
        {

        }
        public DonationContext(DbContextOptions<DonationContext> options) : base(options)
        {

        }

        public DbSet<Donar> Donars{ get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<Account> Accounts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DELL-INSPIRON-3\\SQLEXPRESS;Database=Allah;Trusted_Connection=True;");
            }
        }
    }
}
*/
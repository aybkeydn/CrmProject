using Microsoft.EntityFrameworkCore;
using Most_Crm.Models;
using System.Collections.Generic;

namespace Most_Crm.Data
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ContactPerson> ContactPeople { get; set; }


    }
}

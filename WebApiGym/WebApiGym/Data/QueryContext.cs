using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGym.Models;

namespace WebApiGym.Data
{
    public class QueryContext : DbContext
    {
        public QueryContext(DbContextOptions<GymContext> options) : base(options)
        {
        }


        public DbSet<queryLoginResult> loginQueryResult { get; set; }


    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<queryLoginResult>().HasKey();
        }
    }
}

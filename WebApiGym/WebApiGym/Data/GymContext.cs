using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiGym.Models;

namespace WebApiGym.Data
{
    public class GymContext: DbContext
    {
        public GymContext(DbContextOptions<GymContext> options): base(options)
        {
        }

        public DbSet<tb_usuario> tb_Usuario { get; set; }
        public DbSet<vistaCentro> centroInfo { get; set; }

        public DbSet<tb_control> ControlInfo { get; set; }

        //public DbSet<queryLoginResult> loginQueryResult { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vistaCentro>().HasNoKey();
         
        }
    }


}

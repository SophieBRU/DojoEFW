using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atelier_09112020
{
    class DojoEFW : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-F2GQDM4\SQLEXPRESS;Database=DojoEFW;Integrated Security=True");
        }
    }
}

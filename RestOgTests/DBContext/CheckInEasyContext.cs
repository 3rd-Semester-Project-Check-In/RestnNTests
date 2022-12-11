using Microsoft.EntityFrameworkCore;
using RestOgTests.Models;
using System;

namespace RestOgTests.DBContext
{
    public class CheckInEasyContext : DbContext
    {

        public CheckInEasyContext(DbContextOptions<CheckInEasyContext> options) : base(options) { }

        public DbSet<Lokale> Lokaler { get; set; }
        public DbSet<Kort> Korts { get; set; }

    }
}

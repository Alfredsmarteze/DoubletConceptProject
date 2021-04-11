using DoubletConceptProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoubletConceptProject.Data
{
    public class DoubletContext: IdentityDbContext
    {
        public DoubletContext(DbContextOptions options):base(options)
        {}

        public DbSet<YourMessage> yourMessages { get; set; }
        public DbSet<Admin> admin { get; set; }
        public DbSet<DoubletConceptProject.Models.LoginInfo> LoginInfo { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
            
        //}
    }
}

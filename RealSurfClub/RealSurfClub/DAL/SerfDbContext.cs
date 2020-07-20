using RealSurfClub.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealSurfClub.DAL
{
    public class SurfDbContext : DbContext
    {

        static SurfDbContext()
        {
            Database.SetInitializer(new SurfDbInitializer());
        }

        public SurfDbContext(): base("RealSurfDatabase")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
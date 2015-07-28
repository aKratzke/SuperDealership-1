using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SuperDealership.Models;



	
namespace SuperDealership.DAL
{
    public class AutoDBContext : DbContext
    {

        public DbSet<Auto> Vehicle { get; set; }

        public DbSet<User> Users { get; set; }


         


         


    }
} 
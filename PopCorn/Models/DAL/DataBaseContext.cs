using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PopCorn.Models.DAL
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext():base("FILM")
        {

        }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
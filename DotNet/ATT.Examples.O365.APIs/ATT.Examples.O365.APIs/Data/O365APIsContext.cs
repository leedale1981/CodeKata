using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ATT.Examples.O365.APIs.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ATT.Examples.O365.APIs.Data
{
    public class O365APIsContext : DbContext
    {
        public O365APIsContext() : base("O365APIsContext") { }
        public DbSet<PerWebUserCache> PerWebUserCacheList { get;set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SO.SilList.Manager.Models.ValueObjects;


namespace SO.SilList.Manager.DbContexts
{
    public partial class MainDb : DbContext
    {
        public MainDb()
            : base("name=MainDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<BusinessVo> businesses { get; set; }
      

    }

}

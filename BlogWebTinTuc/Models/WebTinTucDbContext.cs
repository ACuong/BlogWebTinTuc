using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BlogWebTinTuc.Models
{
    public partial class WebTinTucDbContext : DbContext
    {
        public WebTinTucDbContext()
            : base("name=WebTinTucDbContext")
        {
        }
        public virtual DbSet<Account> Accounts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}

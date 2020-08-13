namespace DataModal.DBClass
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SooftDbContext : DbContext
    {
        public SooftDbContext()
            : base("name=SooftDbContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<SingerGenders> SingerGenders { get; set; }
        public virtual DbSet<Singers> Singers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static SooftDbContext Create()
        {
            return new SooftDbContext();
        }
    }
}

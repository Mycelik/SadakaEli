using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadakaEli.Model.Domain;
using SadakaEli.DataAccess.EntityFramework.Mapping;
using System.Data.Entity;

namespace SadakaEli.DataAccess.EntityFramework.Context
{
    public class SadakaEliContext : DbContext
    {

        public SadakaEliContext() : base("SadakaEliConnStr")
        {
            Database.SetInitializer<SadakaEliContext>(null);
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<News> Newsies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Slider> Sliders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new NewsMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SliderMap());

        }
    }
}

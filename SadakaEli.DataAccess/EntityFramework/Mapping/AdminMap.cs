using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using SadakaEli.Model.Domain;

namespace SadakaEli.DataAccess.EntityFramework.Mapping
{
    public class AdminMap:EntityTypeConfiguration<Admin>
    {
        public AdminMap()
        {
            ToTable("Admin");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


        }
    }
}

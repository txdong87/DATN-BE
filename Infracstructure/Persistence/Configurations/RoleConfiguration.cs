//using Domain.Entities;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Persistence.Configurations
//{
//    public class RoleConfiguration : IEntityTypeConfiguration<Role>
//    {
//        public void Configure(EntityTypeBuilder<Role> builder)
//        {
//            builder.Property(e => e.RoleName)
//                    .HasMaxLength(50)
//                    .HasDefaultValueSql("'NULL'");
//        }
//    }
//}

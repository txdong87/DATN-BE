//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Persistence.Configurations
//{
//    public class UserConfiguration : IEntityTypeConfiguration<User>
//    {
//        public void Configure(EntityTypeBuilder<User> builder)
//        {
//            //builder.HasOne(a => a.Category)
//            //    .WithMany(a => a.Assets)
//            //    .HasForeignKey(a => a.CategoryId);
//            builder.HasOne(d => d.Role)
//                   .WithMany(p => p.Users)
//                   .HasForeignKey(d => d.RoleId)
//                        .OnDelete(DeleteBehavior.Restrict);
//        }
//    }
//}

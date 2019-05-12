using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);

            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);

            builder.HasOne<User>(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.UserId);
        }
    }
}

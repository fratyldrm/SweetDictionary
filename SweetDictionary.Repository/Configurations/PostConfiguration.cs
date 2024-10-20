using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Repository.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("PostId");
            builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
            builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");
            builder.Property(c => c.Title).HasColumnName("Title");
            builder.Property(c => c.Content).HasColumnName("content");
            builder.Property(c => c.AuthorId).HasColumnName("AuthorId");
            builder.Property(c => c.CategoryId).HasColumnName("CategoryId");




            builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Author).WithMany(x => x.Posts).HasForeignKey(x=>x.AuthorId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}

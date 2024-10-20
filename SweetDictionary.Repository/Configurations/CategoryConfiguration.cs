using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Repository.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
       builder.ToTable("Categories").HasKey(c=>c.Id);
        builder.Property(c=>c.Id).HasColumnName("CategoryId");
        builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(c => c.Name).HasColumnName("Category_Name");


      
        builder.HasMany(X=>X.Posts).WithOne(x => x.Category).HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.NoAction);
        builder.HasData(new Category
        {
            Id = 1,
            Name = "Yazılım",
        });
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCarSystem.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());

            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Cars);
            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(20);
            
        }

        private List<Category> CreateCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                 {
                      Id = 1,
                      CategoryName = "Economy"
                 },

                new Category()
                {
                    Id = 2,
                    CategoryName = "Compact"
                },

                new Category()
                {
                    Id = 3,
                    CategoryName = "Intermediate"
                }
            };

            return categories;
        }
    }
}

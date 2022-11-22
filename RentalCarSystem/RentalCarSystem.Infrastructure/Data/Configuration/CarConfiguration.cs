using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCarSystem.Infrastructure.Entities;
using RentalCarSystem.Infrastructure.Entities.Enum.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Data.Configuration
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {

        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(CreateCars());
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Category)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.CategoryId);
            builder.Property(r => r.RegNumber)
                   .IsRequired()
                   .HasMaxLength(8);
            builder.Property(m => m.Make)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(m => m.Model)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(m => m.MakeYear)
                   .IsRequired();
            builder.Property(c => c.Color)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(d => d.Description)
                   .IsRequired()
                   .HasMaxLength(5000);
            builder.Property(i => i.ImageUrl)
                   .IsRequired();
            builder.Property(g => g.GearBox)
                .IsRequired();
            builder.Property(d => d.DailyRate)
                .IsRequired();
            builder.Property(a => a.IsAvailable)
                .IsRequired();
        }

        private List<Car> CreateCars()
        {
            var cars = new List<Car>()
            {
                new Car()
                 {
                      Id = 1,
                      RegNumber = "B1234AB",
                      Make = "Toyota",
                      Model = "Corolla",
                      MakeYear = 2022,
                      Color = "Black",
                      Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
                      ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
                      GearBox = GearBox.Manual,
                      DailyRate = 40,
                      IsAvailable = true,
                      CategoryId = 3,
                 },

                new Car()
                {
                    Id = 2,
                    RegNumber = "B1444CB",
                    Make = "Hundai",
                    Model = "i20",
                    MakeYear = 2022,
                    Color = "Grey",
                    Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, no highest equipment.",
                    ImageUrl = "https://s7g10.scene7.com/is/image/hyundaiautoever/BC3_5DR_TopTrim_DG01-01_EXT_front_rgb_v01_w3a-1:4x3?wid=960&hei=720&fmt=png-alpha&fit=wrap,1",
                    GearBox = GearBox.Manual,
                    DailyRate = 33,
                    IsAvailable = true,
                    CategoryId = 1,
                },

                new Car()
                {
                    Id = 3,
                    RegNumber = "B1223AB",
                    Make = "Citroen",
                    Model = "C4",
                    MakeYear = 2022,
                    Color = "White",
                    Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment.",
                    ImageUrl = "https://www.citroen-eg.com/wp-content/uploads/2021/11/Polar-White-front1.jpg",
                    GearBox = GearBox.Automatic,
                    DailyRate = 37,
                    IsAvailable = true,
                    CategoryId = 2,
                }
            };

            return cars;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Data.Configuration
{
    internal class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {

        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder.HasData(CreateInsurances());
            builder.HasKey(i => i.InsuranceCode);

            builder.Property(i => i.TypeOfInsurance)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(c => c.CostPerDay)
                .IsRequired();
        }

        private List<Insurance> CreateInsurances()
        {
            var insurances = new List<Insurance>()
            {
                new Insurance()
                 {
                      InsuranceCode = 1,
                      TypeOfInsurance = "FullCoverage",
                      CostPerDay = 10
                 },

                new Insurance()
                {
                    InsuranceCode = 2,
                    TypeOfInsurance = "HalfCoverage",
                    CostPerDay = 5
                }
            };

            return insurances;
        }
    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;

namespace WasteControl.Infrastructure.DAL.Configurations
{
    public class ReceivingCompanyConfiguration : IEntityTypeConfiguration<ReceivingCompany>
    {
        public void Configure(EntityTypeBuilder<ReceivingCompany> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(
                    v => v.Value,
                    v => new ID(v));

            builder.Property(x => x.IsActive)
                .HasConversion(
                    v => v.Value,
                    v => new Activity(v));
            
            builder.Property(x => x.CreateDate)
                .HasConversion<TimeStamp?>(
                    v => v == null ? null : v.Value,
                    v => v == null ? null : new TimeStamp(v))
                .IsRequired(false);

            builder.Property(x => x.CreatedById)
                .HasConversion<ID?>(
                    v => v == null ? null : v.Value,
                    v => v == null ? null : new ID(v))
                .IsRequired(false);

            builder.Property(x => x.ModifiedDate)
                .HasConversion<TimeStamp?>(
                    v => v == null ? null : v.Value,
                    v => v == null ? null : new TimeStamp(v))
                .IsRequired(false);

            builder.Property(x => x.ModifiedById)
                .HasConversion<ID?>(
                    v => v == null ? null : v.Value,
                    v => v == null ? null : new ID(v))
                .IsRequired(false);

            builder.Property(x => x.Code)
                .HasConversion(
                    v => v.Value,
                    v => new CompanyCode(v));

            builder.Property(x => x.Name)
                .HasConversion(
                    v => v.Value,
                    v => new CompanyName(v));

            builder.Property(x => x.Address)
                .HasConversion(
                    v => v.Value,
                    v => new Address(v));

            builder.Property(x => x.City)
                .HasConversion(
                    v => v.Value,
                    v => new City(v));

            builder.Property(x => x.PostalCode)
                .HasConversion(
                    v => v.Value,
                    v => new PostalCode(v));

            builder.Property(x => x.Country)
                .HasConversion(
                    v => v.Value,
                    v => new Country(v));

            builder.Property(x => x.Phone)
                .HasConversion(
                    v => v.Value,
                    v => new Phone(v));

            builder.Property(x => x.Email)
                .HasConversion(
                    v => v.Value,
                    v => new Email(v));
        }

    }
}
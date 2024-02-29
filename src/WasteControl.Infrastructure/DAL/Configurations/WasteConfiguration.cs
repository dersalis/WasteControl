using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;

namespace WasteControl.Infrastructure.DAL.Configurations
{
    public class WasteConfiguration : IEntityTypeConfiguration<Waste>
    {
        public void Configure(EntityTypeBuilder<Waste> builder)
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
                .HasConversion(
                    v => v.Value,
                    v => new TimeStamp(v))
                .IsRequired(false);

            builder.Property(x => x.CreatedById)
                .HasConversion(
                    v => v.Value,
                    v => new ID(v))
                .IsRequired(false);

            builder.Property(x => x.ModifiedDate)
                .HasConversion(
                    v => v.Value,
                    v => new TimeStamp(v))
                .IsRequired(false);

            builder.Property(x => x.ModifiedById)
                .HasConversion(
                    v => v.Value,
                    v => new ID(v))
                .IsRequired(false);

            builder.Property(x => x.Code)
                .HasConversion(
                    v => v.Value,
                    v => new WasteCode(v));

            builder.Property(x => x.Name)
                .HasConversion(
                    v => v.Value,
                    v => new WasteName(v));

            builder.Property(x => x.Quantity)
                .HasConversion(
                    v => v.Value,
                    v => new WasteQuantity(v));
            
            builder.Property(x => x.Unit)
                .HasConversion(
                    v => v.Value,
                    v => new WasteUnit(v));
        }
    }
}
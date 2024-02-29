using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;

namespace WasteControl.Infrastructure.DAL.Configurations
{
    public class WasteExportConfiguration : IEntityTypeConfiguration<WasteExport>
    {
        public void Configure(EntityTypeBuilder<WasteExport> builder)
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

            builder.Property(x => x.ReceivingCompanyId)
                .HasConversion(
                    v => v.Value,
                    v => new ID(v))
                .IsRequired(false);

            builder.Property(x => x.TransportCompanyId)
                .HasConversion(
                    v => v.Value,
                    v => new ID(v))
                .IsRequired(false);

            builder.Property(x => x.BookingDate)
                .HasConversion(
                    v => v.Value,
                    v => new TimeStamp(v));

            builder.Property(x => x.Description)
                .HasConversion(
                    v => v.Value,
                    v => new WasteExportDescription(v));
        }
    }
}
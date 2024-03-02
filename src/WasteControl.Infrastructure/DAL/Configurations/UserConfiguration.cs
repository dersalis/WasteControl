using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;

namespace WasteControl.Infrastructure.DAL.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
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

            builder.HasOne(x => x.CreatedBy)
                .WithMany()
                .HasForeignKey(x => x.CreatedById)
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

            builder.HasOne(x => x.ModifiedBy)
                .WithMany()
                .HasForeignKey(x => x.ModifiedById)
                .IsRequired(false);

            builder.Property(x => x.ModifiedById)
                .HasConversion(
                    v => v.Value,
                    v => new ID(v))
                .IsRequired(false);

            builder.Property(x => x.Name)
                .HasConversion(
                    v => v.Value,
                    v => new UserName(v));

            builder.Property(x => x.Email)
                .HasConversion(
                    v => v.Value,
                    v => new Email(v));
                
            builder.HasMany<WasteExport>()
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CreatedById)
                .IsRequired(false);

            builder.HasMany<WasteExport>()
                .WithOne(x => x.ModifiedBy)
                .HasForeignKey(x => x.ModifiedById)
                .IsRequired(false);

            builder.HasMany<Waste>()
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CreatedById)
                .IsRequired(false);

            builder.HasMany<Waste>()
                .WithOne(x => x.ModifiedBy)
                .HasForeignKey(x => x.ModifiedById)
                .IsRequired(false);

            builder.HasMany<ReceivingCompany>()
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CreatedById)
                .IsRequired(false);

            builder.HasMany<ReceivingCompany>()
                .WithOne(x => x.ModifiedBy)
                .HasForeignKey(x => x.ModifiedById)
                .IsRequired(false);

            builder.HasMany<TransportCompany>()
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CreatedById)
                .IsRequired(false);

            builder.HasMany<TransportCompany>()
                .WithOne(x => x.ModifiedBy)
                .HasForeignKey(x => x.ModifiedById)
                .IsRequired(false);

            builder.HasMany<User>()
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CreatedById)
                .IsRequired(false);

            builder.HasMany<User>()
                .WithOne(x => x.ModifiedBy)
                .HasForeignKey(x => x.ModifiedById)
                .IsRequired(false);
        }
    }
}
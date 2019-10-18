using MF.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MF.Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(d => d.FirstName).HasColumnName(nameof(User.FirstName)).IsRequired();
            builder.Property(d => d.LastName).HasColumnName(nameof(User.LastName)).IsRequired();
            builder.Property(d => d.Login).HasColumnName(nameof(User.Login)).IsRequired();
            builder.Property(d => d.Password).HasColumnName(nameof(User.Password)).IsRequired();
            builder.Property(d => d.Level).HasColumnName(nameof(User.Level)).IsRequired();
            builder.HasQueryFilter(d => d.Active);
            builder.OwnsOne(o => o.Contact, co =>
            {
                co.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
                co.Property(p => p.Email).HasColumnName("Email");
            });
            builder.OwnsOne(o => o.Address,
                sa =>
                {
                    sa.Property(p => p.PostalCode).HasColumnName("PostalCode");
                    sa.Property(p => p.AddressLine).HasColumnName("AddressLine");
                    sa.Property(p => p.City).HasColumnName("City");
                    sa.Property(p => p.State).HasColumnName("State");
                    sa.Property(p => p.Country).HasColumnName("Country");
                }
            );
        }
    }
}
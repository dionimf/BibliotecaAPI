using MF.Domain.Entities.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MF.Infra.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(d => d.BookName).HasColumnName(nameof(Book.BookName)).IsRequired();
            builder.Property(d => d.Author).HasColumnName(nameof(Book.Author)).IsRequired();
            builder.Property(d => d.PublishingCompany).HasColumnName(nameof(Book.PublishingCompany)).IsRequired();
            builder.Property(d => d.PostedDate).HasColumnName(nameof(Book.PostedDate)).IsRequired();
            builder.Property(d => d.Edition).HasColumnName(nameof(Book.Edition)).IsRequired();
            builder.Property(d => d.Status).HasColumnName(nameof(Book.Status)).IsRequired();
        }
    }
}
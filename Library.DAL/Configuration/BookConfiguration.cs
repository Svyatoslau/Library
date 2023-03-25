using Library.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Configuration;
internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .Property(b => b.Isbn)
            .HasMaxLength(17)
            .IsRequired();
        builder
            .Property(b => b.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder
            .Property(b => b.Genre)
            .HasMaxLength(50);
        builder
            .Property(b => b.Description)
            .HasMaxLength(1000);
        builder
            .Property(b => b.Author)
            .HasMaxLength(100)
            .IsRequired();
    }
}

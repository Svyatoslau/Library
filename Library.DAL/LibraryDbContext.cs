using Library.Core.Models;
using Library.DAL.Configuration;
using Library.DAL.Origin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL;
public class LibraryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new BookConfiguration())
            .ApplyConfiguration(new UserConfiguration());

        modelBuilder
            .ApplyConfiguration(new BookOrigin())
            .ApplyConfiguration(new UserOrigin());
    }

}

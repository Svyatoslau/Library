using Library.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Origin;
internal class BookOrigin : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            new Book
            {
                Id = 1,
                Isbn = "978-0-7352-1128-5",
                Name = "The Lincoln Highway",
                Genre = "historical fiction",
                Description =
                    "This is a historical fiction novel that follows four young men" +
                    " on a cross-country road trip in 1950s America. Along the way," +
                    " they encounter adventure, danger, and unexpected connections.",
                Author = "Amor Towles"
            },
            new Book
            {
                Id = 2,
                Isbn = "978-0-4417-8644-5",
                Name = "Dune",
                Genre = "science fiction",
                Description =
                    "This is a science fiction classic that tells the story of Paul Atreides," +
                    " a young man who inherits a desert planet called Arrakis, which holds a " +
                    "valuable spice that can extend life and enhance consciousness. Paul must" +
                    " fight against enemies who want to take over his planet and his destiny.",
                Author = "Frank Herbert"
            },
            new Book
            {
                Id = 3,
                Isbn = "978-0-7352-1049-3",
                Name = "Atomic Habits: An Easy & Proven Way to Build Good Habits & Break Bad Ones",
                Genre = "self-help",
                Description =
                    "This is a self-help book that teaches readers how to create and " +
                    "maintain effective habits that can improve their lives. The book " +
                    "draws on scientific research, personal stories, and practical advice.",
                Author = "James Clear"
            }
        );
    }
}

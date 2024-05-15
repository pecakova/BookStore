using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Data;
using System;
using System.Linq;

namespace BookStore.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>()))
        {
            // Look for any movies.
            /*if (context.Author.Any() || context.Book.Any() || context.BookGenre.Any() || context.Genre.Any() || context.Review.Any() || context.UserBooks.Any())
            {

                // Retrieve the books you want to delete
                var booksToDelete = context.Book.Where(book => book.Title == "Pirej" || book.Title == "The idea of you" || book.Title == "Silver Suitcase" || book.Title == "Les Miserables" || book.Title == "The Comfort Book").ToList();

                // Delete the retrieved books
                context.Book.RemoveRange(booksToDelete);

                // Save changes to the database
                context.SaveChanges();
                // Retrieve the books you want to delete
                var authorToDelete = context.Author.Where(author => author.FirstName == "Petre" && author.LastName == "M.Andreevski" || author.FirstName == "Robinne" && author.LastName == "Lee" || author.FirstName == "Terry" && author.LastName == "Tod" || author.FirstName == "Victor" && author.LastName == "Hugo" || author.FirstName == "Matt" && author.LastName == "Haig").ToList();

                // Delete the retrieved books
                context.Author.RemoveRange(authorToDelete);

                // Save changes to the database
                context.SaveChanges();

                var genreToDelete = context.Genre.Where(genre => genre.GenreName == "Historical drama" || genre.GenreName == "Romance" || genre.GenreName == "Drama" || genre.GenreName == "Tragedy" || genre.GenreName == "Psychology");

                context.Genre.RemoveRange(genreToDelete);
                context.SaveChanges();

                var reviewToDelete = context.Review.Where(user => user.AppUser == "AnneM" || user.AppUser == "TomT" || user.AppUser == "Marie" || user.AppUser == "Ana" || user.AppUser == "Nicole");
                context.Review.RemoveRange(reviewToDelete);
                context.SaveChanges();

                var bgToDelete = context.BookGenre.Where(bg => bg.BookId == 1 || bg.BookId == 2 || bg.BookId == 3 || bg.BookId == 4 || bg.BookId == 5);
                context.BookGenre.RemoveRange(bgToDelete);
                context.SaveChanges();
                
                return;   // DB has been seeded
            }*/
            if (context.Author.Any() || context.Book.Any() || context.BookGenre.Any() || context.Genre.Any() || context.Review.Any() || context.UserBooks.Any())
            {
                return;
            }
            context.Author.AddRange(
                new Author
                {   
                    /*Id = 1, */
                    FirstName = "Petre",
                    LastName = "M.Andreevski",
                    BirthDate = DateTime.Parse("1934-6-25"),
                    Nationality = "Macedonian",
                    Gender = "male"
                },
                new Author
                {
                    /*Id = 2, */
                    FirstName = "Robinne",
                    LastName = "Lee",
                    BirthDate = DateTime.Parse("1980-4-20"),
                    Nationality = "American",
                    Gender = "female"
                },
                new Author
                {
                    /*Id = 3, */
                    FirstName = "Terry",
                    LastName = "Tod",
                    BirthDate = DateTime.Parse("1976-10-10"),
                    Nationality = "American",
                    Gender = "male"
                },
                new Author
                {
                    /*Id = 4, */
                    FirstName = "Victor",
                    LastName = "Hugo",
                    BirthDate = DateTime.Parse("1802-2-26"),
                    Nationality = "French",
                    Gender = "male"
                },
                new Author
                {
                    /*Id = 5, */
                    FirstName = "Matt",
                    LastName = "Haig",
                    BirthDate = DateTime.Parse("1975-7-3"),
                    Nationality = "English",
                    Gender = "male"
                }
            );
            context.SaveChanges();
            context.Book.AddRange(
                new Book
                {
                    /*Id = 1, */
                    Title = "Pirej",
                    YearPublished = 1980,
                    NumPages = 252,
                    Description = "The novel, set during the period of the Balkan Wars, World War I and the period after, tells the story of Jon and Velika, a couple living in a village in southern Macedonia. The novel's title translated to couch grass refers to the perseverance and stoicism of Macedonian people through history. In modern day, Pirej is considered to be the author's magnum opus and one of the main and most important works written in Macedonian during the 20th century. ",
                    Publisher = "Tri",
                    AuthorId = 106,
                    FrontPage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCQsK7Kn9fkKRzNVHAkD_OTP1JG7FFBvT18BiYp1nnRxjHUS5G",
                    DownloadUrl = "https://www.google.mk/books/edition/Pirej/MGYsAAAAIAAJ?hl=mk&gbpv=1&bsq=%D0%9F%D0%B8%D1%80%D0%B5%D1%98&dq=%D0%9F%D0%B8%D1%80%D0%B5%D1%98&printsec=frontcover",
                },
                new Book
                {
                    /*Id = 2, */
                    Title = "The idea of you",
                    YearPublished = 2017,
                    NumPages = 384,
                    Description = "Solène Marchand, the thirty-nine-year-old owner of an art gallery in Los Angeles, is reluctant to take her daughter, Isabelle, to meet her favorite boy band. But since her divorce, she’s more eager than ever to be close to Isabelle. The last thing Solène expects is to make a connection with one of the members of the world-famous August Moon. But Hayes Campbell is clever, winning, confident, and posh, and the attraction is immediate. That he is all of twenty years old further complicates things.",
                    Publisher = "MacMillan",
                    AuthorId = 107,
                    FrontPage = "https://m.media-amazon.com/images/I/41wnlc2dO6L._SY445_SX342_.jpg",
                    DownloadUrl = "https://www.amazon.com/Idea-You-Novel-Robinne-Lee/dp/1250125901",
                },
                new Book
                {
                    /*Id = 3, */
                    Title = "Silver Suitcase",
                    YearPublished = 2016,
                    NumPages = 270,
                    Description = "It’s 1939, and Canada is on the cusp of entering World War II. Seventeen-year-old farm girl Cornelia has been heartbroken since the day her mother died five years ago. As a new tragedy provides Cornelia still more reason to reject her parent’s faith, a mysterious visitor appears in her hour of desperation. Alone and carrying a heavy secret, she makes a desperate choice that will haunt her for years to come. Never telling a soul, Cornelia pours out the painful events of the war in her diary.",
                    Publisher = "Brilliance",
                    AuthorId = 108,
                    FrontPage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRKfkWYvNLnqB1oidnrQ4NCbiLC9ihXvVaxKZsAhpRhKIlWiwfS",
                    DownloadUrl = "https://www.amazon.com/Silver-Suitcase-Terrie-Todd/dp/1511343842",
                },
                new Book
                {
                    /*Id = 4, */
                    Title = "Les Miserables",
                    YearPublished = 1982,
                    NumPages = 1232,
                    Description = "",
                    Publisher = "Penguin Classics",
                    AuthorId = 109,
                    FrontPage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUg5qwOTfeSwTf-cJZQCgxsH5SW2y9z_qC4xZBvuZjjJchR6t6",
                    DownloadUrl = "https://www.amazon.com/Miserables-Penguin-Classics-Victor-Hugo/dp/0140444300",
                },
                new Book
                {
                    /*Id = 5, */
                    Title = "The Comfort Book",
                    YearPublished = 2021,
                    NumPages = 272,
                    Description = "The Comfort Book is a collection of consolations learned in hard times and suggestions for making the bad days better. Drawing on maxims, memoir and the inspirational lives of others, these meditations celebrate the ever-changing wonder of living. This is for when we need the wisdom of a friend or a reminder we can always nurture inner strength and hope, even in our busy world.",
                    Publisher = "Canongate Books",
                    AuthorId = 110,
                    FrontPage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQKoWnRCzDSD6rX022NadBJSjsS9v_mDPD6UakQNzzWZspw4bR-",
                    DownloadUrl = "https://www.amazon.co.uk/Comfort-Book-Matt-Haig/dp/1786898292",
                }
            );
            context.SaveChanges();
            context.Genre.AddRange(
                new Genre { /*Id = 1, */ GenreName = "Historical drama" },
                new Genre { /*Id = 2, */ GenreName = "Romance" },
                new Genre { /*Id = 3, */ GenreName = "Drama" },
                new Genre { /*Id = 4, */ GenreName = "Tragedy" },
                new Genre { /*Id = 5, */ GenreName = "Psychology" }
                );
            context.SaveChanges();
            context.Review.AddRange(
                new Review
                {
                    /*Id = 1, */
                    AppUser = "AnneM",
                    Comment = "Very beautiful and inspirational book!",
                    Rating = 10,
                },
                new Review
                {
                    /*Id = 2, */
                    AppUser = "TomT",
                    Comment = "Such a romance.",
                    Rating = 9,
                },
               new Review
               {
                   /*Id = 3, */
                   AppUser = "Marie",
                   Comment = "What a story! I love it.",
                   Rating = 10,
               },
               new Review
               {
                   /*Id = 4, */
                   AppUser = "Ana",
                   Comment = "Breathtaking.",
                   Rating = 10,
               },
                new Review
                {
                    /*Id = 5, */
                    AppUser = "Nicole",
                    Comment = "It's good!",
                    Rating = 7,
                }
             );
            context.SaveChanges();
            context.BookGenre.AddRange(
                new BookGenre
                {
                    BookId = 1,
                    GenreId = 1
                },
                new BookGenre
                {
                    BookId = 1,
                    GenreId = 2,
                },
                new BookGenre
                {
                    BookId = 2,
                    GenreId = 2
                },
                new BookGenre
                {
                    BookId = 2,
                    GenreId = 3,
                },
                new BookGenre
                {
                    BookId = 3,
                    GenreId = 1
                },
                new BookGenre
                {
                    BookId = 3,
                    GenreId = 2
                },
                new BookGenre
                {
                    BookId = 3,
                    GenreId = 4
                },
                new BookGenre
                {
                    BookId = 4,
                    GenreId = 4
                },
                new BookGenre
                {
                    BookId = 5,
                    GenreId = 5
                }
                );

        }
    }
}
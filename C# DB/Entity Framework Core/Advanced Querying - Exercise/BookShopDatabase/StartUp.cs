namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Enums;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            BookShopContext context = new BookShopContext();
            Console.WriteLine(GetBooksByAuthor(context, "po"));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var age = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == age)
                .Select(x => new
                {
                    BookTitle = x.Title
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books.OrderBy(x => x.BookTitle))
            {
                sb.AppendLine(book.BookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .Select(x => new
                {
                    BookId = x.BookId,
                    Title = x.Title
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books.OrderBy(x => x.BookId))
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books.OrderByDescending(x => x.Price))
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    BookId = x.BookId,
                    Title = x.Title
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books.OrderBy(x => x.BookId))
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<string> toOrder = new List<string>();

            foreach (var item in categories)
            {
                var books = context.Books
                    .Where(x => x.BookCategories
                        .Any(c => String.Equals(c.Category.Name, item, StringComparison.CurrentCultureIgnoreCase)))
                    .Select(p => new
                    {
                        Title = p.Title
                    })
                    .ToArray();

                foreach (var book in books)
                {
                    toOrder.Add(book.Title);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in toOrder.OrderBy(x => x))
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate.Value < dateTime)
                .Select(x => new
                {
                    Title = x.Title,
                    EditionType = x.EditionType,
                    Price = x.Price,
                    ReleaseDate = x.ReleaseDate
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books.OrderByDescending(x => x.ReleaseDate))
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var author in authors.OrderBy(x=>x.FullName))
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => new
                {
                    Title = x.Title
                })
                .OrderBy(x => x.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => new
                {
                    BookId = x.BookId,
                    Title = x.Title,
                    AuthorFullName = x.Author.FirstName + " " + x.Author.LastName
                })
                .OrderBy(x => x.BookId)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Models.Enums;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            BookShopContext context = new BookShopContext();
            Console.WriteLine(GetBooksByPrice(context));
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
            foreach (var book in books.OrderByDescending(x=>x.Price))
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

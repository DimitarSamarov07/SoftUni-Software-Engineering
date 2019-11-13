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
            Console.WriteLine(GetBooksByAgeRestriction(context, "teEn"));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var age = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == age)
                .Select(x=>new
                {
                    BookTitle = x.Title
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books.OrderBy(x=>x.BookTitle))
            {
                sb.AppendLine(book.BookTitle);
            }

            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace solutions
{
    class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                Article article = new Article();
                var line = Console.ReadLine().Split(", ").ToArray();
                article.Title = line[0];
                article.Content = line[1];
                article.Author = line[2];

                articles.Add(article);
            }
            var criteria = Console.ReadLine();

            List<Article> ordered = new List<Article>();
            switch (criteria)
            {
                case "title": ordered = articles.OrderBy(p => p.Title).ToList(); break;
                case "content": ordered = articles.OrderBy(p => p.Content).ToList(); break;
                case "author": ordered = articles.OrderBy(p => p.Author).ToList(); break;
            }
            foreach (Article article in ordered)
            {
                Console.WriteLine(article);
            }
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";

        }
    }
}
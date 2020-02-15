using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    using System.Linq;
    using Data;
    using Models;
    using Models.Enums;
    using ViewModels.Products;

    public class ProductsService:IProductsService
    {
        private readonly AndreysDbContext db = new AndreysDbContext();
        public void CreateProduct(string name, string description, string imageUrl,
                                  string category, string gender, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Category = Enum.Parse<Category>(category),
                Gender = Enum.Parse<Gender>(gender),
                Price = price
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            IEnumerable<ProductViewModel> enumerable = new List<ProductViewModel>();
            enumerable = this.db.Products.Select(x=>new ProductViewModel
            {
                Id= x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Category = x.Category.ToString(),
                Gender = x.Gender.ToString(),
                Price = x.Price
            })
                .ToArray();

            return enumerable;
        }

        public ProductViewModel GetProductById(int id)
        {
            return this.db.Products.Where(x => x.Id == id)
                .Select(x => new ProductViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Category = x.Category.ToString(),
                    Gender = x.Gender.ToString(),
                    Description = x.Description,
                    Id = x.Id,
                    ImageUrl = x.ImageUrl
                })
                .FirstOrDefault();

        }

        public void RemoveProduct(int id)
        {
            this.db.Remove(this.db.Products.Find(id));
            this.db.SaveChanges();
        }
    }
}

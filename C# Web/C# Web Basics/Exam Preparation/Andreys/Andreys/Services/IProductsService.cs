using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    using Models;
    using ViewModels.Products;

    public interface IProductsService
    {
        void CreateProduct(string name, string description, string imageUrl,
                           string category, string gender, decimal price);

        IEnumerable<ProductViewModel> GetAll();

        ProductViewModel GetProductById(int id);

        void RemoveProduct(int id);
    }
}

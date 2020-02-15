using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Controllers
{
    using Models.Enums;
    using Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class ProductsController:Controller
    {
        private readonly IProductsService service;
        //https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.joma-sport.com%2Fen%2Fshirt-short-sleeve-ss-t-shirt-combi-cotton-navy-blue-100913.331&psig=AOvVaw1_N83U0v1QO1-S3mRfolvN&ust=1581855176200000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKCE7vXD0-cCFQAAAAAdAAAAABAD

        public ProductsController(IProductsService service)
        {
            this.service = service;
        }
        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(string name, string description, string imageUrl,
                                string category, string gender, decimal price)
        {

            if (name?.Length<4||name?.Length>20)
            {
                return this.Error("Name length should be in range 4-20 characters!");
            }

            if (description.Length>10)
            {
                return this.Error("Description length shouldn't be bigger than 10");
            }

            if (price==0||price<0)
            {
                return this.Error("The price should be at least 0$");
            }

            this.service.CreateProduct(name,description,imageUrl,category,gender,price);

            return this.Redirect("/");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }

            var product = this.service.GetProductById(id);
            return this.View(product);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }
            this.service.RemoveProduct(id);
            return this.Redirect("/");
        }
    }
}

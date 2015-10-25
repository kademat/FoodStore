using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodStore.Domain.Abstract;
using FoodStore.WebUI.Models;

namespace FoodStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 5;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        // GET: Product
        public ViewResult List(string category, int page = 1)
        {
            var model = new ProductsListViewModel
            {
                Products = repository.Products.
                    Where(p => category == null || p.Category == category).
                    OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo =
                    new PagingInfo() { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = 
                    category == null ? repository.Products.Count() : repository.Products.Count(e => e.Category == category) },
                CurrentCategory = category
            };
            return View(model);
            //return View(repository.Products.OrderBy(p => p.ProductID).Skip((page-1) * PageSize).Take(PageSize));
        }


    }
}
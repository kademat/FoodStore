using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodStore.Domain.Abstract;

namespace FoodStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        // GET: Product
        public ActionResult List()
        {
            return View(repository.Products);
        }

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
    }
}
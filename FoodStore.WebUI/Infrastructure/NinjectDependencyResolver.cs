using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodStore.Domain.Abstract;
using FoodStore.Domain.Concrete;
using FoodStore.Domain.Entities;
using Moq;
using Ninject;

namespace FoodStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();

            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product
            //    {
            //        Calories = 66,
            //        Category = "Alcohol",
            //        Description = "100 gram of wine",
            //        Name = "Wine",
            //        ProductID = 1
            //    },
            //    new Product
            //    {
            //        Calories = 215,
            //        Category = "Alcohol",
            //        Description = "100 gram of wodka",
            //        Name = "Wodka",
            //        ProductID = 2
            //    },
            //    new Product
            //    {
            //        Calories = 48,
            //        Category = "Alcohol",
            //        Description = "100 gram of beer",
            //        Name = "Beer",
            //        ProductID = 3
            //    },
            //    new Product
            //    {
            //        Calories = 211,
            //        Category = "Alcohol",
            //        Description = "100 gram of rum",
            //        Name = "Rum",
            //        ProductID = 4
            //    },
            //    new Product
            //    {
            //        Calories = 211,
            //        Category = "Fruits",
            //        Description = "100 gram of rum",
            //        Name = "Rum",
            //        ProductID = 5
            //    },
            //    new Product {Calories = 51, Category = "Fruits", Description = "1 apple", Name = "Apple", ProductID = 6},
            //    new Product {Calories = 42, Category = "Fruits", Description = "1 kiwi", Name = "Kiwi", ProductID = 7}
            //});
            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);//for the same mock object everytime
        }
    }
}
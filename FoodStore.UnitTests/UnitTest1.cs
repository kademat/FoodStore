using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using FoodStore.Domain.Abstract;
using FoodStore.Domain.Entities;
using FoodStore.WebUI.Controllers;
using FoodStore.WebUI.HtmlHelpers;
using FoodStore.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FoodStore.UnitTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Can_Paginate()
		{
			// Arrane
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new[]
			{
				new Product {ProductID = 1, Name = "P1"},
				new Product {ProductID = 2, Name = "P2"},
				new Product {ProductID = 3, Name = "P3"}, 
				new Product {ProductID = 4, Name = "P4"},
				new Product {ProductID = 5, Name = "P5"},
				new Product {ProductID = 6, Name = "P6"}
			});
			var controller = new ProductController(mock.Object);
			controller.PageSize = 3;
			//Act
			//var result = (IEnumerable<Product>)controller.List(2).Model;
			//if (result == null) throw new ArgumentNullException("result");
			ProductsListViewModel result = (ProductsListViewModel) controller.List(2).Model;
			// Assert
			Product[] prodArray = result.Products.ToArray();
			Assert.IsTrue(prodArray.Length == 3);
			Assert.AreEqual(prodArray[0].Name, "P4");
			Assert.AreEqual(prodArray[1].Name, "P5");

		}

		[TestMethod]
		public void Can_Generate_Page_Links()
		{
			//Arrange
			HtmlHelper myHelper = null;
			//Arrange
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = 2,
				TotalItems = 25,
				ItemsPerPage = 10
			};

			Func<int, string> pageUrlDelegate = i => "Page" + i;
			//Act
			MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
			//Assert
			string expectedResult = @"<a class=""btn btn-default"" href=""Page1"">1</a>";
			Assert.AreEqual(expectedResult, result.ToString().Substring(0, expectedResult.Length));
		}
	}
}

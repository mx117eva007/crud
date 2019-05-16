using System;
using System.Collections.Generic;
using System.Linq;
using CRUD;
using CRUDTest.Task;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock.EntityFramework;

namespace CRUDTest
{
    [TestClass]
    public class CRUDTest
    {
        [TestMethod]
        public void Save()
        {
            //arrange
            var context = Mock.CreateContext();

            //action
            CRUD.Businesses.CRUD.Save(context,
                new Product {ProductId = new Guid("CCB33F33-3D6D-409A-8879-5C3C195731BD"), Name = "小米手機", Price = 10000});

            //assert
            Assert.AreEqual(context.Product.Count(), 1);
        }

        [TestMethod]
        public void Query()
        {
            //arrange
            var context = Mock.CreateContext();
            var products = new List<Product>
            {
                new Product {ProductId = new Guid("CCB33F33-3D6D-409A-8879-5C3C195731BD"), Name = "小米手機", Price = 10000}
            };
            context.Product.Bind(products);

            //action
            var crud = new CRUD.Models.CRUD();
            CRUD.Businesses.CRUD.Query(context, crud);

            //assert
            Assert.AreSame(products.First(), crud.Products.First());
        }

        [TestMethod]
        public void QueryByKeyword()
        {
            //arrange
            var context = Mock.CreateContext();
            var products = new List<Product>
            {
                new Product {ProductId = new Guid("CCB33F33-3D6D-409A-8879-5C3C195731BD"), Name = "手機", Price = 10000},
                new Product {ProductId = new Guid("A141B179-E6CD-4FB9-A473-CA8317E1252D"), Name = "鞋子", Price = 1000}
            };
            context.Product.Bind(products);

            //action
            var crud = new CRUD.Models.CRUD {Keyword = "鞋"};
            CRUD.Businesses.CRUD.Query(context, crud);

            //assert
            Assert.AreEqual("鞋子", crud.Products.First().Name);
        }

        [TestMethod]
        public void Update()
        {
            //arrange
            var context = Mock.CreateContext();
            var products = new List<Product>
            {
                new Product {ProductId = new Guid("CCB33F33-3D6D-409A-8879-5C3C195731BD"), Name = "小米手機", Price = 10000}
            };
            context.Product.Bind(products);

            //action
            var product = new Product
            {
                ProductId = new Guid("CCB33F33-3D6D-409A-8879-5C3C195731BD"),
                Name = "小米手環",
                Price = 100
            };
            CRUD.Businesses.CRUD.Update(context, product);

            //assert
            Assert.AreEqual(product.Name, context.Product.First().Name);
            Assert.AreEqual(product.Price, context.Product.First().Price);
        }

        [TestMethod]
        public void Delete()
        {
            //arrange
            var context = Mock.CreateContext();
            var products = new List<Product>
            {
                new Product {ProductId = new Guid("CCB33F33-3D6D-409A-8879-5C3C195731BD"), Name = "小米手機", Price = 10000}
            };
            context.Product.Bind(products);

            //action
            CRUD.Businesses.CRUD.Delete(context, new Guid("CCB33F33-3D6D-409A-8879-5C3C195731BD"));

            //assert
            Assert.AreEqual(context.Product.Count(), 0);
        }
    }
}
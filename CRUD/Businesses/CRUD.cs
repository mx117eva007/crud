using System;
using System.Linq;

namespace CRUD.Businesses
{
    public class CRUD
    {
        /// <summary>
        ///     查詢
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        public static void Query(Database1Entities context, dynamic model)
        {
            var crud = (Models.CRUD) model;
            crud.Products.AddRange(context.Product.ToList());
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        public static void Update(Database1Entities context, dynamic model)
        {
            var product = (Product) model;
            var first = context.Product.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (first == null) return;
            first.Name = product.Name;
            first.Price = product.Price;
        }

        /// <summary>
        ///     儲存
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        public static void Save(Database1Entities context, dynamic model)
        {
            var product = (Product) model;
            product.ProductId = Guid.NewGuid();
            context.Product.Add(product);
        }

        /// <summary>
        ///     刪除
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        public static void Delete(Database1Entities context, dynamic model)
        {
            var product = (Product) model;
        }
    }
}
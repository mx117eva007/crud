using System.Collections.Generic;

namespace CRUD.Models
{
    public class CRUD
    {
        /// <summary>
        ///     新增
        /// </summary>
        public Product AddProduct = new Product();

        /// <summary>
        ///     刪除商品
        /// </summary>
        public Product DeleteProduct = new Product();

        /// <summary>
        ///     編輯商品
        /// </summary>
        public Product EditProduct = new Product();

        /// <summary>
        ///     查詢
        /// </summary>
        public List<Product> Products = new List<Product>();
    }
}
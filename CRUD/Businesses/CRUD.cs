using System.Linq;

namespace CRUD.Businesses
{
    public class CRUD
    {
        public static void Index(Database1Entities context, dynamic model)
        {
            var crud = (Models.CRUD) model;
            crud.Products.AddRange(context.Product.ToList());
        }
    }
}
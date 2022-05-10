using Resturant.DataAccess;
using Resturant.DataAccess.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Service
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProduct();
        Product GetProductById(int id);

        void AddProduct(Product product);

        IEnumerable<Product> GetProductByPagination(PagedResponse pagedResponse);

        void Delete(int id);

        //void UpdateProduct(Product product);

    }
}

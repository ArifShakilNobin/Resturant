using Resturant.DataAccess;
using Resturant.DataAccess.Filter;
using Resturant.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Service
{
    public class ProductRepo : IProductRepo
    {
        private IRepository<Product>? _repository;

        public ProductRepo(IRepository<Product>? repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product product)
        {
            _repository?.Add(product);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _repository.GetAll().OrderByDescending(c => c.Name).ThenBy(c => c.AddedDate);
            //return _context.Companies.Distinct().ToList();

        }

        public Product GetProductById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Product> GetProductByPagination(PagedResponse pagedResponse)
        {
            return _repository.FindAll()
                .OrderBy(on => on.Name)
                .Skip((pagedResponse.PageNumber - 1) * pagedResponse.PageSize)
                .Take(pagedResponse.PageSize)
                .ToList();
        }

        public void Delete(int id)
        {
            _repository?.Delete(id);
        }

        //public void UpdateProduct(Product product)
        //{

        //    var products = _repository?.GetAll().FirstOrDefault(p => p.Id == product.Id);
        //    //if (products != null)
        //    //{
        //    //    products.Name = product.Name;
        //    //    products.price = product.price;
        //    //    products.Description = product.Description;
        //    //}
        //    _repository?.Update(product);

        //}
    }
}

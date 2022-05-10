using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.DataAccess;
using Resturant.DataAccess.Filter;
using Resturant.DataAccess.Response;
using Resturant.Service;

namespace Resturant.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo? _repo;

        public ProductController(IProductRepo? repo)
        {
            _repo = repo;
        }


        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest(new ApiResponse(true, "Product object is null", null));
                }
                //if (ModelState.IsValid)
                //{
                //    var isCompanyNameAlreadyExists = _unitOfWork.Companies.companyAlreadyexist(company.companyName);
                //    if (isCompanyNameAlreadyExists)
                //    {
                //        ModelState.AddModelError("Company Name", "Company with this name already exists");
                //        return BadRequest(new ApiResponse(true, "Company with this name already exists", null));

                //    }
                //}
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(true, "Invalid model object", null));

                }
                else
                {
                    _repo.AddProduct(product);
                }
                return Ok(new ApiResponse(true, "Data Saved", _repo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }


        }




        [HttpGet]
        public IActionResult getAllProduct()
        {
            //var products = _repo?.GetAllProduct();
            //return Ok(products);

            try
            {
                //var response = _unitOfWork.Companies.GetAllCompany().OrderByDescending(c => c.companyName).ThenBy(c => c.AddedDate);
                var response = _repo?.GetAllProduct();
                return Ok(new ApiResponse(true, "Product data load successfully", response));

            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(true, "Product data load failed", null));
            }
        }

        [HttpGet]
        [Route("getProductById")]
        public IActionResult getProductById(int id)
        {

            try
            {
                var response = _repo?.GetProductById(id);
                return Ok(new ApiResponse(true, "Product data load successfully", response));

            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(true, "Product data load failed", null));
            }
        }


        [HttpGet]
        [Route("GetProduct")]
        public IActionResult GetCompanyByPage([FromQuery] PagedResponse pagedResponse)
        {
            try
            {
                var response = _repo?.GetProductByPagination(pagedResponse);
                return Ok(new ApiResponse(true, "Product data load successfully", response));

            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(true, "Product data load failed", null));
            }
        }


        [HttpDelete]
        public IActionResult DeletProduct(int id)
        {
            try
            {
                var productToDelete = _repo?.GetProductById(id);
                if (productToDelete == null)
                {
                    return NotFound();
                }
                else
                {
                    _repo?.Delete(id);
                }

                return Ok(new ApiResponse(true, "Product delete", _repo));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(true, "Product data load failed", null));
            }
        }

        //[HttpPut]
        //public IActionResult UpdateProduct(int id, [FromBody] Product product)
        //{
        //    try
        //    {
        //        //if (id != product.Id)
        //        //{
        //        //    return BadRequest("Employee ID mismatch");
        //        //}

        //        //var employeeToUpdate =  _repo?.GetProductById(id);

        //        //if (employeeToUpdate == null)
        //        //{
        //        //    return NotFound($"Employee with Id = {id} not found");
        //        //}



        //        _repo?.UpdateProduct(product);
        //        return Ok(new ApiResponse(true, "Product update", _repo));
        //    }
        //    catch(Exception ex)
        //    {
        //        return Ok(new ApiResponse(true, "Error updating data", _repo));
        //    }
        //}


    }
}

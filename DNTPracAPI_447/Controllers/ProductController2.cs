using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstraction;

namespace DNTPracAPI_447.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController2 : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController2(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        //Addedcode to fetch all products from the repository and return them as a response.
        //This method handles potential exceptions and returns appropriate HTTP status codes based on the outcome of the operation.
        [HttpGet]
        [Route("DisplayAllProducts")]
        ///This method retrieves all products from the repository and returns them as a response. 
        ///It handles potential exceptions and returns appropriate HTTP status codes based on the outcome of the operation.
        ///Created By : Raghav Created Date: 2026-07-03
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productRepo.GetAllProducts();
                if (products != null)
                {
                    return StatusCode(StatusCodes.Status200OK, products);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
            
        }
    }
}

using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstraction;

namespace DNTPracAPI_447.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IConfiguration _configuration;
        public ProductController(IProductRepository productRepo, IConfiguration configuration)
        {
            _configuration = configuration;
            _productRepo = productRepo;
        }
        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllProducts()
        {
            string env = _configuration.GetSection("ApplicationSettings:ApplicationName").Value;
            Console.Write(env);
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
        //[Route("GetProductById/{id}")]
        //[ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public IActionResult GetProductById(int id)
        //{
        //    try
        //    {
        //         var product = _productRepo.GetProductById(id);

        //         if (product != null)
        //         {
        //            return StatusCode(StatusCodes.Status200OK, product);
        //         }
        //         else
        //         {
        //            return StatusCode(StatusCodes.Status404NotFound);
        //         }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex);
        //    }

        //}
        [HttpGet]
        [Route("AddProduct")]
        public IActionResult AddProduct(Product productToAdd)
        {
            if (ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status201Created, true);
            }
                _productRepo.AddProduct(productToAdd);
            return StatusCode(StatusCodes.Status400BadRequest);

        }
        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(Product productToUpdate)
        {
         
            if (ModelState.IsValid)
            {
                _productRepo.UpdateProduct(productToUpdate);
                return StatusCode(StatusCodes.Status200OK, true);
            }
            return StatusCode(StatusCodes.Status400BadRequest);

        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            var isDeleted = _productRepo.DeleteProduct(id);
            if (isDeleted)
            {
                return StatusCode(StatusCodes.Status200OK, true);
            }
            return StatusCode(StatusCodes.Status404NotFound);

        }
    }
}

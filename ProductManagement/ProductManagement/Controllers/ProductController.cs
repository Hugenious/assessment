using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        //Product collection list.
        static List<Product> productList = new List<Product>
        {
            new Product { ProductId = 1, Name = "LEGO® Technic™ Liebherr Crawler Crane", Description = "LEGO® Technic™ Liebherr Crawler Crane LR 13000 42146 Building Toy Cars (2,883 Pieces)", Price = 9636 },
            new Product { ProductId = 2, Name = "LEGO® Technic NASA Apollo Lunar Roving Vehicle", Description = "LEGO® Technic NASA Apollo Lunar Roving Vehicle – LRV 42182", Price = 3182 },
            new Product { ProductId = 3, Name = "LEGO® Icons Lamborghini Countach 5000", Description = "LEGO® Icons Lamborghini Countach 5000 Quattrovalvole 10337", Price = 2674 },
            new Product { ProductId = 4, Name = "LEGO® Icons Transformers Bumblebee", Description = "LEGO® Icons Transformers Bumblebee Set 10338", Price = 1322 }
        };

        //Get all products from collection.
        [HttpGet]
        public ActionResult<List<Product>> ProductsGetAll()
        {
            try
            {
                return Ok(productList); //return full product collection.
            }
            catch (Exception ex) //Error handling.
            {
                _logger.LogError(ex, "Error fetching products.");
                return StatusCode(500, new { message = "An error occurred while retrieving products." });
            }
        }

        //Get product using product Id.
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            try
            {
                var product = productList.FirstOrDefault(p => p.ProductId == id); //Get product id from collection.
                if (product == null) return NotFound(); //Check if a product was found.
                return Ok(product); //Return product if found.
            }
            catch (Exception ex) //Error handling.
            {
                _logger.LogError(ex, "Error fetching product using id.");
                return StatusCode(500, new { message = "An error occurred while retrieving product." });
            }
        }

        //Create new product.
        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product product)
        {
            try
            {
                if (product == null) return BadRequest(); //Check if product passed is null.

                //Generate new product id , checking the last id used in the collection.
                product.ProductId = productList.Count > 0 ? productList.Max(p => p.ProductId) + 1 : 1;
                productList.Add(product);

                //Product created successfuly.
                return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
            }
            catch (Exception ex) //Error handling
            {
                _logger.LogError(ex, "Error creating product.");
                return StatusCode(500, new { message = "An error occurred while creating product." });
            }
        }

        //Update product specifying the product id to update
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product updatedProduct)
        {
            try
            {
                //Get product that need to be updated from collection using the product id.
                var product = productList.FirstOrDefault(p => p.ProductId == id);
                //If product not found.
                if (product == null) return NotFound(); 

                //Set product new info
                product.Name = updatedProduct.Name;
                product.Description = updatedProduct.Description;
                product.Price = updatedProduct.Price;

                return NoContent(); //Nothing to return.
            }
            catch (Exception ex) //Error handling.
            {
                _logger.LogError(ex, "Error updating product.");
                return StatusCode(500, new { message = "An error occurred while updating product." });
            }
        }

        //Delete product, specifying product id to delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Get product from collection that need to be deleted using product id.
                var product = productList.FirstOrDefault(p => p.ProductId == id);

                //Check if product to delete is found.
                if (product == null) return NotFound(); 

                //Delete the product.
                productList.Remove(product);
                return NoContent();
            }
            catch (Exception ex) //Error handling.
            {
                _logger.LogError(ex, "Error deleting product.");
                return StatusCode(500, new { message = "An error occurred while deleting product." });
            }
        }

    }
}

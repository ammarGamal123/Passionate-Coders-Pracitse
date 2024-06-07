using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplicationV1._0.Authorization;
using WebApplicationV1._0.Data;
using WebApplicationV1._0.Filters;

namespace WebApplicationV1._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(ApplicationDbContext context,
                                  ILogger<ProductsController> logger)
        {
            _context = context;
            this.logger = logger;
        }

        [HttpGet]
        [Route("GetProducts")]
        [CheckPermission(Permission.ReadProducts)]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var userName = User.Identity.Name;
            var userId = ((ClaimsIdentity)User.Identity).
                FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var products = _context.Set<Product>().ToList();
            
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        [CheckPermission(Permission.ReadProducts)]
        [LogSensitiveAction]
        public ActionResult<Product> GetById (int id)
        {
            logger.LogDebug("Getting Product #{id} " + id);
            var product = _context.Set<Product>().Find(id);

            if (product == null)
            {
                logger.LogDebug("Product #{id} was not found -- time{y} " ,
                                id , DateTime.Now);
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = 0;

            _context.Set<Product>().Add(product);
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public ActionResult<Product> UpdateProduct(Product product)
        {

            var existingProduct = _context.Set<Product>().Find(product.Id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Sku = product.Sku;

            _context.Set<Product>().Update(existingProduct);

            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete]
        [Route("DeleteProduct{id:int}")]
        public ActionResult<int> DeleteProduct(int id)
        {
            var existingProduct = _context.Set<Product>().Find(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            _context.Set<Product>().Remove(existingProduct);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}

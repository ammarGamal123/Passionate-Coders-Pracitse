using Microsoft.AspNetCore.Mvc;
using WebApplicationV1._0.Data;

namespace WebApplicationV1._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = 0;

            _context.Set<Product>().Add(product);
            _context.SaveChanges();

            return Ok(product);
        }


        [HttpPut]
        [Route("")]
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
        [Route("{id}")]
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

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _context.Set<Product>().ToList();

            return Ok(products);
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _context.Set<Product>().Find(id);
            
            if (product == null)
                return NotFound();

            return Ok(product);
        }

    }
}

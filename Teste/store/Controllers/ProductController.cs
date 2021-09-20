using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;
using store.Data;

namespace store.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("listarprodutos")]
        public async Task<ActionResult<List<Product>>> GetListProducts([FromServices] DataContext context)
        {
            var products = await context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }

        //Get do id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult  <Product>> GetProductById([FromServices] DataContext context, int id)
        {
            var products = await context.Products.Include(x => x.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return products;    
        }


        //Get do Nome
        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<Product>> GetProductByName([FromServices] DataContext context, string name)
        {
            var products = await context.Products.Include(x => x.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == name);
            return products;    
        }

        //Get do Nome
        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetProductByCategory([FromServices] DataContext context, int id)
        {
            var products = await context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .Where(x => x.CategoryId == id)
            .ToListAsync();
            return products;    
        }

        [HttpPost]
        [Route("criar")]
        public async Task<ActionResult<Product>> PostCreateProduct([FromServices] DataContext context, [FromBody] Product modelProduct) 
        {
            if(ModelState.IsValid)
            {
                context.Products.Add(modelProduct);
                await context.SaveChangesAsync();
                return modelProduct;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
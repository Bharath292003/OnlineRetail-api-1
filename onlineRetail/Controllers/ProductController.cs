using LazyCache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using onlineRetail.Caching;
using onlineRetail.Model;
using onlineRetail.Repository;
using onlineRetail.Repository.IRepository;
using System.Diagnostics;

namespace onlineRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;
        private ICacheProvider _cacheProvider;
     
        public ProductController(IProductRepository productRepository,ILogger<ProductController> logger,ICacheProvider cacheProvider) 
        {
            _productRepository = productRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
            //_cache = cache;
            
        }
        [HttpGet]
        [Route("/Getproductbycache")]
        public async Task<ActionResult> GetCustomerCache()
        {
            if (_cacheProvider.TryGetValue(cachekeys.product, out List<Product> products))
                return Ok(products);

             products = await _productRepository.GetAll();

            var cacheEntryOption = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(30),
                Size = 1024
            };
            _cacheProvider.Set(cachekeys.product, products, cacheEntryOption);


            return Ok(products);
        }
        //public IActionResult Index()
        //{
        //    var stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    if(_cache.TryGetValue(cachekey, out IEnumerable<Product> products)) 
        //    {
        //        _logger.Log(LogLevel.Information, "products found in cache");
        //    }
        //}
        [HttpGet]
        [Route ("Getproduct")]
        public async Task<IActionResult> Getproduct() 
        {
            var Product = await _productRepository.GetAll();
            if(Product == null)
            {
                return NotFound();
            }
            return Ok(Product);

        }
        [HttpGet("GetProductbyID")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetProductbyID(Guid ID) 
        {
            var Product = await _productRepository.GetById(ID);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }
        [HttpGet("GetProductbyName")]
        public async Task<IActionResult> GetProductbyName(string Name)
        {
            var products1=await _productRepository.GetAll();
            if (products1 == null)
            {
                return NotFound();
            }
            var products = await _productRepository.GetByName(Name);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Postproduct(Product pro)
        {
            var postpro = await _productRepository.Create(pro);
            return CreatedAtAction(nameof(Getproduct), new { ID = pro.productId }, pro);
        }
        [HttpPut("PutProductbyId")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutProductbyId(Guid productId, Product pro)
        {
            var putpro = await _productRepository.Update(productId, pro);
            if (!(putpro))
            {
                return NotFound();
            }
            return Ok();
        }
        
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var products1 = await _productRepository.GetAll();
            if (products1 == null)
            {
                return NotFound();
            }
            var productdel = await _productRepository.Delete(productId);
            if (productdel == false)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}

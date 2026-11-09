using CustomMiddleWareApis.Modal;
using Microsoft.AspNetCore.Mvc;

namespace CustomMiddleWareApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("productList")]
        public async Task<IActionResult> ProductList()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://fakestoreapi.com/");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync("products");
            return Ok(response);
        }

        [HttpPost("createProduct")]
        public IActionResult CreateProductList(Product product)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://fakestoreapi.com/");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.PostAsJsonAsync("product", product).Wait();

            return RedirectToAction("ProductList");
        }
        
        [HttpGet("productDetails")]
        public IActionResult ProductDetails(int productId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://fakestoreapi.com/");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = httpClient.GetAsync($"products/{productId}");
            return Ok(response);
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Api
{
    public class ProductGet
    {
        private readonly IProductData productData;

        public ProductGet(IProductData productData)
        {
            this.productData = productData;
        }

        [FunctionName("ProductGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req)
        {
            var products = await productData.GetProducts();
            return new OkObjectResult(products);
        }
    }
}
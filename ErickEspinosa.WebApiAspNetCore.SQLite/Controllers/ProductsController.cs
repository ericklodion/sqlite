using ErickEspinosa.SQLite.Application.Services.Interfaces;
using ErickEspinosa.SQLite.Data.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErickEspinosa.WebApiAspNetCore.SQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.GetProducts());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _productService.CreateProduct(product);
            return Ok();
        }

        [HttpDelete]
        [Route("{guid}")]
        public async Task<IActionResult> Delete(string guid)
        {
            await _productService.DeleteProduct(guid);
            return Ok();
        }
    }
}

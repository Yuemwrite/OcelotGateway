using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductsController : ControllerBase
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        
        
    }

    private static List<Product> _product = new List<Product>()
    {
        new()
        {
            ProductId = 1,
            ProductName = "Notebook"
        },
        new()
        {
            ProductId = 2,
            ProductName = "Mobile Phone"
        },
        new()
        {
            ProductId = 3,
            ProductName = "Keyboard"
        }
    };
        
    

    [HttpGet("getProduct")]
    public IActionResult Get()
    {
        return Ok(_product);
    }

    [HttpGet("productId")]
    public IActionResult Get(int productId)
    {
        var data = _product.FirstOrDefault(_ => _.ProductId == productId);
        return Ok(data);
    }

    [HttpPost("addProduct")]
    public IActionResult AddProduct(Product products)
    {
        _product.Add(products);
        return Ok(products);
    }

    [HttpPut("updateProduct")]
    public IActionResult UpdateProduct(Product products)
    {
        var editProduct = _product.FirstOrDefault(x => x.ProductId == products.ProductId);
        editProduct.ProductName = products.ProductName;
        return Ok(products);
    }

    [HttpDelete("deleteProduct")]
    public IActionResult DeleteProduct(Product products)
    {
        var deleteProduct = _product.FirstOrDefault(x => x.ProductId == products.ProductId);
        _product.Remove(deleteProduct);
        return Ok(products.ProductId);
    }
    
}
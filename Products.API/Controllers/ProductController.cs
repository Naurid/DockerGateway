using Microsoft.AspNetCore.Mvc;
using Products.API.Model;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(List<ProductModel> pl) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(pl);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                ProductModel? order = pl.FirstOrDefault(x => x.Id == id);

                if (order is null) return NotFound("No such product");

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                List<ProductModel> orders = pl.Where(x => x.Name.Contains(name)).ToList();

                if (orders.Count == 0) return NotFound("No products with this name");

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{name}/{price}")]
        public IActionResult CreateOrder(string name, float price)
        {
            try
            {
                ProductModel newProduct = new ProductModel() { Id = pl.Max(x=>x.Id) + 1, Name = name, Price = price };
                pl.Add(newProduct);
                return CreatedAtAction(nameof(GetByID), new {id= newProduct.Id}, newProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}/{total}")]
        public IActionResult UpdateOrder(int id, float price)
        {
            try
            {
                ProductModel? model = pl.FirstOrDefault(x => x.Id == id);
                if (model is null) return NotFound("No such product");

                model.Price = price;
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                ProductModel? model = pl.FirstOrDefault(x => x.Id == id);
                if (model is null) return NotFound("No such product");
                pl.Remove(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

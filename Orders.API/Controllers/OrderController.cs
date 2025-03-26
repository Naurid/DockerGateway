using Microsoft.AspNetCore.Mvc;
using Orders.API.Models;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(List<OrderModel> ol) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ol);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                OrderModel? order = ol.FirstOrDefault(x => x.Id == id);

                if (order is null) return NotFound("No such order");

                return Ok(order);
            }
            catch(Exception ex)  
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                List<OrderModel> orders = ol.Where(x => x.ClientName.ToLower().Replace(" ", "").Contains(name.ToLower().Replace(" ", ""))).ToList();

                if (orders.Count == 0) return NotFound("No orders");

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{name}/{total}")]
        public IActionResult CreateOrder(string name, float total)
        {
            try
            {
                OrderModel newOrder = new OrderModel() {Id= ol.Max(x=>x.Id) + 1, ClientName=name, Total=total };
                ol.Add(newOrder);
                return CreatedAtAction(nameof(GetByID), new { id = newOrder.Id }, newOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}/{total}")]
        public IActionResult UpdateOrder(int id, float total)
        {
            try
            {
                OrderModel? model = ol.FirstOrDefault(x => x.Id == id);

                if (model is null) return NotFound("No such order");

                model.Total = total;
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
                OrderModel? model = ol.FirstOrDefault(x => x.Id == id);

                if (model is null) return NotFound("No such order");
                ol.Remove(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

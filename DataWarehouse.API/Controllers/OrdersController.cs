using DataWarehouse.API.Models.RecordModels;
using DataWarehouse.API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataWarehouse.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly OrderRepository _repository;

    public OrdersController(OrderRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await _repository.GetOrdersAsync();
        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Order order)
    {
        await _repository.CreateOrderAsync(order);
        return Ok(order);
    }
}


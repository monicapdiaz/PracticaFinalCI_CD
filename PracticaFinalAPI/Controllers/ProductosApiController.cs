using Microsoft.AspNetCore.Mvc;
using PracticaFinalAPI.Models;
using PracticaFinalAPI.Services;

namespace PracticaFinalAPI.Controllers;

[ApiController]
[Route("api/productos")]
public class ProductosApiController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosApiController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    // GET: api/productos
    [HttpGet]
    public ActionResult<IEnumerable<Producto>> Get()
    {
        return Ok(_productoService.GetAll());
    }

    // GET: api/productos/5
    [HttpGet("{id}")]
    public ActionResult<Producto> Get(int id)
    {
        var producto = _productoService.GetById(id);
        if (producto == null)
        {
            return NotFound($"Producto con ID {id} no encontrado.");
        }
        return Ok(producto);
    }

    // POST: api/productos
    [HttpPost]
    public ActionResult<Producto> Post([FromBody] Producto producto)
    {
        if (producto == null)
        {
            return BadRequest("El producto no puede ser nulo.");
        }

        var nuevoProducto = _productoService.Create(producto);
        return CreatedAtAction(nameof(Get), new { id = nuevoProducto.Id }, nuevoProducto);
    }

    // PUT: api/productos/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Producto producto)
    {
        if (producto == null)
        {
            return BadRequest("El producto no puede ser nulo.");
        }

        if (!_productoService.Update(id, producto))
        {
            return NotFound($"Producto con ID {id} no encontrado.");
        }

        return NoContent();
    }

    // DELETE: api/productos/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_productoService.Delete(id))
        {
            return NotFound($"Producto con ID {id} no encontrado.");
        }

        return NoContent();
    }
}


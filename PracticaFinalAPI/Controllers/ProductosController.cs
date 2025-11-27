using Microsoft.AspNetCore.Mvc;
using PracticaFinalAPI.Models;
using PracticaFinalAPI.Services;

namespace PracticaFinalAPI.Controllers;

public class ProductosController : Controller
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    // GET: Productos
    public IActionResult Index()
    {
        var productos = _productoService.GetAll();
        return View(productos);
    }

    // GET: Productos/Details/5
    public IActionResult Details(int id)
    {
        var producto = _productoService.GetById(id);
        if (producto == null)
        {
            return NotFound();
        }
        return View(producto);
    }

    // GET: Productos/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Productos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Nombre,Descripcion,Precio,Stock")] Producto producto)
    {
        if (ModelState.IsValid)
        {
            _productoService.Create(producto);
            TempData["SuccessMessage"] = "Producto creado exitosamente.";
            return RedirectToAction(nameof(Index));
        }
        return View(producto);
    }

    // GET: Productos/Edit/5
    public IActionResult Edit(int id)
    {
        var producto = _productoService.GetById(id);
        if (producto == null)
        {
            return NotFound();
        }
        return View(producto);
    }

    // POST: Productos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,Stock")] Producto producto)
    {
        if (id != producto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            if (!_productoService.Update(id, producto))
            {
                return NotFound();
            }
            TempData["SuccessMessage"] = "Producto actualizado exitosamente.";
            return RedirectToAction(nameof(Index));
        }
        return View(producto);
    }

    // GET: Productos/Delete/5
    public IActionResult Delete(int id)
    {
        var producto = _productoService.GetById(id);
        if (producto == null)
        {
            return NotFound();
        }
        return View(producto);
    }

    // POST: Productos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        if (!_productoService.Delete(id))
        {
            return NotFound();
        }
        TempData["SuccessMessage"] = "Producto eliminado exitosamente.";
        return RedirectToAction(nameof(Index));
    }
}

using PracticaFinalAPI.Models;

namespace PracticaFinalAPI.Services;

public class ProductoService : IProductoService
{
    private static readonly List<Producto> _productos = new()
    {
        new Producto { Id = 1, Nombre = "Laptop", Descripcion = "Laptop Dell XPS 15", Precio = 1500.00m, Stock = 10 },
        new Producto { Id = 2, Nombre = "Mouse", Descripcion = "Mouse inalámbrico Logitech", Precio = 25.99m, Stock = 50 },
        new Producto { Id = 3, Nombre = "Teclado", Descripcion = "Teclado mecánico RGB", Precio = 89.99m, Stock = 30 }
    };

    public IEnumerable<Producto> GetAll()
    {
        return _productos;
    }

    public Producto? GetById(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public Producto Create(Producto producto)
    {
        var nuevoId = _productos.Any() ? _productos.Max(p => p.Id) + 1 : 1;
        producto.Id = nuevoId;
        _productos.Add(producto);
        return producto;
    }

    public bool Update(int id, Producto producto)
    {
        var productoExistente = _productos.FirstOrDefault(p => p.Id == id);
        if (productoExistente == null)
        {
            return false;
        }

        productoExistente.Nombre = producto.Nombre;
        productoExistente.Descripcion = producto.Descripcion;
        productoExistente.Precio = producto.Precio;
        productoExistente.Stock = producto.Stock;
        return true;
    }

    public bool Delete(int id)
    {
        var producto = _productos.FirstOrDefault(p => p.Id == id);
        if (producto == null)
        {
            return false;
        }

        _productos.Remove(producto);
        return true;
    }
}


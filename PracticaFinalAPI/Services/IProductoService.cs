using PracticaFinalAPI.Models;

namespace PracticaFinalAPI.Services;

public interface IProductoService
{
    IEnumerable<Producto> GetAll();
    Producto? GetById(int id);
    Producto Create(Producto producto);
    bool Update(int id, Producto producto);
    bool Delete(int id);
}


using Microsoft.AspNetCore.Mvc;
using PracticaFinalAPI.Controllers;
using PracticaFinalAPI.Models;
using PracticaFinalAPI.Services;
using Xunit;
using System.Collections.Generic;

namespace PracticaFinalAPI.Tests;

public class ProductosControllerTests
{
    private readonly IProductoService _productoService;

    public ProductosControllerTests()
    {
        _productoService = new ProductoService();
    }

    [Fact]
    public void Get_ReturnsOkResult()
    {
        // Arrange
        var controller = new ProductosApiController(_productoService);

        // Act
        var result = controller.Get();

        // Assert
        var okResult = Assert.IsType<ActionResult<IEnumerable<Producto>>>(result);
        Assert.NotNull(okResult);
    }

    [Fact]
    public void Get_WithValidId_ReturnsOkResult()
    {
        // Arrange
        var controller = new ProductosApiController(_productoService);
        int id = 1;

        // Act
        var result = controller.Get(id);

        // Assert
        var okResult = Assert.IsType<ActionResult<Producto>>(result);
        Assert.NotNull(okResult);
    }

    [Fact]
    public void Get_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        var controller = new ProductosApiController(_productoService);
        int id = 999;

        // Act
        var result = controller.Get(id);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public void Post_WithValidProducto_ReturnsCreatedAtAction()
    {
        // Arrange
        var controller = new ProductosApiController(_productoService);
        var nuevoProducto = new Producto
        {
            Nombre = "Test Product",
            Descripcion = "Test Description",
            Precio = 99.99m,
            Stock = 10
        };

        // Act
        var result = controller.Post(nuevoProducto);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.NotNull(createdResult);
        Assert.Equal(nuevoProducto.Nombre, ((Producto)createdResult.Value!).Nombre);
    }

    [Fact]
    public void Post_WithNullProducto_ReturnsBadRequest()
    {
        // Arrange
        var controller = new ProductosApiController(_productoService);

        // Act
        var result = controller.Post(null!);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
}


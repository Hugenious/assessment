using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductManagement.Controllers;
using ProductManagement.Models;
using System.Reflection;

[TestClass]
public class ProductManagerTests
{
    private ProductController _controller;

    [TestInitialize]
    public void Setup()
    {
        // Create a mock logger
        var mockLogger = new Mock<ILogger<ProductController>>();

        // Initialize the controller with the mock logger
        _controller = new ProductController(mockLogger.Object);

        // Clear the static product list to ensure the test starts with an empty list
        var fieldInfo = typeof(ProductController).GetField("productList", BindingFlags.NonPublic | BindingFlags.Static);
        var list = fieldInfo.GetValue(null) as List<Product>;
        list.Clear(); // Clear existing data

        // Add test data to the static productList
        list.Add(new Product { ProductId = 1, Name = "Product 1", Description = "Description 1", Price = 100 });
        list.Add(new Product { ProductId = 2, Name = "Product 2", Description = "Description 2", Price = 200 });
    }

    [TestMethod]
    public void ProductsGetAll_ReturnsOk_WhenProductsExist()
    {
        // Act
        var result = _controller.ProductsGetAll(); // Call the method

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.IsInstanceOfType(okResult, typeof(OkObjectResult)); // Ensure result is OK status
        var products = okResult.Value as List<Product>;
        Assert.IsNotNull(products); // Assert that the product list is not null
        Assert.AreEqual(2, products.Count); // Verify the number of products (2 in this case)
    }

    [TestMethod]
    public void GetById_ReturnsProduct_WhenProductExists()
    {
        // Act
        var result = _controller.GetById(1); // Call the method with ID 1

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsInstanceOfType(okResult, typeof(OkObjectResult)); // Ensure result is OK status
        var product = okResult.Value as Product;
        Assert.IsNotNull(product); // Ensure the product is not null
        Assert.AreEqual(1, product.ProductId); // Ensure the correct product is returned
    }

    [TestMethod]
    public void GetById_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Act
        var result = _controller.GetById(999); // Call the method with a non-existent ID

        // Assert
        var notFoundResult = result.Result as NotFoundResult;
        Assert.IsNotNull(notFoundResult); // Ensure that NotFoundResult is returned
    }

    [TestMethod]
    public void Create_ReturnsCreatedProduct_WhenProductIsValid()
    {
        // Arrange
        var newProduct = new Product { Name = "Product 3", Description = "Description 3", Price = 150 };

        // Act
        var result = _controller.Create(newProduct); // Call the method to create a new product

        // Assert
        var createdResult = result.Result as CreatedAtActionResult;
        Assert.IsNotNull(createdResult); // Ensure the product was created
        Assert.IsInstanceOfType(createdResult, typeof(CreatedAtActionResult)); // Ensure result is Created status
        var product = createdResult.Value as Product;
        Assert.IsNotNull(product); // Ensure the created product is not null
        Assert.AreEqual("Product 3", product.Name); // Verify the created product name
    }

    [TestMethod]
    public void Create_ReturnsBadRequest_WhenProductIsNull()
    {
        // Act
        var result = _controller.Create(null); // Call the method with a null product

        // Assert
        var badRequestResult = result.Result as BadRequestResult;
        Assert.IsNotNull(badRequestResult); // Ensure a BadRequestResult is returned
    }

    [TestMethod]
    public void Update_ReturnsNoContent_WhenProductIsUpdatedSuccessfully()
    {
        // Arrange
        var updatedProduct = new Product { Name = "Updated Product", Description = "Updated Description", Price = 250 };

        // Act
        var result = _controller.Update(1, updatedProduct); // Call the update method

        // Assert
        var noContentResult = result as NoContentResult;
        Assert.IsNotNull(noContentResult); // Ensure a NoContentResult is returned
    }

    [TestMethod]
    public void Update_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var updatedProduct = new Product { Name = "Non-Existent Product", Description = "Non-Existent Description", Price = 500 };

        // Act
        var result = _controller.Update(999, updatedProduct); // Call the update method with a non-existent ID

        // Assert
        var notFoundResult = result as NotFoundResult;
        Assert.IsNotNull(notFoundResult); // Ensure that NotFoundResult is returned
    }

    [TestMethod]
    public void Delete_ReturnsNoContent_WhenProductIsDeletedSuccessfully()
    {
        // Act
        var result = _controller.Delete(1); // Call the delete method

        // Assert
        var noContentResult = result as NoContentResult;
        Assert.IsNotNull(noContentResult); // Ensure that NoContentResult is returned
    }

    [TestMethod]
    public void Delete_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Act
        var result = _controller.Delete(999); // Call the delete method with a non-existent ID

        // Assert
        var notFoundResult = result as NotFoundResult;
        Assert.IsNotNull(notFoundResult); // Ensure that NotFoundResult is returned
    }
}

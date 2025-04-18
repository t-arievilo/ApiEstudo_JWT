using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiEstudo.Controllers;
using ApiEstudo.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstudoxUnitTests.UnitTests
{
    public class DeleteProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
    {
        private readonly ProdutosController _controller;

        public DeleteProdutoUnitTests(ProdutosUnitTestController setup)
        {
            _controller = new ProdutosController(setup.repository);
        }

        [Fact]
        public async Task DeleteProduto_Return_Ok()
        {
            // Arrange
            var prodId = 11;
            // Act
            var result = await _controller.Delete(prodId) as ActionResult<ProdutoDTO>;
            // Assert
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task DeleteProduto_Return_NotFound()
        {
            // Arrange
            var prodId = 1000;
            // Act
            var result = await _controller.Delete(prodId) as ActionResult<ProdutoDTO>;
            // Assert
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}

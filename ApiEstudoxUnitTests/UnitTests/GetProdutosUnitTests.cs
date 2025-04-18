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
    public class GetProdutosUnitTests : IClassFixture<ProdutosUnitTestController>
    {
        private readonly ProdutosController _controller;

        public GetProdutosUnitTests(ProdutosUnitTestController setup)
        {
            _controller = new ProdutosController(setup.repository);
        }

        [Fact]
        public async Task GetProdutoById_OKResult()
        {
            // Arrange
            var prodId = 2;

            // Act
            var data = await _controller.Get(prodId);

            // Assert
            data.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetProdutoById_NotFoundResult()
        {
            // Arrange
            var prodId = 100;

            // Act
            var data = await _controller.Get(prodId);

            // Assert
            data.Result.Should().BeOfType<NotFoundObjectResult>()
                .Which.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GetProdutoById_Return_BadRequest()
        {
            //Arrange
            int prodId = -1;

            //Act
            var data = await _controller.Get(prodId);

            //Assert
            data.Result.Should().BeOfType<BadRequestObjectResult>()
                .Which.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetProdutos_Return_ListOfProdutoDTO()
        {
            //Act
            var data = await _controller.Get();

            //Assert
            data.Result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeAssignableTo<IEnumerable<ProdutoDTO>>()
                .And.NotBeNull();
        }

        [Fact]
        public async Task GetProdutos_Return_BadRequestResult()
        {
            //Act
            var data = await _controller.Get();

            //Assert
            data.Result.Should().BeOfType<BadRequestResult>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiEstudo.Controllers;
using ApiEstudo.DTOs;
using ApiEstudo.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstudoxUnitTests.UnitTests
{
    public class PostProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
    {
        private readonly ProdutosController _controller;

        public PostProdutoUnitTests(ProdutosUnitTestController setup)
        {
            _controller = new ProdutosController(setup.repository);
        }

        [Fact]
        public async Task PostProduto_Return_CreatedStatusCode()
        {
            // Arrange
            var novoProdutoDto = new ProdutoDTO
            {
                Nome = "Novo Produto",
                Descricao = "Descrição do novo produto",
                Preco = 99.99m,
                ImagemUrl = "imagem.jpg",
                CategoriaId = 2
            };

            // Act
            var data = await _controller.Post(novoProdutoDto);

            // Assert
            var createdResult = data.Result.Should().BeOfType<CreatedAtRouteResult>();
            createdResult.Subject.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task PostProduto_Return_BadRequest()
        {
            ProdutoDTO prod = null;

            var data = await _controller.Post(prod);

            var badRequestResult = data.Result.Should().BeOfType<BadRequestObjectResult>();
            badRequestResult.Subject.StatusCode.Should().Be(400);
        }
    }
}

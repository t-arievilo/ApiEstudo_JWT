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
    public class PutProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
    {
        private readonly ProdutosController _controller;
        public PutProdutoUnitTests(ProdutosUnitTestController setup)
        {
            _controller = new ProdutosController(setup.repository);
        }
        [Fact]
        public async Task PutProduto_Return_Ok()
        {
            // Arrange
            var prodId = 16;
            var produtoDto = new ProdutoDTO
            {
                ProdutoId = prodId,
                Nome = "Produto Atualizado",
                Descricao = "Descrição do produto atualizado",
                Preco = 89.99m,
                ImagemUrl = "imagem_atualizada.jpg",
                CategoriaId = 2
            };
            // Act
            var result = await _controller.Put(16, produtoDto) as ActionResult<ProdutoDTO>;
            // Assert
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public async Task PutProduto_Return_BadRequest()
        {
            var prodId = 1000;
            var produtoDto = new ProdutoDTO
            {
                ProdutoId = 13,
                Nome = "Produto Atualizado",
                Descricao = "Descrição do produto atualizado",
                Preco = 89.99m,
                ImagemUrl = "imagem_atualizada.jpg",
                CategoriaId = 2
            };

            var data = await _controller.Put(prodId, produtoDto);


            data.Result.Should().BeOfType<BadRequestObjectResult>()
                .Which.StatusCode.Should().Be(400);
        }
    }
    
}

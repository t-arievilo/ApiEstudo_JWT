using ApiEstudo.Models;

namespace ApiEstudo.DTOs.Mappings
{
    public static class ProdutoDTOUpdateResponseMappingExtensions
    {
        public static ProdutoDTOUpdateResponse? ToProdutoDTOUpdateResponse(this Produto produto)
        {
            if (produto is null)
                return null;

            return new ProdutoDTOUpdateResponse
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                ImagemUrl = produto.ImagemUrl,
                Estoque = produto.Estoque,
                DataCadastro = produto.DataCadastro,
                CategoriaId = produto.CategoriaId,
                Categoria = produto.Categoria
            };
        }

        public static Produto? ToProduto(this ProdutoDTOUpdateRequest produtoDto, Produto produtoExistente)
        {
            if (produtoDto is null)
                return null;

            // Atualiza apenas os campos que podem ser alterados pelo DTO
            produtoExistente.Estoque = produtoDto.Estoque;
            produtoExistente.DataCadastro = produtoDto.DataCadastro;

            return produtoExistente;
        }

        public static ProdutoDTOUpdateRequest? ToProdutoDTOUpdateRequest(this Produto produto)
        {
            if (produto is null)
                return null;

            return new ProdutoDTOUpdateRequest
            {
                Estoque = produto.Estoque,
                DataCadastro = produto.DataCadastro
            };
        }
    }
}

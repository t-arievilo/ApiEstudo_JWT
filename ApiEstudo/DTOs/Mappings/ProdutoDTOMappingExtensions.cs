using ApiEstudo.Models;

namespace ApiEstudo.DTOs.Mappings
{
    public static class ProdutoDTOMappingExtensions
    {
        public static ProdutoDTO? ToProdutoDTO(this Produto produto)
        {
            if (produto == null)
                return null;

            return new ProdutoDTO
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                ImagemUrl = produto.ImagemUrl,
                CategoriaId = produto.CategoriaId
            };
        }

        public static Produto? ToProduto(this ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
                return null;

            return new Produto
            {
                ProdutoId = produtoDTO.ProdutoId,
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                Preco = produtoDTO.Preco,
                ImagemUrl = produtoDTO.ImagemUrl,
                CategoriaId = produtoDTO.CategoriaId
            };
        }

        public static IEnumerable<ProdutoDTO> ToProdutoDTOList(this IEnumerable<Produto> produtos)
        {
            if (produtos == null || !produtos.Any())
                return new List<ProdutoDTO>();

            return produtos.Select(p => new ProdutoDTO
            {
                ProdutoId = p.ProdutoId,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                ImagemUrl = p.ImagemUrl,
                CategoriaId = p.CategoriaId
            }).ToList();
        }
    }
}

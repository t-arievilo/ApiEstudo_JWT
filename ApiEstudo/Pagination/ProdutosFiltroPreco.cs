namespace ApiEstudo.Pagination
{
    public class ProdutosFiltroPreco : QueryStringsParameters
    {
        public decimal? Preco { get; set; }
        public string? PrecoCriterio { get; set; }
    }
}

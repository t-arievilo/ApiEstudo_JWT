using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEstudo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " +
                   "Values('Coca-Cola', 'Refrigerante de cola', 5.50, 'cocacola.jpg', 50, now(), 1)");

            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " +
                   "Values('Lanche de atum', 'Lanche de atum com maionese', 8.50, 'atum.jpg', 50, now(), 2)");

            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " +
                   "Values('Pudim 100g', 'Pudim de leite condensado 100g', 6.75, 'pudim.jpg', 50, now(), 3)");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}

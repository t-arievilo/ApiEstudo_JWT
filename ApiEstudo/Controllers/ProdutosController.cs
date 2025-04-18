using ApiEstudo.DTOs;
using ApiEstudo.DTOs.Mappings;
using ApiEstudo.Models;
using ApiEstudo.Pagination;
using ApiEstudo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace ApiEstudo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public ProdutosController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    [Authorize(Policy = "UserOnly")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
    {
        try
        {
            var produtos = await _uof.ProdutoRepository.GetAllAsync();

            if (produtos is null || !produtos.Any())
                return NotFound("Nenhum produto encontrado...");

            var produtosDto = produtos.ToProdutoDTOList();

            return Ok(produtosDto);
        }
        catch (Exception )
        {
            return BadRequest();
        }
        
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get([FromQuery] ProdutosParameters produtosParameters)
    {
        var produtos = await _uof.ProdutoRepository.GetProdutosAsync(produtosParameters);

        return ObterProdutos(produtos);
    }

    [HttpGet("filter/preco/pagination")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutosFilterPreco([FromQuery] ProdutosFiltroPreco produtosFilterParameters)
    {
        var produtos = await _uof.ProdutoRepository.GetProdutosFiltroPrecoAsync(produtosFilterParameters);
        return ObterProdutos(produtos);
    }

    [HttpGet("produtos/{id}")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutosPorCategoria(int id)
    {
        var produtos = await _uof.ProdutoRepository.GetProdutosPorCategoriaAsync(id);

        if (produtos is null || !produtos.Any())
            return NotFound("Nenhum produto encontrado...");

        var produtosDto = produtos.ToProdutoDTOList();

        return Ok(produtosDto);
    }

    [HttpGet("{id:int}", Name = "ObterProduto")]
    public async Task<ActionResult<ProdutoDTO>> Get(int id)
    {
        if (id == null || id <= 0)
            return BadRequest("Dados inválidos");

        var produto = await _uof.ProdutoRepository.GetAsync(p => p.ProdutoId == id);
        if (produto is null)
            return NotFound("Produto não encontrado...");

        var produtoDto = produto.ToProdutoDTO();

        return Ok(produtoDto);
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoDTO>> Post(ProdutoDTO produtoDto)
    {
        if (produtoDto is null)
            return BadRequest("Dados inválidos");

        var produto = produtoDto.ToProduto();
        var produtoCriado = _uof.ProdutoRepository.Create(produto);
        await _uof.CommitAsync();

        var novoProdutoDto = produtoCriado.ToProdutoDTO();

        return new CreatedAtRouteResult("ObterProduto", new { id = novoProdutoDto.ProdutoId }, novoProdutoDto);
    }

    [HttpPatch("{id}/UpdatePartial")]
    public async Task<ActionResult<ProdutoDTOUpdateResponse>> Patch(int id,
        JsonPatchDocument<ProdutoDTOUpdateRequest> patchProdutoDto)
    {
        // Valida input 
        if (patchProdutoDto == null || id <= 0)
            return BadRequest();

        // Obtém o produto pelo Id
        var produto = await _uof.ProdutoRepository.GetAsync(c => c.ProdutoId == id);

        // Se não encontrou retorna
        if (produto == null)
            return NotFound();

        // Mapeia produto para ProdutoDTOUpdateRequest manualmente
        var produtoUpdateRequest = produto.ToProdutoDTOUpdateRequest();

        // Aplica as alterações definidas no documento JSON Patch ao objeto ProdutoDTOUpdateRequest
        patchProdutoDto.ApplyTo(produtoUpdateRequest, ModelState);

        if (!ModelState.IsValid || !TryValidateModel(produtoUpdateRequest))
            return BadRequest(ModelState);

        // Mapeia as alterações de volta para a entidade Produto manualmente
        produtoUpdateRequest.ToProduto(produto);

        // Atualiza a entidade no repositório
        _uof.ProdutoRepository.Update(produto);
        // Salva as alterações no banco de dados
        await _uof.CommitAsync();

        // Retorna ProdutoDTOUpdateResponse mapeado manualmente
        return Ok(produto.ToProdutoDTOUpdateResponse());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProdutoDTO>> Put(int id, ProdutoDTO produtoDto)
    {
        if (id != produtoDto.ProdutoId)
            return BadRequest("Dados inválidos");

        var produto = produtoDto.ToProduto();
        var produtoAtualizado = _uof.ProdutoRepository.Update(produto);
        await _uof.CommitAsync();

        var produtoAtualizadoDto = produtoAtualizado.ToProdutoDTO();

        return Ok(produtoAtualizadoDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProdutoDTO>> Delete(int id)
    {
        var produto = await _uof.ProdutoRepository.GetAsync(p => p.ProdutoId == id);

        if (produto is null)
            return NotFound("Produto não encontrado...");

        var produtoExcluido = _uof.ProdutoRepository.Delete(produto);
        await _uof.CommitAsync();

        var produtoExcluidoDto = produtoExcluido.ToProdutoDTO();

        return Ok(produtoExcluidoDto);
    }




    private ActionResult<IEnumerable<ProdutoDTO>> ObterProdutos(IPagedList<Produto> produtos)
    {
        var metadata = new
        {
            produtos.Count,
            produtos.PageSize,
            produtos.PageCount,
            produtos.HasNextPage,
            produtos.HasPreviousPage,
            produtos.TotalItemCount
        };

        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

        var produtosDto = produtos.ToProdutoDTOList();
        return Ok(produtosDto);
    }
}
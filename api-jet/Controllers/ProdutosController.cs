using api.Data;
using api.Extensions;
using api.Models;
using api.Services;
using api.ViewModels.Result;
using api.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using Microsoft.AspNetCore.Authorization;
using api.ViewModels;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace api.Controllers
{

    [ApiController]
    public class ProdutosController : ControllerBase
    {

        [Authorize]
        [HttpGet("v1/produtos")]
        public async Task<IActionResult> GetProdutosAsync(
        [FromServices] DataBaseContext context)
        {
            try
            {

                //Monta array de dados
                var rows = await context.
                    Produtos
                    .AsNoTracking()
                    .Select(x => new
                    {
                        x.codigo,
                        x.nome,
                        x.imagem,
                        x.descricao,
                        x.estoque,
                        x.status,
                        x.preco,
                        x.preco_promocao
                    })
                    .ToListAsync();

                //Retorna dados
                return Ok(new ResultViewModel<dynamic>("Registro inserido com sucesso!", true, rows, new List<string>()));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<dynamic>>("Falha ao carregar os registros!", false, new List<dynamic>(), new List<string>() { "05X01 - Falha interna no servidor" }));
            }
        }

        [Authorize]
        [HttpGet("v1/produtos/card")]
        public async Task<IActionResult> GetProdutosCardAsync(
        [FromServices] DataBaseContext context)
        {
            try
            {

                //Monta array de dados
                var rows = await context.
                    Produtos
                    .AsNoTracking()
                    .Select(x => new
                    {
                        x.codigo,
                        x.nome,
                        x.imagem,
                        x.descricao,
                        x.estoque,
                        x.status,
                        x.preco,
                        x.preco_promocao
                    })
                    .Where(x => x.status != false)
                    .ToListAsync();

                //Retorna dados
                return Ok(new ResultViewModel<dynamic>("Registro inserido com sucesso!", true, rows, new List<string>()));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<dynamic>>("Falha ao carregar os registros!", false, new List<dynamic>(), new List<string>() { "05X01 - Falha interna no servidor" }));
            }
        }


        [Authorize]
        [HttpGet("v1/produtos/{codigo}")]
        public async Task<IActionResult> GetProdutosByIdAsync(
        [FromRoute] int codigo,
        [FromServices] DataBaseContext context)
        {
            try
            {
                //Monta Arrya de dados
                var data = await context
                    .Produtos
                    .AsNoTracking()
                    .Select(x => new
                    {
                        x.codigo,
                        x.nome,
                        x.imagem,
                        x.descricao,
                        x.estoque,
                        x.status,
                        x.preco,
                        x.preco_promocao
                    })
                    .Where(x => x.codigo == codigo)
                    .ToListAsync();


                //Retorna dados
                return Ok(new ResultViewModel<dynamic>("Registros carregados com sucesso!", true, data, new List<string>()));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<ProdutosModel>>("Falha ao carregar os registros!", false, new List<ProdutosModel>(), new List<string>() { "05X02 - Falha interna no servidor" }));
            }
        }

        [Authorize]
        [HttpPost("v1/produtos")]
        public async Task<IActionResult> PostProdutosAsync(
           [FromBody] ProdutosModel model,
           [FromServices] DataBaseContext context)
        {

            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<ProdutosModel>(ModelState.GetErrors()));

            try
            {
                //Seta Dados
                var row = new ProdutosModel
                {
                    nome = model.nome,
                    imagem = model.imagem,
                    descricao = model.descricao,
                    estoque = model.estoque,
                    status = model.status,
                    preco = model.preco,
                    preco_promocao = model.preco_promocao
                };

                await context.Produtos.AddAsync(row);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<ProdutosModel>("Registro inserido com sucesso!", true, row, new List<string>()));

            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<dynamic>>("Falha ao carregar os registros!", false, new List<dynamic>(), new List<string>() { "05X01 - Falha interna no servidor" }));
            }
        }

        [Authorize]
        [HttpPut("v1/produtos/{codigo}")]
        public async Task<IActionResult> PutProdutosAsync(
        [FromRoute] int codigo,
        [FromBody] ProdutosModel model,
        [FromServices] DataBaseContext context)
        {

            try
            {

                var produtos = await context
                    .Produtos
                    .FirstOrDefaultAsync(x => x.codigo == codigo);

                if (produtos == null)
                    return NotFound(new ResultViewModel<ProdutosModel>("Não foi possivel encontrar o registro!", false, new ProdutosModel(), new List<string>() { "05X03 - Registro não encontrado." }));


                if (model.imagem == "")
                {
                    produtos.nome = model.nome;
                    produtos.descricao = model.descricao;
                    produtos.estoque = model.estoque;
                    produtos.status = model.status;
                    produtos.preco = model.preco;
                    produtos.preco_promocao = model.preco_promocao;

                } else {

                    produtos.nome = model.nome;
                    produtos.descricao = model.descricao;
                    produtos.estoque = model.estoque;
                    produtos.status = model.status;
                    produtos.preco = model.preco;
                    produtos.imagem = model.imagem;
                    produtos.preco_promocao = model.preco_promocao;

                }

                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<ProdutosModel>("Registro alterado com sucesso!", true, produtos, new List<string>()));
            }
            catch (DbUpdateException error)
            {
                return StatusCode(500, new ResultViewModel<ProdutosModel>("Não foi possível alterar o registro!", false, new ProdutosModel(), new List<string>() { "05X03 - Não foi possível alterar o registro" }));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<ProdutosModel>("Falha ao carregar os registros!", false, new ProdutosModel(), new List<string> { "05X04 - Falha interna no servidor" }));
            }
        }

        [Authorize]
        [HttpDelete("v1/produtos/{codigo}")]
        public async Task<IActionResult> DeleteProdutosAsync(
        [FromRoute] int codigo,
        [FromServices] DataBaseContext context)
        {

            try
            {
                var row = await context
                   .Produtos
                   .FirstOrDefaultAsync(x => x.codigo == codigo);

                if (row == null)
                    return NotFound(new ResultViewModel<dynamic>("Não foi possivel encontrar o registro!", false, new {row}, new List<string>() { "05X03 - Registro não encontrado." }));

                context.Produtos.Remove(row);
                await context.SaveChangesAsync();


                return Ok(new ResultViewModel<ProdutosModel>("Registro excluído com sucesso!", true, new ProdutosModel(), new List<string>()));
            }
            catch (DbUpdateException error)
            {
                return StatusCode(500, new ResultViewModel<ProdutosModel>("Não foi possível excluir o registro!", false, new ProdutosModel(), new List<string>() { "05X03 - Não foi possível excluir o registro." }));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<ProdutosModel>("Falha ao carregar os registros!", false, new ProdutosModel(), new List<string> { "05X05 - Falha interna no servidor" }));
            }
        }


    }
}


using Microsoft.AspNetCore.Mvc;
using Precificador.Application.Services;
using Precificador.Application.Model;

namespace Precificador.WebApi.Controllers
{
    /// <summary>
    /// Construtor do Controller Colecao.
    /// </summary>
    /// <param name="service">Serviço de aplicação para coleções.</param>
    /// <param name="logger">Logger para rastreamento de erros.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class ColecaoController(IColecaoService service, ILogger<ColecaoController> logger) : ControllerBase
    {
        private readonly IColecaoService _service = service;
        private readonly ILogger<ColecaoController> _logger = logger;

        /// <summary>
        /// Retorna a lista de todas as coleções.
        /// </summary>
        /// <returns>Lista de Coleções.</returns>
        /// <response code="200">Retorna a lista de coleções.</response>
        /// <response code="204">Não encontrou resultados.</response>
        /// <response code="400">Erro ao buscar coleções.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();

                if (result == null || !result.Any())
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar coleções.");
                return BadRequest("Erro ao listar coleções.");
            }
        }

        /// <summary>
        /// Retorna os dados de uma coleção específica.
        /// </summary>
        /// <param name="id">Identificador único da coleção.</param>
        /// <returns>Dados da coleção.</returns>
        /// <response code="200">Coleção</response>
        /// <response code="204">Coleção não encontrada.</response>
        /// <response code="400">Erro ao buscar coleção.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                if (result == null)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar coleção.");
                return BadRequest("Erro ao consultar coleção.");
            }
        }

        /// <summary>
        /// Retorna lista de coleções que tenham as palavras especificadas no nome
        /// </summary>
        /// <param name="nome">Identificador único da coleção.</param>
        /// <returns>Lista de Coleções.</returns>
        /// <response code="200">Coleção</response>
        /// <response code="204">Coleção não encontrada.</response>
        /// <response code="400">Erro ao buscar coleção.</response>
        [HttpGet("GetByName/{nome}")]
        public async Task<IActionResult> GetAllByName(string nome)
        {
            try
            {
                var result = await _service.GetAllByNameAsync(nome);

                if (result == null || !result.Any())
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar coleção.");
                return BadRequest("Erro ao consultar coleção.");
            }
        }

        /// <summary>
        /// Cadastra nova coleção.
        /// </summary>
        /// <param name="value">Dados da Coleção a ser cadastrada.</param>
        /// <returns>Sucesso no Cadastro</returns>
        /// <response code="200">Coleção cadastrada com sucesso.</response>
        /// <response code="400">Erro ao cadastrar Coleção.</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Colecao value)
        {
            try
            {
                return Ok(await _service.AddAsync(value));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar coleção.");
                return BadRequest("Erro ao cadastrar coleção.");
            }
        }

        /// <summary>
        /// Atualiza os dados de uma Coleção existente.
        /// </summary>
        /// <param name="value">Novos dados da Coleção.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="200">Coleção atualizada com sucesso.</response>
        /// <response code="204">Coleção não encontrada.</response>
        /// <response code="400">Erro ao atualizar Coleção.</response>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Colecao value)
        {
            try
            {
                var result = await _service.UpdateAsync(value);

                if (!result)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar coleção.");
                return BadRequest("Erro ao atualizar coleção.");
            }
        }

        /// <summary>
        /// Remove uma Coleção existente.
        /// </summary>
        /// <param name="id">Identificador da Coleção a ser removida.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="200">Coleção removida com sucesso.</response>
        /// <response code="204">Coleção não encontrada.</response>
        /// <response code="400">Erro ao remover Coleção.</response>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);

                if (!result)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover Coleção.");
                return BadRequest("Erro ao remover Coleção.");
            }
        }
    }
}
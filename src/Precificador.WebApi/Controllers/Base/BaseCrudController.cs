using Microsoft.AspNetCore.Mvc;

using Precificador.Application.Services.Base;

namespace Precificador.WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseCrudController<TModel, TService>(TService service, ILogger logger) : ControllerBase where TService : ICrudService<TModel>
    {
        protected TService _service = service;
        protected ILogger _logger = logger;

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();

                if (result == null || !((IEnumerable<TModel>)result).Any())
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar registros.");
                return BadRequest("Erro ao listar registros.");
            }
        }

        [HttpGet("ById")]
        public virtual async Task<IActionResult> GetById([FromBody] Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar registro.");
                return BadRequest("Erro ao consultar registro.");
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TModel value)
        {
            try
            {
                var result = await _service.AddAsync(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar registro.");
                return BadRequest("Erro ao cadastrar registro.");
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TModel value)
        {
            try
            {
                var result = await _service.UpdateAsync(value);

                if (!(bool)result)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar registro.");
                return BadRequest("Erro ao atualizar registro.");
            }
        }

        [HttpGet("ByFilter")]
        public virtual async Task<IActionResult> GetByFilterAsync([FromBody] string nome)
        {
            try
            {
                var result = await _service.GetByFilterAsync(nome);

                if (result == null || !((IEnumerable<TModel>)result).Any())
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar registros.");
                return BadRequest("Erro ao consultar registros.");
            }
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete([FromBody] Guid id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);

                if (!(bool)result)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover registro.");
                return BadRequest("Erro ao remover registro.");
            }
        }
    }
}
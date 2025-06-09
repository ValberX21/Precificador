using Microsoft.AspNetCore.Mvc;

using Precificador.Application.Services.Base;

namespace Precificador.WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseModelController<TModel, TService>(TService service, ILogger logger) : BaseController<TModel, TService>(service, logger) where TService : IBaseModelService<TModel>
    {
        [HttpGet("by-name")]
        public virtual async Task<IActionResult> GetAllByName([FromBody] string nome)
        {
            try
            {
                var result = await _service.GetAllByNameAsync(nome);

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
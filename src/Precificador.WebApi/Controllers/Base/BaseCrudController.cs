﻿using Microsoft.AspNetCore.Mvc;
using Precificador.Application.Model.Base;
using Precificador.Application.Services.Base;
using Precificador.Domain.Entities.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository.Base;
using System.Text.Json;

namespace Precificador.WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseCrudController<TModel, TEntity, TFilter, TService, TRepository>(TService service, ILogger logger) : ControllerBase where TModel : ModelBase where TEntity : CrudBase where TFilter : IFilter where TService : ICrudService<TModel, TEntity, TFilter, TRepository> where TRepository : ICrudRepository<TEntity, TFilter>
    {
        protected TService _service = service;
        protected ILogger _logger = logger;

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();

                return result == null || !((IEnumerable<TModel>)result).Any() ? NoContent() : Ok(result);
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

                return result == null ? NoContent() : Ok(result);
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

                return !(bool)result ? NoContent() : Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar registro.");
                return BadRequest("Erro ao atualizar registro.");
            }
        }

        [HttpGet("ByFilter")]
        public virtual async Task<IActionResult> GetByFilterAsync([FromBody] string param)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    return BadRequest("Filter parameter cannot be null or empty.");
                }

                var filter = JsonSerializer.Deserialize<TFilter>(param);

                if (filter == null)
                {
                    return BadRequest("Failed to deserialize filter parameter.");
                }

                var result = await _service.GetByFilterAsync(filter);

                return result == null || !((IEnumerable<TModel>)result).Any() ? NoContent() : Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar registros.");
                return BadRequest("Erro ao listar registros.");
            }
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete([FromBody] Guid id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);

                return !(bool)result ? NoContent() : Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover registro.");
                return BadRequest("Erro ao remover registro.");
            }
        }
    }
}
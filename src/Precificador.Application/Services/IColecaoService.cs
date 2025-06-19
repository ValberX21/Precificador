﻿using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public interface IColecaoService : ICrudService<Model.Colecao, Domain.Entities.Colecao, ColecaoFilter, IColecaoRepository>
    {
    }
}
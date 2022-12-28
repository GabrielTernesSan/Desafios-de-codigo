﻿using Domain.Queries.Responses;

namespace Domain.Queries
{
    public interface IVingadoresQuery
    {
        Task<IEnumerable<ObterVingadoresResponse>> ObterVingadores();
    }
}

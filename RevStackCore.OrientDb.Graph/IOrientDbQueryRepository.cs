﻿using System.Linq;
using System.Threading.Tasks;

namespace RevStackCore.OrientDb.Graph
{
    public interface IOrientDbQueryRepository
    {
        IQueryable<TModel> Find<TModel>(string query);
        Task<IQueryable<TModel>> FindAsync<TModel>(string query);
    }
}

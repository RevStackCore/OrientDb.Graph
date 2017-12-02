using RevStackCore.Pattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace RevStackCore.OrientDb.Graph
{
    public class OrientDbQueryService : IOrientDbQueryService
    {
        private readonly IOrientDbQueryRepository _repository;

        public OrientDbQueryService(IOrientDbQueryRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<TModel> Find<TModel>(string query)
        {
            return _repository.Find<TModel>(query);
        }

        public Task<IQueryable<TModel>> FindAsync<TModel>(string query)
        {
            return Task.FromResult(Find<TModel>(query));
        }
    }
}

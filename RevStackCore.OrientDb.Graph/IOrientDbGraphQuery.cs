using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RevStackCore.OrientDb.Graph
{
    public interface IOrientDbGraphQuery<TEntity, TKey>
    {
        IQueryable<TEntity> Find(string query);
    }
}

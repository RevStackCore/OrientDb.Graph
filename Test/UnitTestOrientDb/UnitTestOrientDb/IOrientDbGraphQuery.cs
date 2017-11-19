using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestOrientDb
{
    public interface IOrientDbGraphQuery<TEntity, TKey>
    {
        IQueryable<TEntity> Find(string query);
    }
}

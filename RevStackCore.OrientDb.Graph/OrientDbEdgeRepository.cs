﻿using System.Reflection;
using RevStackCore.Pattern;


namespace RevStackCore.OrientDb.Graph
{
    public class OrientDbEdgeRepository<TEntity, TKey> : OrientDbRepository<TEntity, TKey>, IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly OrientDbContext _context;

        public OrientDbEdgeRepository(OrientDbContext context)
            : base(context)
        {
            _context = context;
        }

        public new TEntity Add(TEntity entity)
        {
            var type = entity.GetType();
            var name = type.Name;

            if (type.GetProperty("In") == null)
            {
                throw new System.Exception("'In' property of type OrientDbEntity is required");
            }

            if (type.GetProperty("Out") == null)
            {
                throw new System.Exception("'Out' property of type OrientDbEntity is required");
            }

            var In = type.GetProperty("In").GetValue(entity);
            var Out = type.GetProperty("Out").GetValue(entity);
            var inRid = In.GetType().GetProperty("_rid").GetValue(In);
            var outRid = Out.GetType().GetProperty("_rid").GetValue(Out);

            var typeName = Utils.OrientDbUtils.GetEntityIdType(entity);
            entity = Utils.OrientDbUtils.SetEntityIdProperty(entity);

            _context.Database.Execute("CREATE CLASS " + name + " EXTENDS E");

            //https://github.com/orientechnologies/orientdb/issues/5688
            //FIX: alter database custom standardElementConstraints=false
            _context.Database.Execute("CREATE PROPERTY " + name + ".id " + typeName);
            _context.Database.Execute("CREATE INDEX " + name + ".id UNIQUE");
            var q = "CREATE EDGE " + name + " FROM " + inRid + " to " + outRid + " SET id = '" + entity.Id + "'";
            _context.Database.Execute(q);
            //var edge = base.GetById(entity.Id);
            return base.Update(entity);
        }

        public new TEntity Update(TEntity entity)
        {
            var type = entity.GetType();
            var name = entity.GetType().Name;

            if (type.GetProperty("In") == null)
            {
                throw new System.Exception("'To' property of type OrientDbEntity is required");
            }

            if (type.GetProperty("Out") == null)
            {
                throw new System.Exception("'From' property of type OrientDbEntity is required");
            }

            var In = type.GetProperty("In").GetValue(entity);
            var Out = type.GetProperty("Out").GetValue(entity);
            var inRid = In.GetType().GetProperty("_rid").GetValue(In);
            var outRid = Out.GetType().GetProperty("_rid").GetValue(Out);

            var q = "UPDATE EDGE " + name + " SET in = " + inRid + ", out = " + outRid + " WHERE id ='" + entity.Id + "'";
            _context.Database.Execute(q);

            return base.Update(entity);
        }

        public new void Delete(TEntity entity)
        {
            var name = entity.GetType().Name;
            _context.Database.Execute("DELETE EDGE " + name + " where id = '" + entity.Id.ToString() + "'");
        }
    }
}

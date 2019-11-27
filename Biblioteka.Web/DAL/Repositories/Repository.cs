using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka.Web.DAL.Repositories
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        protected LibContext _context;
        protected DbSet<Entity> dbSet;

        public Repository(LibContext context)
        {
            _context = context;
            dbSet = _context.Set<Entity>();
        }

        public virtual IQueryable<Entity> Get() => dbSet;

        public virtual IList<Entity> Get(Func<Entity, bool> where) => Get().Where(where).ToList();

        public virtual Entity Get(int id) => dbSet.Find(id);

        public virtual void Insert(Entity entity) => dbSet.Add(entity);

        public virtual void Update(Entity entity, int id)
        {
            Entity old = Get(id);
            if (old != null) _context.Entry(old).CurrentValues.SetValues(entity);
        }

        public void Delete(Entity entity) => dbSet.Remove(entity);

        public void Delete(int id)
        {
            Entity entity = Get(id);
            if (entity != null) Delete(entity);
        }
    }
}

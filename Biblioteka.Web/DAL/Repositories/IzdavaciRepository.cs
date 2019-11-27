using Biblioteka.Web.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka.Web.DAL.Repositories
{
    public class IzdavaciRepository : IRepository<Izdavac>
    {
        private readonly LibContext context;

        public IzdavaciRepository(LibContext context)
        {
            this.context = context;
        }

        public void Delete(Izdavac entity)
        {
            context.Izdavaci.Remove(entity);
        }

        public void Delete(int id)
        {
            Izdavac entity = Get(id);
            if (entity != null) Delete(entity);
        }

        public IQueryable<Izdavac> Get()
        {
            return context.Izdavaci;
        }

        public IList<Izdavac> Get(Func<Izdavac, bool> where) 
        {
            return Get().Where(where).ToList();
        }

        public Izdavac Get(int id)
        {
            return Get().FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Izdavac entity)
        {
            context.Izdavaci.Add(entity);
        }

        public void Update(Izdavac entity, int id)
        {
            Izdavac old = Get(id);
            if (old != null) context.Entry(old).CurrentValues.SetValues(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

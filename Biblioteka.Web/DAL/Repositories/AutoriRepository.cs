using Biblioteka.Web.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka.Web.DAL.Repositories
{
    public class AutoriRepository : IRepository<Autor>
    {
        private readonly LibContext context;

        public AutoriRepository(LibContext context)
        {
            this.context = context;
        }

        public void Delete(Autor entity)
        {
            context.Autori.Remove(entity);
        }

        public void Delete(int id)
        {
            Autor entity = Get(id);
            if (entity != null) Delete(entity);
        }

        public IQueryable<Autor> Get()
        {
            return context.Autori.Include(x => x.Knjige).ThenInclude(x => x.Knjiga);
        }

        public IList<Autor> Get(Func<Autor, bool> where) 
        {
            return Get().Where(where).ToList();
        }

        public Autor Get(int id)
        {
            return Get().FirstOrDefault(x => x.aId == id);
        }

        public void Insert(Autor entity)
        {
            context.Autori.Add(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Autor entity, int id)
        {
            Autor old = Get(id);
            if (old != null) context.Entry(old).CurrentValues.SetValues(entity);
        }


    }
}

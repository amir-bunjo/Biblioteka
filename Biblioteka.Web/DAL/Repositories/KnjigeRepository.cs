using Biblioteka.Web.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka.Web.DAL.Repositories
{
    public class KnjigeRepository : IRepository<Knjiga>
    {
        private readonly LibContext context;

        public KnjigeRepository(LibContext context)
        {
            this.context = context;
        }

        public void Delete(Knjiga entity)
        {
            context.Knjige.Remove(entity);
        }

        public void Delete(int id)
        {
            Knjiga entity = Get(id);
            if (entity != null) Delete(entity);
        }

        public IQueryable<Knjiga> Get()
        {
            return context.Knjige.Include(x => x.Izdavac).Include(x => x.Autori).ThenInclude(x => x.Autor);
        }

        public IList<Knjiga> Get(Func<Knjiga, bool> where) 
        {
            return Get().Where(where).ToList();
        }

        public Knjiga Get(int id)
        {
            return Get().FirstOrDefault(x => x.kId == id);
        }

        public void Insert(Knjiga entity)
        {
            context.Knjige.Add(entity);
        }

        public void Update(Knjiga entity, int id)
        {
            Knjiga old = Get(id);
            if (old != null) context.Entry(old).CurrentValues.SetValues(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}

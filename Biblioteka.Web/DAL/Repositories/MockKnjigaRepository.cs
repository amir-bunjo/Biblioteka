using Biblioteka.Web.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka.Web.DAL.Repositories
{
    public class MockKnjigaRepository : IKnjigaRepository
    {










        /*
        private IQueryable<Knjiga> dbSet;
        
        public  IQueryable<Knjiga> Get()
        {
            return dbSet.Include(x => x.Izdavac).Include(x => x.Autori).ThenInclude(x => x.Autor);
        }

        public  IList<Knjiga> Get(Func<Knjiga, bool> where)
        {
            IList<Knjiga> lista;
            IQueryable<Knjiga> dbQuery = Get();
            lista = dbQuery.Where(where).ToList();
            return lista;
        }

        public  Knjiga Get(int id)
        {

            //IQueryable<Knjiga> dbQuery = Get();
            //Knjiga knjiga = dbQuery.FirstOrDefault(x => x.Id == id);
            return Get().FirstOrDefault(x => x.kId == id);
        }

        public  void Update(Knjiga knjiga, int id)
        {
            Knjiga staraKnjiga = Get(id);
            if (staraKnjiga != null)
            {
                _context.Entry(staraKnjiga).CurrentValues.SetValues(knjiga);
                staraKnjiga.Izdavac = knjiga.Izdavac;
            }
        }*/
        public Knjiga Delete(Knjiga knjiga)
        {
            throw new NotImplementedException();
        }

        public Knjiga Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Knjiga> Get()
        {
            throw new NotImplementedException();
        }

        public Knjiga Get(int id)
        {
            throw new NotImplementedException();
        }

        public Knjiga Insert(Knjiga knjiga)
        {
            throw new NotImplementedException();
        }

        public Knjiga Update(Knjiga knjiga, int id)
        {
            throw new NotImplementedException();
        }
    }
}


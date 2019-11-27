using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka.Web.DAL.Entities;

namespace Biblioteka.Web.DAL.Repositories
{
    public class SqlKnjigaRepository : IKnjigaRepository
    {
        private readonly LibContext _context;
        public SqlKnjigaRepository(LibContext context)
        {
            this._context = context;
        }

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
            return _context.Knjige;
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

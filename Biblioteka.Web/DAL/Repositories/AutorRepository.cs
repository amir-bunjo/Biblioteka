using Biblioteka.Web.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka.Web.DAL.Repositories
{
    public class AutorRepository : Repository<Autor>
    {
        public AutorRepository(LibContext context) : base(context) { }

        public override IQueryable<Autor> Get() => dbSet.Include(x => x.Knjige).ThenInclude(x => x.Knjiga);

        public override IList<Autor> Get(Func<Autor, bool> where) => Get().Where(where).ToList();

        public override Autor Get(int id) => Get().FirstOrDefault(x => x.aId == id);
    }
}

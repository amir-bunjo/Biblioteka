using Biblioteka.Web.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka.Web.DAL.Repositories
{
    public class IzdavacRepository : Repository<Izdavac>
    {
        public IzdavacRepository(LibContext context) : base(context) { }

        public override IQueryable<Izdavac> Get() => dbSet.Include(x => x.Knjige); //mozda dodat.ThenInclude(x => x.A).ThenInclude(x => x.Author);

        public override IList<Izdavac> Get(Func<Izdavac, bool> where) => Get().Where(where).ToList();

        public override Izdavac Get(int id) => Get().FirstOrDefault(x => x.Id == id);
    }
}

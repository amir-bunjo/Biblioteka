using Biblioteka.Web.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka.Web.DAL.Repositories
{
    public class KnjigaRepository : Repository<Knjiga>
    {
        public KnjigaRepository(LibContext context) : base(context) {
            
        }


        public override IQueryable<Knjiga> Get()
        {
            return dbSet.Include(x => x.Izdavac).Include(x => x.Autori).ThenInclude(x => x.Autor);
        }

        public override IList<Knjiga> Get(Func<Knjiga, bool> where)
        {
            IList<Knjiga> lista;
            IQueryable<Knjiga> dbQuery = Get();
            lista = dbQuery.Where(where).ToList();
            return lista;
        }

        public override Knjiga Get(int id)
        {

            //IQueryable<Knjiga> dbQuery = Get();
            //Knjiga knjiga = dbQuery.FirstOrDefault(x => x.Id == id);
            return Get().FirstOrDefault(x => x.kId == id);
        }

        public override void Update(Knjiga knjiga, int id)
        {
            Knjiga staraKnjiga = Get(id);
            if (staraKnjiga != null)
            {
                _context.Entry(staraKnjiga).CurrentValues.SetValues(knjiga);
                staraKnjiga.Izdavac = knjiga.Izdavac;
            }
        }
    }
}

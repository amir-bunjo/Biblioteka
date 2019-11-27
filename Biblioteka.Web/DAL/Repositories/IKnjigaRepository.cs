using Biblioteka.Web.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteka.Web.DAL.Repositories
{
    public interface IKnjigaRepository
    {
        IQueryable<Knjiga> Get();
     //   IList<Entity> Get(Func<Entity, bool> where);
        Knjiga Get(int id);

        Knjiga Insert(Knjiga knjiga);
        Knjiga Update(Knjiga knjiga, int id);
        Knjiga Delete(Knjiga knjiga);
        Knjiga Delete(int id);
    }
}

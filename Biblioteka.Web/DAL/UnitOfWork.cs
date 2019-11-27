using Biblioteka.Web.DAL.Entities;
using Biblioteka.Web.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.Web.DAL
{
    public class UnitOfWork : IDisposable
    {
        string connString = @"User Id=test;Password=test;Data Source=
            (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.131.64)(PORT = 1521))
            (CONNECT_DATA =
                (SERVER = DEDICATED)
                (SERVICE_NAME = IBNTS.bstelecom.ba)
             )
              );";
        private readonly LibContext _context;
        private IRepository<Autor> _autori;
        private IRepository<Knjiga> _knjige;
        private IRepository<Izdavac> _izdavaci;
        private IRepository<AutorKnjiga> _autorknjiga;


        public UnitOfWork(LibContext context ) => _context = context ;

        public LibContext Context => _context;

        public IRepository<Autor> Autori => _autori ?? (_autori = new AutorRepository(_context));
        public IRepository<Knjiga> Knjige => _knjige ?? (_knjige = new KnjigaRepository(_context));
        public IRepository<Izdavac> Izdavaci => _izdavaci ?? (_izdavaci = new IzdavacRepository(_context));
        public IRepository<AutorKnjiga> AutorKnjiga => _autorknjiga ?? (_autorknjiga = new Repository<AutorKnjiga>(_context));

        public int Save() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}

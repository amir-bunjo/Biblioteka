using Biblioteka.DAL.Entities;
using Biblioteka.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly LibContext _context;
        private IRepository<Autor> _autori;
        private IRepository<Knjiga> _knjige;
        private IRepository<Izdavac> _izdavaci;
        private IRepository<AutorKnjiga> _autorknjiga;


        public UnitOfWork(LibContext context = null) => _context = context ?? (context = new LibContext());

        public LibContext Context => _context;

        public IRepository<Autor> Autori => _autori ?? (_autori = new AutorRepository(_context));
        public IRepository<Knjiga> Knjige => _knjige ?? (_knjige = new KnjigaRepository(_context));
        public IRepository<Izdavac> Izdavaci => _izdavaci ?? (_izdavaci = new IzdavacRepository(_context));
        public IRepository<AutorKnjiga> AutorKnjiga => _autorknjiga ?? (_autorknjiga = new Repository<AutorKnjiga>(_context));

        public int Save() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}

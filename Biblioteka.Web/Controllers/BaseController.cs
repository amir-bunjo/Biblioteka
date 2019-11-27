using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.Web.DAL.Entities;
using Biblioteka.Web.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IRepository<Knjiga> Knjige;
        protected readonly IRepository<Autor> Autori;
        protected readonly IRepository<Izdavac> Izdavaci;

        public BaseController(IRepository<Knjiga> repository, IRepository<Autor> repositoryA, IRepository<Izdavac> repositoryI)
        {
            Knjige = Knjige ?? repository;
            Autori = Autori ?? repositoryA;
            Izdavaci = Izdavaci ?? repositoryI;
        }
    }
}
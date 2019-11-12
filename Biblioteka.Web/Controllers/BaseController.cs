using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Web.Controllers
{
    public class BaseController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        public UnitOfWork Unit => _unit ?? new UnitOfWork();


    }
}
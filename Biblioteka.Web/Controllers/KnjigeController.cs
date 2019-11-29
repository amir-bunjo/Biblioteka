using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.Web.DAL;
using Biblioteka.Web.DAL.Entities;
using Biblioteka.Web.DAL.Repositories;
using Biblioteka.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteka.Web.Controllers
{
    [Authorize(Roles = "Administrator,UserTest")]
    public class KnjigeController : BaseController
    {
 

        public KnjigeController(IRepository<Knjiga> repository, IRepository<Autor> repositoryA, IRepository<Izdavac> repositoryI)
                                        : base(repository, repositoryA, repositoryI) { }

        public IActionResult Index()
        {
            List<Knjiga> knjige = Knjige.Get().ToList();

            return View(knjige);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            Knjige.Delete(id);
            Knjige.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Knjiga knjiga = Knjige.Get(id);
            return View(knjiga);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            Knjiga knjiga = Knjige.Get(id);

            return View(knjiga);
        }


        public IActionResult Create()
        {
            List<Izdavac> izdavaci = Izdavaci.Get().ToList();
            List<Autor> autori = Autori.Get().ToList();

            KnjigaModel model = new KnjigaModel()
            {
                listaSvihIzdavaca = izdavaci.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Ime
                }),
                listaSvihAutora = autori.Select(x => new SelectListItem()
                {
                    Value = x.aId.ToString(),
                    Text = x.Ime
                })
            };

            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Update(Knjiga knjiga)
        {
            if (knjiga.kId > 0)
            {
                Knjige.Update(knjiga, knjiga.kId);
            }
            else
            {
                Knjige.Insert(knjiga);
            }
            Knjige.Save();
            return RedirectToAction("Index");
        }

        public IActionResult SaveNew(KnjigaModel knjigaModel)
        {
           
            Knjiga knjiga = new Knjiga()
            {
                kId = knjigaModel.kId,
                Naslov = knjigaModel.Naslov ,
                Cijena = knjigaModel.Cijena,
                Izdavac = Izdavaci.Get(knjigaModel.Izdavac) 
            };
            Knjige.Insert(knjiga);
            Knjige.Save();
            /* implement later(add authbooksrepo :Irepos<authbooks>).. and add here 
            foreach(int autorId in knjigaModel.Autori)
            {
                Unit.AutorKnjiga.Insert(new AutorKnjiga()
                {
                    Autor = Unit.Autori.Get(autorId),
                    Knjiga = knjiga
                });
            }
            Knjige.Save();*/
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.Web.DAL.Entities;
using Biblioteka.Web.DAL.Repositories;
using Biblioteka.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteka.Web.Controllers
{
    public class AutoriController : BaseController
    {
        public AutoriController(IRepository<Knjiga> repository, IRepository<Autor> repositoryA, IRepository<Izdavac> repositoryI)
                                        : base(repository, repositoryA, repositoryI) { }


        public IActionResult Index()
        {
            List<Autor> autori = Autori.Get().ToList();
            return View(autori);
        }

        public IActionResult Delete(int id)
        {
            Autori.Delete(id);
       
            Autori.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Autor autor = Autori.Get(id);
            return View(autor);
        }

        public IActionResult Edit(int id)
        {
            //Autor autor = ;

            return View(Autori.Get(id));
        }

        public IActionResult Create()
        {
            List<Knjiga> knjige = new List<Knjiga>(); // Knjige.Get().ToList();

            AutorModel model = new AutorModel()
            {
                listaSvihKnjiga = knjige.Select(x => new SelectListItem()
                {
                    Value = x.kId.ToString(),
                    Text = x.Naslov
                })
            };

            return View(model);
        }

        public IActionResult Update(Autor autor)
        {
            if (autor.aId > 0)
            {
                Autori.Update(autor, autor.aId);
            }
            else
            {
                Autori.Insert(autor);
            }
            Autori.Save();
            return RedirectToAction("Index");
        }

        public IActionResult SaveNew(AutorModel autorModel)
        {
            Autor autor = new Autor()
            {
                Ime = autorModel.Ime,
                Prezime = autorModel.Prezime,
                Email = autorModel.Email,
                Biografija = autorModel.Biografija
            };

            Autori.Insert(autor);
            Autori.Save();
            /* implement later
            foreach (int knjigaId in autorModel.Knjige)
            {
                AutorKnjiga.Insert(new AutorKnjiga()
                {
                    Autor = autor,
                    Knjiga = Knjige.Get(knjigaId)
                });
            }
            Save();*/

            return RedirectToAction("Index");
        }
    }
}
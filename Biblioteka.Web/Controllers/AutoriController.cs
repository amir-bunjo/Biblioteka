using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.DAL.Entities;
using Biblioteka.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteka.Web.Controllers
{
    public class AutoriController : BaseController
    {
        public IActionResult Index()
        {
            List<Autor> autori = Unit.Autori.Get().ToList();

            return View(autori);
        }

        public IActionResult Delete(int id)
        {
            Unit.Autori.Delete(id);
            Unit.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Autor autor = Unit.Autori.Get(id);
            return View(autor);
        }

        public IActionResult Edit(int id)
        {
            //Autor autor = ;

            return View(Unit.Autori.Get(id));
        }

        public IActionResult Create()
        {
            List<Knjiga> knjige = Unit.Knjige.Get().ToList();

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
                Unit.Autori.Update(autor, autor.aId);
            }
            else
            {
                Unit.Autori.Insert(autor);
            }
            Unit.Save();
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

            Unit.Autori.Insert(autor);
            Unit.Save();

            foreach (int knjigaId in autorModel.Knjige)
            {
                Unit.AutorKnjiga.Insert(new AutorKnjiga()
                {
                    Autor = autor,
                    Knjiga = Unit.Knjige.Get(knjigaId)
                });
            }
            Unit.Save();

            return RedirectToAction("Index");
        }
    }
}
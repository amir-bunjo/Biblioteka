using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.DAL;
using Biblioteka.DAL.Entities;
using Biblioteka.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteka.Web.Controllers
{
    public class KnjigeController : BaseController
    {

        public IActionResult Index()
        {
            List<Knjiga> knjige = Unit.Knjige.Get().ToList();

            return View(knjige);
        }

        public IActionResult Delete(int id)
        {
            Unit.Knjige.Delete(id);
            Unit.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Knjiga knjiga = Unit.Knjige.Get(id);
            return View(knjiga);
        }

        public IActionResult Edit(int id)
        {
            Knjiga knjiga = Unit.Knjige.Get(id);

            return View(knjiga);
        }

        public IActionResult Create()
        {
            List<Izdavac> izdavaci = Unit.Izdavaci.Get().ToList();
            List<Autor> autori = Unit.Autori.Get().ToList();

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

        public IActionResult Update(Knjiga knjiga)
        {
            if (knjiga.kId > 0)
            {
                Unit.Knjige.Update(knjiga, knjiga.kId);
            }
            else
            {
                Unit.Knjige.Insert(knjiga);
            }
            Unit.Save();
            return RedirectToAction("Index");
        }

        public IActionResult SaveNew(KnjigaModel knjigaModel)
        {
           
            Knjiga knjiga = new Knjiga()
            {
                kId = knjigaModel.kId,
                Naslov = knjigaModel.Naslov ,
                Cijena = knjigaModel.Cijena,
                Izdavac = Unit.Izdavaci.Get(knjigaModel.Izdavac)
            };
            Unit.Knjige.Insert(knjiga);
            Unit.Save();

            foreach(int autorId in knjigaModel.Autori)
            {
                Unit.AutorKnjiga.Insert(new AutorKnjiga()
                {
                    Autor = Unit.Autori.Get(autorId),
                    Knjiga = knjiga
                });
            }
            Unit.Save();
            return RedirectToAction("Index");
        }
    }
}
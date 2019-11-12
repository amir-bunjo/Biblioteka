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
    public class IzdavaciController : BaseController
    {
        public IActionResult Index()
        {
            List<Izdavac> izdavaci = Unit.Izdavaci.Get().ToList();


            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem( ){ Text = "1.item",Value="1"}  );
            listItems.Add(new SelectListItem() { Text = "2.item", Value = "2" });

            ViewData.Add("items", listItems);

            return View(izdavaci);
        }

        public IActionResult Delete(int id)
        {
            Unit.Izdavaci.Delete(id);
            Unit.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Izdavac izdavac = Unit.Izdavaci.Get(id);
            return View(izdavac);
        }

        public IActionResult Edit(int id)
        {
            Izdavac izdavac = Unit.Izdavaci.Get(id);

            return View(izdavac);
        }

        public IActionResult Create()
        {
            List<Knjiga> knjige = Unit.Knjige.Get().ToList();

            IzdavacModel model = new IzdavacModel()
            {
                listaSvihKnjiga = knjige.Select(x => new SelectListItem()
                {
                    Value = x.kId.ToString(),
                    Text = x.Naslov
                })
            };

            return View(model);
        }

        public IActionResult Update(Izdavac izdavac)
        {
            if (izdavac.Id > 0)
            {
                Unit.Izdavaci.Update(izdavac, izdavac.Id);
            }
            else
            {
                Unit.Izdavaci.Insert(izdavac);
            }
            Unit.Save();
            return RedirectToAction("Index");
        }

        public IActionResult SaveNew(IzdavacModel izdavacModel)
        {
            Izdavac izdavac = new Izdavac()
            {
                Ime = izdavacModel.Ime,
                Sjediste = izdavacModel.Sjediste,

            };

            Unit.Izdavaci.Insert(izdavac);
            Unit.Save();

            foreach (int knjigaId in izdavacModel.Knjige)
            {
                Knjiga knjiga = Unit.Knjige.Get(knjigaId);
                knjiga.Izdavac = Unit.Izdavaci.Get(izdavac.Id);
            }
            Unit.Save();

            return RedirectToAction("Index");
        }
    }
}
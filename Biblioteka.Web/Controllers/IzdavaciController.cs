using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.Web.DAL.Entities;
using Biblioteka.Web.DAL.Repositories;
using Biblioteka.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteka.Web.Controllers
{
    [Authorize(Roles = "Administrator,UserTest")]
    public class IzdavaciController : BaseController
    {

        public IzdavaciController(IRepository<Knjiga> repository, IRepository<Autor> repositoryA, IRepository<Izdavac> repositoryI)
                                        : base(repository, repositoryA, repositoryI) { }

        public IActionResult Index()
        {
            List<Izdavac> izdavaci = Izdavaci.Get().ToList();

            List<SelectListItem> listItems = new List<SelectListItem>
            {
                new SelectListItem() { Text = "1.item", Value = "1" },
                new SelectListItem() { Text = "2.item", Value = "2" }
            };

            ViewData.Add("items", listItems);

            return View(izdavaci);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            Izdavaci.Delete(id);
            Izdavaci.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Izdavac izdavac = Izdavaci.Get(id);
            return View(izdavac);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            Izdavac izdavac = Izdavaci.Get(id);

            return View(izdavac);
        }


        public IActionResult Create()
        {
            List<Knjiga> knjige = new List<Knjiga>(); // Knjige.Get().ToList();

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

        [Authorize(Roles = "Administrator")]
        public IActionResult Update(Izdavac izdavac)
        {
            if (izdavac.Id > 0)
            {
                Izdavaci.Update(izdavac, izdavac.Id);
            }
            else
            {
                Izdavaci.Insert(izdavac);
            }
            Izdavaci.Save();
            return RedirectToAction("Index");
        }

        public IActionResult SaveNew(IzdavacModel izdavacModel)
        {
            Izdavac izdavac = new Izdavac()
            {
                Ime = izdavacModel.Ime,
                Sjediste = izdavacModel.Sjediste,

            };

            Izdavaci.Insert(izdavac);
            Izdavaci.Save();
            /* implement later saving selected books while creating new Publisher
            foreach (int knjigaId in izdavacModel.Knjige)
            {
                Knjiga knjiga = Knjige.Get(knjigaId);
                knjiga.Izdavac =Izdavaci.Get(izdavac.Id);
            }
            Izdavaci.Save(); */

            return RedirectToAction("Index");
        }
    }
}
using MagazinJocuriVideo.Models;
using MagazinJocuriVideo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinJocuriVideo.Controllers
{
   
    public class CosCumparaturiController : Controller
    {
        private CosCumparaturiRepository cosCumparaturiRepository = new CosCumparaturiRepository();
        private FacturaRepository facturaRepository = new FacturaRepository();
        private ProdusRepository produsRepository = new ProdusRepository();
        // GET: CosCumparaturi
        public ActionResult Index()
        {
            return View();
        }

        // GET: CosCumparaturi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CosCumparaturi/Create
        public ActionResult Create()
        {
            //ProdusModels produs = produsRepository.GetProdusById(id);
            return View("CreateCosCumparaturi");
        }

        // POST: CosCumparaturi/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CosCumparaturiModels cosCumparaturiModels = new CosCumparaturiModels();
                UpdateModel(cosCumparaturiModels);
                cosCumparaturiModels.IdComanda=facturaRepository.UltimaFactura();
                Console.WriteLine(cosCumparaturiModels.IdComanda);

                cosCumparaturiRepository.InserareCosCumparaturi(cosCumparaturiModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCosCumparaturi");
            }
        }

        // GET: CosCumparaturi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CosCumparaturi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CosCumparaturi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CosCumparaturi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

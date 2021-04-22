using MagazinJocuriVideo.Models;
using MagazinJocuriVideo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinJocuriVideo.Controllers
{
    public class ProdusController : Controller
    {
        private ProdusRepository produsRepository = new ProdusRepository();
        // GET: Produs
        public ActionResult Index()
        {
            List<ProdusModels> produse = produsRepository.GetAllProduse();
            foreach(var item in produse)
            {
                item.Pret += item.Pret * (decimal)0.19;
            }
            return View("Index",produse);
        }

        // GET: Produs/Details/5
        public ActionResult Details(int id)
        {
            ProdusModels produs = produsRepository.GetProdusById(id);
            return View("DetailsProdus",produs);
        }

        // GET: Produs/Create
        public ActionResult Create()
        {
            return View("CreateProdus");
        }

        // POST: Produs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ProdusModels produsModels = new ProdusModels();
                UpdateModel(produsModels);

                produsRepository.InserareProdus(produsModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateProdus");
            }
        }

        // GET: Produs/Edit/5
        public ActionResult Edit(int id)
        {
            ProdusModels produs = produsRepository.GetProdusById(id);
            return View("EditProdus",produs);
        }

        // POST: Produs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ProdusModels produsModels = new ProdusModels();
                UpdateModel(produsModels);

                produsRepository.UpdateProdus(produsModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditProdus");
            }
        }

        // GET: Produs/Delete/5
        public ActionResult Delete(int id)
        {
            ProdusModels produs = produsRepository.GetProdusById(id);
            return View("DeleteProdus", produs);
        }

        // POST: Produs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                produsRepository.DeleteProdus(id);
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteProdus");
            }
        }
    }
}

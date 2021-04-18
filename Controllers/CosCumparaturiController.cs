﻿using MagazinJocuriVideo.Models;
using MagazinJocuriVideo.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            
            
            
            List<CosVizualizare> cosVizualizare = new List<CosVizualizare>();
            List<CosCumparaturiModels> cos = cosCumparaturiRepository.GetAllCos();
            foreach (CosCumparaturiModels cc in cos)
            {
                CosVizualizare obiect = new CosVizualizare();
                obiect.IdCos = cc.IdCos;
                obiect.Nume = produsRepository.GetProdusById(cc.CodProdusId).NumeProdus;
                obiect.Cantitate=cc.Cantitate;
                obiect.Pret=cc.Pret;
                cosVizualizare.Add(obiect);
            }
            return View("Index", cosVizualizare);
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
        public ActionResult Create(int id,FormCollection collection)
        {
            try
            {
                ProdusModels produs = new ProdusModels();
                produs = produsRepository.GetProdusById(id);
                CosCumparaturiModels cosCumparaturiModels = new CosCumparaturiModels();
                UpdateModel(cosCumparaturiModels);
                cosCumparaturiModels.CodProdusId = id;
                cosCumparaturiModels.IdComanda=facturaRepository.UltimaFactura();
                cosCumparaturiModels.Pret = cosCumparaturiModels.Cantitate * produs.Pret;
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
            CosCumparaturiModels cos = cosCumparaturiRepository.GetProdusById(id);
            return View("EditCosCumparaturi", cos);
        }

        // POST: CosCumparaturi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                CosCumparaturiModels cosCumparaturiModels = new CosCumparaturiModels();
                cosCumparaturiModels = cosCumparaturiRepository.GetProdusById(id);
                UpdateModel(cosCumparaturiModels);

                cosCumparaturiRepository.UpdateCosCumparaturi(cosCumparaturiModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCosCumparaturi");
            }
        }

        // GET: CosCumparaturi/Delete/5
        public ActionResult Delete(int id)
        {
            CosCumparaturiModels cos = cosCumparaturiRepository.GetProdusById(id);
            return View("DeleteCosCumparaturi",cos);
        }

        // POST: CosCumparaturi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                cosCumparaturiRepository.DeleteProdusDinCos(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCosCumparaturi");
            }
        }
    }
}
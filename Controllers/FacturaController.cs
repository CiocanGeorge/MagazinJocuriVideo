using MagazinJocuriVideo.Models;
using MagazinJocuriVideo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinJocuriVideo.Controllers
{
    public class FacturaController : Controller
    {
        private CosCumparaturiRepository cosCumparaturiRepository = new CosCumparaturiRepository();
        private FacturaRepository facturaRepository = new FacturaRepository();
        private ClientRepository clientRepository = new ClientRepository();
        private ProdusRepository produsRepository = new ProdusRepository();
        // GET: Factura
        public ActionResult Index()
        {
            List<FacturaModels> factura = facturaRepository.GetAllFactura();
            return View("Index",factura);
        }

        // GET: Factura/Details/5
        public ActionResult Details(int id)
        {
            DetaliiIstoricFacturaModels detaliiFactura = new DetaliiIstoricFacturaModels();
            FacturaModels factura=facturaRepository.GetFacturaById(id);

            detaliiFactura.Adresa = factura.AdresaLivrare;
            detaliiFactura.Data = factura.Data;
            detaliiFactura.Total=factura.TotalPlata;
            var idFactura = factura.IdFactura;
            foreach(var item in cosCumparaturiRepository.GetAllProductByIdComanda(idFactura))
            {
                ProduseIstoricCumparareModels produse = new ProduseIstoricCumparareModels();
                var idProdus = produsRepository.GetProdusById(item.CodProdusId);
                produse.NumeProdus = idProdus.NumeProdus;
                produse.DescriereProdus = idProdus.Descriere;
                produse.Pret = idProdus.Pret;
                produse.NumeImagine = idProdus.NumeImagine;
                detaliiFactura.AddLista(produse);
            }
            

            return View("DetailsFactura", detaliiFactura);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            if(cosCumparaturiRepository.Ultimacomanda()!=facturaRepository.UltimaFactura())
            {
                return RedirectToAction("Index", "Produs");
            }
            decimal totalPret = cosCumparaturiRepository.TotalPlata();
            ViewBag.Total = totalPret.ToString();
            return View("CreateFactura");
        }

        // POST: Factura/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                FacturaModels facturaModels = new FacturaModels();
                UpdateModel(facturaModels);
                facturaModels.IdFactura = cosCumparaturiRepository.Ultimacomanda();
                facturaModels.IdCos = cosCumparaturiRepository.IdCos();
                facturaModels.IdClient = clientRepository.GetClientByEmail(User.Identity.Name);
                facturaModels.Data = DateTime.UtcNow;
                facturaModels.TotalPlata= cosCumparaturiRepository.TotalPlata();

                facturaRepository.InserareFactura(facturaModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int id)
        {
            FacturaModels factura = facturaRepository.GetFacturaById(id);
            return View("EditFactura",factura);
        }

        // POST: Factura/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                FacturaModels facturaVeche = facturaRepository.GetFacturaById(id);
                FacturaModels facturaNoua = new FacturaModels();
                UpdateModel(facturaNoua);
                facturaNoua.IdFactura = facturaVeche.IdFactura;
                facturaNoua.IdCos = facturaVeche.IdCos;
                facturaNoua.IdClient = facturaVeche.IdClient;
                facturaNoua.Data = facturaVeche.Data;
                facturaNoua.TotalPlata = facturaVeche.TotalPlata;

                facturaRepository.UpdateFactura(facturaNoua);

                

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditFactura");
            }
        }

        // GET: Factura/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Factura/Delete/5
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

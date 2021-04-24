using MagazinJocuriVideo.Models;
using MagazinJocuriVideo.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinJocuriVideo.Controllers
{
   [Authorize]
    public class CosCumparaturiController : Controller
    {
        private CosCumparaturiRepository cosCumparaturiRepository = new CosCumparaturiRepository();
        private FacturaRepository facturaRepository = new FacturaRepository();
        private ProdusRepository produsRepository = new ProdusRepository();
        private ClientRepository clientRepository = new ClientRepository();
        // GET: CosCumparaturi
        public ActionResult Index()
        {            
            List<CosVizualizare> cosVizualizare = new List<CosVizualizare>();
            List<CosCumparaturiModels> cos = cosCumparaturiRepository.GetAllCosByUser(clientRepository.GetClientByEmail(User.Identity.Name));
            foreach (CosCumparaturiModels cc in cos)
            {
                CosVizualizare obiect = new CosVizualizare();
                obiect.IdCos = cc.IdCos;
                obiect.Nume = produsRepository.GetProdusById(cc.CodProdusId).NumeProdus;
                obiect.Cantitate=cc.Cantitate;
                obiect.Pret=cc.Pret+cc.Pret*(decimal)0.19;
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
                if (cosCumparaturiRepository.ExistaProdus(id, clientRepository.GetClientByEmail(User.Identity.Name)))
                {
                    cosCumparaturiModels = cosCumparaturiRepository.GetCos(id, clientRepository.GetClientByEmail(User.Identity.Name));
                    int cantitate = cosCumparaturiRepository.GetCantitate(id, clientRepository.GetClientByEmail(User.Identity.Name));
                    UpdateModel(cosCumparaturiModels);
                    cosCumparaturiModels.Cantitate = cosCumparaturiModels.Cantitate + cantitate;
                    cosCumparaturiModels.Pret = produsRepository.GetProdusById(cosCumparaturiRepository.GetCodProdusId(id, clientRepository.GetClientByEmail(User.Identity.Name))).Pret * cosCumparaturiModels.Cantitate;
                    cosCumparaturiRepository.UpdateCosCumparaturi(cosCumparaturiModels);
               
                }
                else
                {
                    UpdateModel(cosCumparaturiModels);
                    cosCumparaturiModels.CodProdusId = id;
                    cosCumparaturiModels.IdComanda = facturaRepository.UltimaFactura();
                    cosCumparaturiModels.Pret = cosCumparaturiModels.Cantitate * produs.Pret;
                    cosCumparaturiModels.ClientId = clientRepository.GetClientByEmail(User.Identity.Name);

                    cosCumparaturiRepository.InserareCosCumparaturi(cosCumparaturiModels);
                }
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
                cosCumparaturiModels.Pret = produsRepository.GetProdusById(cosCumparaturiRepository.GetCodProdusId(id)).Pret * cosCumparaturiModels.Cantitate;

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

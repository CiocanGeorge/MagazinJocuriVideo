using MagazinJocuriVideo.Models;
using MagazinJocuriVideo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinJocuriVideo.Controllers
{
    public class ClientController : Controller
    {
        private ClientRepository clientRepository = new ClientRepository();
        private RolsRepository rol = new RolsRepository();
        // GET: Client
        public ActionResult Index()
        {
            List<ClientiModels> clienti = clientRepository.GetAllClient();
            return View("Index", clienti);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View("CreateClient");
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ClientiModels client = new ClientiModels();
                UpdateModel(client);

                string email = User.Identity.Name;
                client.Email = email;
                clientRepository.InserareClient(client, email);
                rol.TakeRols(email);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateClient");
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
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

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
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

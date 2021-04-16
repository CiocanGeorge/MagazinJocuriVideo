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
        private RolsRepository rolRepository = new RolsRepository();
        private AspNetUserRepository userRepository = new AspNetUserRepository();
        // GET: Client
        public ActionResult Index()
        {
            List<ClientiModels> clienti = clientRepository.GetAllClient();
            return View("Index", clienti);
        }

        // GET: Client/Details/5
        public ActionResult Details(Guid id)
        {
            ClientiModels clientiModels = clientRepository.GetClient(id);
            return View("DetailsClient",clientiModels);
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
                rolRepository.TakeRols(email);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateClient");
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(Guid id)
        {
            ClientiModels clientiModels = clientRepository.GetClient(id);
            return View("EditClient", clientiModels) ;
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                ClientiModels clientiModels = new ClientiModels();
                UpdateModel(clientiModels);
                clientiModels.IdClient = id;

                clientRepository.UpdateClient(clientiModels);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditClient");
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(Guid id)
        {
            ClientiModels clientiModels = clientRepository.GetClient(id);
            return View("DeleteClient",clientiModels);
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                clientRepository.DeleteClient(id);
                rolRepository.DeleteUserRol(id);
                userRepository.DeleteUser(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteClient");
            }
        }
    }
}
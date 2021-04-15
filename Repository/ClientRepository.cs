using MagazinJocuriVideo.Models;
using MagazinJocuriVideo.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Repository
{
    public class ClientRepository
    {
        private MagazinJocuriVideoDataContextDataContext dbContext;
        public ClientRepository()
        {
            dbContext = new MagazinJocuriVideoDataContextDataContext();
        }
        public ClientRepository(MagazinJocuriVideoDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public ClientiModels GetClient(Guid id)
        {
            var client = dbContext.Clientis.FirstOrDefault(x => x.IdClient == id);
            return MapDbObjectToModel(client);
        }

        public List<ClientiModels> GetAllClient()
        {
            List<ClientiModels> clienti = new List<ClientiModels>();
            foreach (Clienti client in dbContext.Clientis)
            {
                clienti.Add(MapDbObjectToModel(client));
            }
            return clienti;
        }


        public void InserareClient(ClientiModels client, string email)
        {
            var id = dbContext.AspNetUsers.FirstOrDefault(x => x.Email == email);
            client.IdClient = new Guid(id.Id);
            dbContext.Clientis.InsertOnSubmit(MapModelToDbObject(client));
            dbContext.SubmitChanges();
        }

        private Clienti MapModelToDbObject(ClientiModels client)
        {
            Clienti clientDb = new Clienti();
            if (clientDb != null)
            {
                clientDb.IdClient = client.IdClient;
                clientDb.Name = client.Nume;
                clientDb.Prenume = client.Prenume;
                clientDb.Telefon = client.Telefon;
                clientDb.Email = client.Email;
                clientDb.Adresa = client.Adresa;
                return clientDb;
            }
            return null;
        }

        private ClientiModels MapDbObjectToModel(Clienti clientDb)
        {
            ClientiModels client = new ClientiModels();
            if (clientDb != null)
            {
                client.IdClient = clientDb.IdClient;
                client.Nume = clientDb.Name;
                client.Prenume = clientDb.Prenume;
                client.Telefon = clientDb.Telefon;
                client.Email = clientDb.Email;
                client.Adresa = clientDb.Adresa;
                return client;
            }
            return null;
        }
    }
}
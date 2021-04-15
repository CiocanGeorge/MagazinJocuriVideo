using MagazinJocuriVideo.Models;
using MagazinJocuriVideo.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Repository
{
    public class ProdusRepository
    {
        private MagazinJocuriVideoDataContextDataContext dbContext;
        public ProdusRepository()
        {
            dbContext = new MagazinJocuriVideoDataContextDataContext();
        }
        public ProdusRepository(MagazinJocuriVideoDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<ProdusModels> GetAllProduse()
        {
            List<ProdusModels> produsModel = new List<ProdusModels>();
            foreach(Produse produs in dbContext.Produses)
            {
                produsModel.Add(MapDbObjectToModel(produs));
            }
            return produsModel;
        }
        public ProdusModels GetProdusById(int id)
        {
            var produs = dbContext.Produses.FirstOrDefault(x => x.CodProdusId == id);
            return MapDbObjectToModel(produs);
        }
        public void InserareProdus(ProdusModels produs)
        {
            dbContext.Produses.InsertOnSubmit(MapModelToDbObject(produs));
            dbContext.SubmitChanges();
        }


        public void UpdateProdus(ProdusModels produs)
        {
            Produse produsDb = dbContext.Produses.FirstOrDefault(x => x.CodProdusId == produs.CodProdusId);
            if(produsDb!=null)
            {
                produsDb.CodProdusId = produs.CodProdusId;
                produsDb.NumeProdus = produs.NumeProdus;
                produsDb.Descriere = produs.Descriere;
                produsDb.Pret = produs.Pret;
                produsDb.NumeImagine = produs.NumeImagine;
                dbContext.SubmitChanges();
            }
        }
      
        public void DeleteProdus(int id)
        {
            Produse produsDb = dbContext.Produses.FirstOrDefault(x => x.CodProdusId == id);
            if(produsDb!=null)
            {
                dbContext.Produses.DeleteOnSubmit(produsDb);
                dbContext.SubmitChanges();
            }
        }

        private Produse MapModelToDbObject(ProdusModels produs)
        {
            Produse produsDb = new Produse();
            if(produs!=null)
            {
                produsDb.CodProdusId = produs.CodProdusId;
                produsDb.NumeProdus = produs.NumeProdus;
                produsDb.Descriere = produs.Descriere;
                produsDb.Pret = produs.Pret;
                produsDb.NumeImagine = produs.NumeImagine;
                return produsDb;
            }
            return null;
        }

        private ProdusModels MapDbObjectToModel(Produse produsDb)
        {
            ProdusModels produs = new ProdusModels();
            if(produsDb!=null)
            {
                produs.CodProdusId = produsDb.CodProdusId;
                produs.NumeProdus = produsDb.NumeProdus;
                produs.Descriere = produsDb.Descriere;
                produs.Pret = produsDb.Pret;
                produs.NumeImagine = produsDb.NumeImagine;
                return produs;
            }
            return null;
        }
    }
}
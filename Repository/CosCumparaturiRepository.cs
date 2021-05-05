using MagazinJocuriVideo.Models;
using MagazinJocuriVideo.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Repository
{
    public class CosCumparaturiRepository
    {
        private MagazinJocuriVideoDataContextDataContext dbContext;
        private FacturaRepository facturaRepository = new FacturaRepository();
        private ProdusRepository produsRepository = new ProdusRepository();
        public CosCumparaturiRepository()
        {
            dbContext = new MagazinJocuriVideoDataContextDataContext();
        }
        public CosCumparaturiRepository(MagazinJocuriVideoDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<CosCumparaturiModels> GetAllCosByUser(Guid idClient)
        {
            int id;
            id = facturaRepository.UltimaFactura()-1;
            //int idFactura = dbContext.Facturas.LastOrDefault().IdFactura;
            List<CosCumparaturiModels> cosCumparaturi = new List<CosCumparaturiModels>();
            foreach(CosCumparaturi cos in dbContext.CosCumparaturis.Where(x=>x.IdComanda>id && x.IdClient==idClient))
            {
                cosCumparaturi.Add(MapDbObjectToModel(cos));
                
            }
            return cosCumparaturi;
        }

        public CosCumparaturiModels GetProdusById(int id)
        {
            return MapDbObjectToModel(dbContext.CosCumparaturis.FirstOrDefault(x=>x.IdCos==id));
        }
        public List<CosCumparaturiModels> GetAllProductByIdComanda(int id)
        {
            List<CosCumparaturiModels> listaCos = new List<CosCumparaturiModels>();
            foreach(var item in dbContext.CosCumparaturis.Where(x=>x.IdComanda==id))
            {
                listaCos.Add(MapDbObjectToModel(item));
            }
            return listaCos;
        }
        public CosCumparaturiModels GetCos(int id,Guid idClient)
        {
            return MapDbObjectToModel(dbContext.CosCumparaturis.FirstOrDefault(x => x.CodProdusId == id && x.IdClient==idClient && x.IdComanda==facturaRepository.UltimaFactura()));
        }
        public int GetCodProdusId(int id,Guid idClient)
        {
            return MapDbObjectToModel(dbContext.CosCumparaturis.FirstOrDefault(x => x.CodProdusId == id && x.IdClient == idClient)).CodProdusId;
        }
        public int GetCodProdusId(int id)
        {
            return MapDbObjectToModel(dbContext.CosCumparaturis.FirstOrDefault(x => x.IdCos == id)).CodProdusId;
        }
        public bool ExistaProdus(int id,Guid idClient)
        {
            ProdusModels produs = produsRepository.GetProdusById(id);
            CosCumparaturi cos = dbContext.CosCumparaturis.FirstOrDefault(x => x.CodProdusId == id && x.IdClient == idClient && x.IdComanda==facturaRepository.UltimaFactura());
            if (cos == null)
                return false;
            return true;
        }
        public int GetCantitate(int id, Guid idClient)
        {
            return dbContext.CosCumparaturis.OrderByDescending(x => x.CodProdusId == id && x.IdClient == idClient && x.IdComanda == facturaRepository.UltimaFactura()).FirstOrDefault().Cantitate;
        }
       public void DeleteProdusDinCos(int id)
        {
            CosCumparaturi cosDb = dbContext.CosCumparaturis.FirstOrDefault(x => x.IdCos == id);
            if(cosDb!=null)
            {
                dbContext.CosCumparaturis.DeleteOnSubmit(cosDb);
                dbContext.SubmitChanges();
            }
        }
        public int IdCos()
        {
            int idCos = 0;
            foreach (CosCumparaturi cos in dbContext.CosCumparaturis)
            {
                idCos = cos.IdCos;
            }
            return idCos;
        }
        public decimal TotalPlata(Guid id)
        {
            decimal total = 0;
            foreach(CosCumparaturi cos in dbContext.CosCumparaturis.Where(x=>x.IdComanda==Ultimacomanda(id) && x.IdClient==id))
            {
                total += cos.Pret;
            }
            return total;
        }
  


        public int Ultimacomanda(Guid id)
        {
            int cosId = 0;
            foreach(CosCumparaturi cos in dbContext.CosCumparaturis.Where(x=>x.IdClient==id))
            {
                cosId = cos.IdComanda;
            }
            return cosId;
        }
        public void InserareCosCumparaturi(CosCumparaturiModels cos)
        {
            dbContext.CosCumparaturis.InsertOnSubmit(MapModelToDbObject(cos));
            dbContext.SubmitChanges();
        }

        public void UpdateCosCumparaturi(CosCumparaturiModels cos)
        {
            CosCumparaturi cosDb = dbContext.CosCumparaturis.FirstOrDefault(x => x.IdCos == cos.IdCos);
            if(cosDb!=null)
            {
                cosDb.IdCos = cos.IdCos;
                cosDb.IdComanda = cos.IdComanda;
                cosDb.CodProdusId = cos.CodProdusId;
                cosDb.Cantitate = cos.Cantitate;
                cosDb.Pret = cos.Pret;
                cosDb.IdClient = cos.ClientId;
                dbContext.SubmitChanges();
            }
        }

        private CosCumparaturi MapModelToDbObject(CosCumparaturiModels cos)
        {
            CosCumparaturi cosDb = new CosCumparaturi();
            if (cos != null)
            {
                cosDb.IdCos = cos.IdCos;
                cosDb.IdComanda = cos.IdComanda;
                cosDb.CodProdusId = cos.CodProdusId;
                cosDb.Cantitate = cos.Cantitate;
                cosDb.Pret = cos.Pret;
                cosDb.IdClient = cos.ClientId;
                return cosDb;
            }
            return null;
        }

        private CosCumparaturiModels MapDbObjectToModel(CosCumparaturi cosDb)
        {
            CosCumparaturiModels cos = new CosCumparaturiModels();
            if(cosDb!=null)
            {
                cos.IdCos = cosDb.IdCos;
                cos.IdComanda = cosDb.IdComanda;
                cos.CodProdusId = cosDb.CodProdusId;
                cos.Cantitate = cosDb.Cantitate;
                cos.Pret = cosDb.Pret;
                cos.ClientId = cosDb.IdClient;
                return cos;
            }
            return null;
        }
    }
}
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
        public CosCumparaturiRepository()
        {
            dbContext = new MagazinJocuriVideoDataContextDataContext();
        }
        public CosCumparaturiRepository(MagazinJocuriVideoDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<CosCumparaturiModels> GetAllCos()
        {
            int id;
            id = facturaRepository.UltimaFactura()-1;
            //int idFactura = dbContext.Facturas.LastOrDefault().IdFactura;
            List<CosCumparaturiModels> cosCumparaturi = new List<CosCumparaturiModels>();
            foreach(CosCumparaturi cos in dbContext.CosCumparaturis.Where(x=>x.IdComanda>id))
            {
                cosCumparaturi.Add(MapDbObjectToModel(cos));
                
            }
            return cosCumparaturi;
        }

        public CosCumparaturiModels GetProdusById(int id)
        {
            return MapDbObjectToModel(dbContext.CosCumparaturis.FirstOrDefault(x=>x.IdCos==id));
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
                return cos;
            }
            return null;
        }
    }
}
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
            List<CosCumparaturiModels> cosCumparaturi = new List<CosCumparaturiModels>();
            foreach(CosCumparaturi cos in dbContext.CosCumparaturis)
            {
                cosCumparaturi.Add(MapDbObjectToModel(cos));
            }
            return cosCumparaturi;
        }

        public void InserareCosCumparaturi(CosCumparaturiModels cos)
        {
            dbContext.CosCumparaturis.InsertOnSubmit(MapModelToDbObject(cos));
            dbContext.SubmitChanges();
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
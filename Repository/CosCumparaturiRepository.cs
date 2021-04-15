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



        private CosCumparaturiModels MapDbObjectToModel(CosCumparaturi cos)
        {
            throw new NotImplementedException();
        }
    }
}
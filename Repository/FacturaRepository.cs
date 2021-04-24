using MagazinJocuriVideo.Models;
using MagazinJocuriVideo.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Repository
{
    public class FacturaRepository
    {
        private MagazinJocuriVideoDataContextDataContext dbContext;
        public FacturaRepository()
        {
            dbContext = new MagazinJocuriVideoDataContextDataContext();
        }
        public FacturaRepository(MagazinJocuriVideoDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public int UltimaFactura()
        {
            /*
            FacturaModels factura = new FacturaModels();
            foreach (Factura produs in dbContext.Facturas)
            {
                factura=MapDbObjectToModel(produs);
            }
            return factura.IdFactura + 1;
            */
            FacturaModels factura = new FacturaModels();
            int valoare = 1;
            Factura collection = dbContext.Facturas.OrderByDescending(x=>x.IdFactura).FirstOrDefault();
            factura = MapDbObjectToModel(collection);
            if (factura != null)
                valoare = factura.IdFactura + 1;
            
            return valoare;
        }

        public List<FacturaModels> GetAllFactura()
        {
            List<FacturaModels> facturaModels = new List<FacturaModels>();
            foreach(Factura factura in dbContext.Facturas)
            {
                facturaModels.Add(MapDbObjectToModel(factura));
            }
            return facturaModels;
        }
        public FacturaModels GetFacturaById(int id)
        {
            return MapDbObjectToModel(dbContext.Facturas.FirstOrDefault(x=>x.IdFactura==id));
        }

        public void InserareFactura(FacturaModels factura)
        {
            dbContext.Facturas.InsertOnSubmit(MapModelToDbObject(factura));
            dbContext.SubmitChanges();
        }

        public void UpdateFactura(FacturaModels factura)
        {
            Factura facturaDb = dbContext.Facturas.FirstOrDefault(x => x.IdFactura == factura.IdFactura);
            if(facturaDb!=null)
            {
                facturaDb.IdFactura = factura.IdFactura;
                facturaDb.IdCos = factura.IdCos;
                facturaDb.Data = factura.Data;
                facturaDb.IdClient = factura.IdClient;
                facturaDb.TotalPlata = factura.TotalPlata;
                facturaDb.AdresaLivrare = factura.AdresaLivrare;
                dbContext.SubmitChanges();
            }
        }
        public void DeleteFactura(int id)
        {
            Factura facturaDb = dbContext.Facturas.FirstOrDefault(x => x.IdFactura == id);
            if(facturaDb!=null)
            {
                dbContext.Facturas.DeleteOnSubmit(facturaDb);
                dbContext.SubmitChanges();
            }
        }

        private Factura MapModelToDbObject(FacturaModels factura)
        {
            Factura facturaDb = new Factura();
            if (factura != null)
            {
                facturaDb.IdFactura = factura.IdFactura;
                facturaDb.IdCos = factura.IdCos;
                facturaDb.Data = factura.Data;
                facturaDb.IdClient = factura.IdClient;
                facturaDb.TotalPlata = factura.TotalPlata;
                facturaDb.AdresaLivrare = factura.AdresaLivrare;
                return facturaDb;
            }
            return null;
        }

        private FacturaModels MapDbObjectToModel(Factura facturaDb)
        {
            FacturaModels factura = new FacturaModels();
            Console.WriteLine(facturaDb);
            if (facturaDb != null)
            {
                factura.IdFactura = facturaDb.IdFactura;
                factura.IdCos = facturaDb.IdCos;
                factura.Data = facturaDb.Data;
                factura.IdClient = facturaDb.IdClient;
                factura.TotalPlata = facturaDb.TotalPlata;
                factura.AdresaLivrare = facturaDb.AdresaLivrare;
                return factura;
            }
            return null;
        }
    }
}
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
            FacturaModels factura = new FacturaModels();
            foreach (Factura produs in dbContext.Facturas)
            {
                factura=MapDbObjectToModel(produs);
            }
            return factura.IdFactura + 1;
            /*
            FacturaModels factura = new FacturaModels();
            int valoare = 0;
            factura = MapDbObjectToModel(dbContext.Facturas.LastOrDefault());
            if (factura != null)
                valoare = factura.IdFactura + 1;
            
            return valoare;*/
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
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
            int valoare = 0;
            var ultimaInregistrare = MapDbObjectToModel(dbContext.Facturas.LastOrDefault());
            if (ultimaInregistrare != null)
                valoare = ultimaInregistrare.IdFactura + 1;
            
            return valoare;
        }

        private FacturaModels MapDbObjectToModel(Factura facturaDb)
        {
            FacturaModels factura = new FacturaModels();
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
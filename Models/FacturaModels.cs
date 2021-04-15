using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Models
{
    public class FacturaModels
    {
        public int IdFactura { get; set; }

        public int IdCos { get; set; }

        public DateTime Data { get; set; }

        public Guid IdClient { get; set; }

        public decimal TotalPlata { get; set; }

        public string AdresaLivrare { get; set; }
    }
}
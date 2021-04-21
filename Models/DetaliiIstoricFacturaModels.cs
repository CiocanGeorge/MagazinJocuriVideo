using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Models
{
    public class DetaliiIstoricFacturaModels
    {
        public string Adresa { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        List<ProduseIstoricCumparareModels> produse= new List<ProduseIstoricCumparareModels>();

        public void AddLista(ProduseIstoricCumparareModels prod)
        {
            produse.Add(prod);
        }
        public List<ProduseIstoricCumparareModels> ProduseCumparate()
        {
            return produse;
        }
    }
}
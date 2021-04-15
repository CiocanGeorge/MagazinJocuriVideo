using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Models
{
    public class ProdusModels
    {
        public int CodProdusId { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        [StringLength(100, ErrorMessage = "Maxim 100 caractere")]
        public string NumeProdus { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public string Descriere { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public decimal Pret { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        [StringLength(200, ErrorMessage = "Maxim 200 caractere")]
        public string NumeImagine { get; set; }

    }
}
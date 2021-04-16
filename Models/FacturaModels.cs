using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Models
{
    public class FacturaModels
    {
        public int IdFactura { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public int IdCos { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public Guid IdClient { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public decimal TotalPlata { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        [StringLength(200, ErrorMessage = "Maxim 200 caractere")]
        public string AdresaLivrare { get; set; }
    }
}
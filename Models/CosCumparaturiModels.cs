using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Models
{
    public class CosCumparaturiModels
    {
        public int IdCos { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public int IdComanda { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public int CodProdusId { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public int Cantitate { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public decimal Pret { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        public Guid ClientId { get; set; }

    }
}
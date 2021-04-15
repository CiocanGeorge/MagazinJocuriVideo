using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Models
{
    public class ClientiModels
    {
        public Guid IdClient { get; set; }

        [Required(ErrorMessage="Obligatoriu")]
        [StringLength(100,ErrorMessage ="Maxim 100 caractere")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        [StringLength(100, ErrorMessage = "Maxim 100 caractere")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        [StringLength(10, ErrorMessage = "Maxim 10 caractere")]
        public string Telefon { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Obligatoriu")]
        [StringLength(200, ErrorMessage = "Maxim 200 caractere")]
        public string Adresa { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Scarpe_ecommerce.Models
{
    public class Articoli
    {
        public int IDarticolo { get; set; }

        [Display(Name = "Modello")]
        [Required(ErrorMessage = "Obbligatorio")]
        public string NomeArticolo { get; set; }

        [Display(Name = "Prezzo")]        
        public decimal Prezzo { get; set; }

        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }

        [Display(Name = "Immagine principale")]
        public string imgCopertina { get; set; }

        [Display(Name = "Seconda immagine")]
        public string IMG1 { get; set; }

        [Display(Name = "Terza immagine")]
        public string IMG2 { get; set; }
    }   
}
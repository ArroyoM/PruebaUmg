using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace PruebaUmg.Models.ViewModel
{
    public class Docente
    {
        [Display(Name ="error")]
        [Required]
        public int Id { get; set; }


        public string nombre { get; set; }
    }
}
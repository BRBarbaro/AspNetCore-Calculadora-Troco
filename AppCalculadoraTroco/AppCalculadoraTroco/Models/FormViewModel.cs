using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCalculadoraTroco.Models
{
    public class FormViewModel
    {
        [Required(ErrorMessage = "Obrigatório informar valor da compra.")]
        [Display(Name = "Valor da Compra")] 
        public double? ValorCompra { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o valor pago.")]
        [Display(Name = "Valor Pago")]
        public double? ValorPago { get; set; }

    }
}

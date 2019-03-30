using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCalculadoraTroco.Models
{
    public class TrocoModel
    {
        public double ValorCompra { get; set; }
        public double ValorPago { get; set; }
        public double Troco { get; set; }
        public List<double> TotalCedulas { get; set; }
        public List<double> TotalMoedas { get; set; }
    }
}

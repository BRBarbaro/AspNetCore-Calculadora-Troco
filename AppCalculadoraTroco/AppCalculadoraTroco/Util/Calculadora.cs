using AppCalculadoraTroco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCalculadoraTroco.Util
{
    public class Calculadora
    {

        public TrocoModel Calcula(double valorCompra, double valorPago)
        {
            double[] cedulas = new double[] { 100.00, 50.00, 10.00, 5.00, 1.00 };
            double[] moedas = new double[] { 0.50, 0.10, 0.05, 0.01 };

            var troco = valorPago - valorCompra;

            TrocoModel trocoModel = new TrocoModel
            {
                ValorCompra = valorCompra,
                ValorPago = valorPago,
                Troco = troco,
                TotalCedulas = new List<double>(),
                TotalMoedas = new List<double>()
            };

            double valorSelecionado = 0.00;

            while (troco > 0)
            {
                if (troco >= 1)
                {
                    valorSelecionado = cedulas.FirstOrDefault(x => x <= troco);
                    trocoModel.TotalCedulas.Add(valorSelecionado);
                }
                else
                {
                    valorSelecionado = moedas.FirstOrDefault(x => x <= troco);
                    trocoModel.TotalMoedas.Add(valorSelecionado);
                }

                troco = Math.Round(troco - valorSelecionado, 2);
            }
            return trocoModel;

        }
    }
}

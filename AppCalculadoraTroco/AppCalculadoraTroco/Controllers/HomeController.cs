using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppCalculadoraTroco.Models;
using AppCalculadoraTroco.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppCalculadoraTroco.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // POST api/home
        [HttpPost]
        public ActionResult<TrocoModel> Post(FormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.ValidationState);
            }

            if (model.ValorCompra > model.ValorPago)
            {
                return BadRequest("Pagamento insuficiente.");
            }

            Calculadora calculadora = new Calculadora();
        

            return Ok(calculadora.Calcula(Convert.ToDouble(model.ValorCompra), 
                                          Convert.ToDouble(model.ValorPago)));
        }

    }
}

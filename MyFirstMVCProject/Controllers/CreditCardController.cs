using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCProject.Models;
using System.Net;
using System.Web.Http;
using Microsoft.AspNetCore.Authorization;
//   <td><div class="btn btn-danger">@Html.ActionLink("ELIMINAR", "EliminarTarjeta", "CreditCard", new { id = @element.Id })</div> </td>
namespace MyFirstMVCProject.Controllers
{public class CreditCardController : Controller {
        DataBase.DB database = new DataBase.DB();
        public CreditCardController() { }


        [System.Web.Http.HttpPost]
        public ActionResult CrearTarjeta(CreditCard model) { database.CrearTarjeta(model); return Redirect("Index"); }


        [System.Web.Http.HttpGet]
        public IActionResult Index(){return View("~/Views/CreditCard/CreditsCards.cshtml", (List<CreditCard>)database.DevolverTodas());}


        [System.Web.Http.HttpGet]
        public ActionResult SeleccionarTarjeta(int Id) { return Json(database.SeleccionarTarjeta(Id), null); }


        [System.Web.Http.HttpGet]
        public ActionResult AllJson() { return Json((List<CreditCard>)database.DevolverTodas(), null); }


        [System.Web.Http.HttpGet]
        public IActionResult VistaActualizar(int id) { return View("~/Views/CreditCard/ccedit.cshtml", (CreditCard)database.SeleccionarTarjeta(id)); }


        [System.Web.Http.HttpPut]
        public ActionResult ActualizarTarjeta(CreditCard model){ database.ActualizarTarjeta(model);return Redirect("Index"); }


        [System.Web.Http.HttpGet]
        public ActionResult EliminarTarjeta(int Id) {database.BorrarTarjeta(Id); return RedirectToAction("Index", "CreditCard"); }

    }

}



















/*List<CreditCard> tarjetas = new List<CreditCard> {
              new CreditCard("","01234567890","1/2017","081","3245"),
              new CreditCard("","01234567891","2/2017","082","4322"),
              new CreditCard("","01234567892","3/2017","083","4324"),
              new CreditCard("","01234567893","4/2017","084","7545"),
              new CreditCard("","01234567894","5/2017","085","7423"),
              new CreditCard("","01234567895","6/2017","086","8954"),
              new CreditCard("","01234567896", "7/2017", "087", "0945"),
              new CreditCard("","01234567897","8/2017","088","1345"),
              new CreditCard("","01234567898","9/2017","089","1276"),
              new CreditCard("","01234567899","10/2017","080","6478")
          };*/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contas_a_Pagar___Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sobre";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Endereço e Contato";

            return View();
        }
    }
}
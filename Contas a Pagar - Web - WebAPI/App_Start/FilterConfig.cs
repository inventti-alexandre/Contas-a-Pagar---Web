﻿using System.Web;
using System.Web.Mvc;

namespace Contas_a_Pagar___Web___WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace direccion_evaluacion.Controllers
{
    public class VerificacionDeSession : Controller
    {
        public VerificacionDeSession()
        {

        }
        public bool Autenticacion()
        {
            return Session["usuario"] != null;   
        }
    }
}
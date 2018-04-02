using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace direccion_evaluacion.Models
{
    public class SubirArchivosModelo
    {
        public String Confirmacion { get; set; }
        public String Estado { get; set; }
        public Exception error { get; set; }

        public void SubirArchivo(String ruta, HttpPostedFileBase file)
        {
            try
            {
                file.SaveAs(ruta);
                this.Confirmacion = "Archivo subido correctamente";
                this.Estado = "1";
            }
                
             
            catch ( Exception ex)
            {
                
                this.error = ex;
            }
        }
        public void EditarArchivo(String ruta, HttpPostedFileBase file)
        {
            try
            {
                file.SaveAs(ruta);
                this.Confirmacion = "Archivo editado correctamente";
                this.Estado = "1";
            }


            catch (Exception ex)
            {

                this.error = ex;
            }
        }
    }
}
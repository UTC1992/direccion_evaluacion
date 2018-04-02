using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace direccion_evaluacion.Controllers
{
    public class DeleteFile
    {
        public string Borrar(string ruta)
        {
            // Delete a file by using File class static method...
            if (System.IO.File.Exists(@ruta))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@ruta);
                    return "eliminado";
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return e.Message;
                }

            }
            return "";
        }
    }
}
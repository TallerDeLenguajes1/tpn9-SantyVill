using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualBasic;

namespace Helpers
{
    public static class SoporteParaConfiguracion
    {
        public static bool CrearArchivoDeConfiguracion(string ruta, string nombre)
        {
            if (!(Directory.Exists(ruta)))
            {
                Directory.CreateDirectory(ruta);
            }
            if (!(File.Exists(ruta+nombre+".dat")))
            {
                File.Create(ruta + nombre + ".dat");
                return true;
            }
            File.WriteAllText(ruta + nombre + ".dat", ruta);
            return false;
        }
        public static string LeerConfiguracion(string ruta, string nombre) {
            string dir = ruta + @"\" + nombre + ".dat";
            if (File.Exists(dir))
            {
                //FileStream miArchivo = new FileStream(dir, FileMode.Open);
                //StreamReader Leer = new StreamReader(miArchivo);
                string path = File.ReadAllText(dir);
                //miArchivo.Position = 0;
                //miArchivo.Close();
                return path;
            }
            return null;
        }
    }
}

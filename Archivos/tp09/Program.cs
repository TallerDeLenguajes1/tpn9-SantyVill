using Helpers;
using System;
using System.IO;

namespace tp09
{
    class Program
    {
        static void Main(string[] args)
        {
            string directorio = @"c:\Repogit\tpn9-SantyVill\Prueba\";
            SoporteParaConfiguracion.CrearArchivoDeConfiguracion(directorio,"destino");
            string[] direccionArchivos = Directory.GetFiles(@"\Repogit\tpn9-SantyVill\tp09\tp09\bin\debug");
            string patch = SoporteParaConfiguracion.LeerConfiguracion(@"\Repogit\tpn9-SantyVill\Prueba\","destino");
            Console.WriteLine("Listado de archivos: ");
            foreach (string item in direccionArchivos)
            {
                FileInfo ArchInf = new FileInfo(item);
                Console.WriteLine(item);
                if (ArchInf.Extension==".mp3" || ArchInf.Extension==".txt")
                {
                    string destino = @"\Repogit\tpn9-SantyVill\Prueba\" + ArchInf.Name;
                    //Console.WriteLine("destino: "+destino+"\nitem: "+item);
                    File.Move(item, destino);
                }
            }
        }
    }
}

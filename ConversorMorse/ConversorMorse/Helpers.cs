﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace ConversorMorse
{
    static public class ConversorDeMorse
    {
        static Dictionary<string, string> DiccMorse = new Dictionary<string, string>()
        {
            { ".-", "a" },{ "-...", "b" },{ "-.-.", "c" },
            { "-..", "d" },{ ".", "e" },{ "..-.", "f" },
            { "--.", "g" },{ "....", "h" },{ "..", "i" },
            { ".---", "j" },{ "-.-", "k" },{ ".-..", "l" },
            { "--", "m" },{ "-.", "n" },{ "---", "o" },
            { ".--.", "p" },{ "--.-", "q" },{ ".-.", "r" },
            { "...", "s" },{ "-", "t" },{ "..-", "u" },
            { "...-", "v" },{ ".--", "w" },{ "-..-", "x" },
            { "-.--", "y" },{ "--..", "z" }
        };
        static Dictionary<string, string> DiccTextAMorse = new Dictionary<string, string>()
        {
            { "a",".-"  },{ "b","-..."  },{ "c", "-.-." },
            { "d","-.."  },{ "e","."  },{ "f","..-."  },
            { "g","--."  },{"h" ,"...."  },{ "i",".."  },
            { "j",".---"  },{ "k","-.-"  },{ "l",".-.."  },
            { "m", "--" },{"n", "-."  },{ "o", "---" },
            { "p", ".--." },{ "q", "--.-" },{ "r", ".-." },
            { "s", "..." },{ "t", "-" },{ "u", "..-" },
            { "v", "...-" },{ "w", ".--" },{ "x", "-..-" },
            { "y", "-.--" },{ "z" , "--.."}
        };

        static public string MorseATexto(string cadena)
        {
            string conversion="";
            string[] palabras = cadena.Split("/");
            foreach (string item in palabras)
            {
                string[] letras = item.Split(" ");
                foreach (string letra in letras)
                {
                    if (DiccMorse.ContainsKey(letra))
                    {
                        conversion += DiccMorse[letra];
                    }
                }
                conversion += " ";
            }
            return conversion;
        }
        static public string TextoAMorse(string cadena)
        {
            cadena = cadena.ToLower();
            string conversion = "";
            foreach (char item in cadena)
            {
                if (DiccTextAMorse.ContainsKey(item.ToString()))
                {
                    conversion += DiccTextAMorse[item.ToString()] + " ";
                }
                else if (item.ToString()==" ")
                {
                    conversion += "/";
                }
            }
            return conversion;
        }
        static public string CrearMorse(string cadena)
        {
            string ruta = @"C:\Repogit\Mensajes\";
            string nombre = "Morse_" + DateTime.Now.ToString("yy-MM-dd hh-mm-ss");
            string Path=ruta+nombre+".txt";
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            FileStream archivos = File.Create(Path);
            archivos.Close();
            File.WriteAllText(Path, TextoAMorse(cadena));
            return Path;
        }
        static public string LeerMorse(string path)
        {
            if (File.Exists(path))
            {
                FileInfo archivo = new FileInfo(path);
                string[] fecha = archivo.Name.Split("_");
                string texto=File.ReadAllText(path);
                string NPath = archivo.Directory + "/Texto_" + fecha[1];
                FileStream aux = File.Create(NPath);
                aux.Close();
                texto = MorseATexto(texto);
                File.WriteAllText(NPath, texto);
                return texto;
            }
            return "No se encontro el archivo.";
        }
    }
}

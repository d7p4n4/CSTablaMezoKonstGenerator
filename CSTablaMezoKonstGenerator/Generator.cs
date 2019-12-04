using d7p4n4Namespace.Final.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSTablaMezoKonstGenerator
{
    class Generator
    {
        public static void generateClass(string outputPath, Tabla tabla)
        {
            string[] text = readIn("TemplateTabla");

            string replaced = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("mezokKonstans"))
                {
                    string newline = "";
                    foreach(var oszlop in tabla.TablaOszlopLista)
                    {
                        newline = newline + text[i + 1].Replace("#mezoNev#", oszlop.Kod) + "\n";
                        Console.WriteLine(newline);
                    }
                    replaced = replaced + newline + "\n";
                    i = i + 2;
                }
                replaced = replaced + text[i] + "\n";
            }

            replaced = replaced.Replace("#tablaNev#", tabla.Megnevezes);

            writeOut(replaced, tabla.Megnevezes, outputPath);

        }

        public static string[] readIn(string fileName)
        {

            string textFile = "c:\\Templates\\c#\\Tabla\\" + fileName + ".csT";

            string[] text = File.ReadAllLines(textFile);

            return text;
        }

        public static void writeOut(string text, string fileName, string outputPath)
        {
            File.WriteAllText(outputPath + fileName + ".cs", text);

        }
    }
}
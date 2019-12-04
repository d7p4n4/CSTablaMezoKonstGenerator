using d7p4n4Namespace.Final.Class;
using System;
using System.IO;

namespace CSTablaMezoKonstGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Deserializer deserializer = new Deserializer();

            try
            {
                string[] files =
                    Directory.GetFiles("d:\\Server\\Visual_studio\\output_Xmls\\arntesztTablak\\", "*.xml", SearchOption.TopDirectoryOnly);

                Console.WriteLine(files.Length);

                foreach (var _file in files)
                {
                    Tabla ujTabla = new Tabla();
                    string _filename = Path.GetFileNameWithoutExtension(_file);
                    Console.WriteLine(_filename);

                    string textFile = Path.Combine("d:\\Server\\Visual_studio\\output_Xmls\\arntesztTablak\\", _filename + ".xml");

                    string text = File.ReadAllText(textFile);

                    ujTabla = deserializer.deser(text);
                    Generator.generateClass("d:\\Server\\Visual_studio\\AK\\outputTablak\\", ujTabla);

                }
            }
            catch (Exception _exception)
            {
                Console.WriteLine(_exception.Message);
            }
        }
    }
}

using System;
using System.IO;
using ProyectOCR.services;

namespace ProyectOCR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OCR PROJECT INICIADO");

            // Definir rutas base
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string inputPath = Path.Combine(basePath, "input");
            string outputPath = Path.Combine(basePath, "output");
            string tessDataPath = Path.Combine(basePath, "tessdata");

            // Asegurar que las carpetas existan
            Directory.CreateDirectory(inputPath);
            Directory.CreateDirectory(outputPath);
            Directory.CreateDirectory(tessDataPath);

            // Idioma de OCR (puede ser "eng" o "spa")
            string ocrLang = "spa";

            Console.WriteLine("Carpeta de entrada: " + inputPath);
            Console.WriteLine("Carpeta de salida: " + outputPath);
            Console.WriteLine("Carpeta tessdata: " + tessDataPath);
            Console.WriteLine("Idioma OCR: " + ocrLang);

            try
            {
                // Crear servicio OCR
                ServicesOCR ocrService = new ServicesOCR(inputPath, outputPath, tessDataPath, ocrLang);

                // Procesar todas las imágenes en la carpeta input
                ocrService.ProcessAllImages();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el proceso OCR: " + ex.Message);
            }

            Console.WriteLine("OCR FINALIZADO");
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}

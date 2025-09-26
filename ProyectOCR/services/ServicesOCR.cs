using System;
using System.IO;
using System.Linq;

namespace ProyectOCR.services
{
    public class ServicesOCR
    {
        private readonly string _inputPath;
        private readonly string _outputPath;
        private readonly ExtractorDataOCR _extractor;

        public ServicesOCR(string inputPath, string outputPath, string tessDataPath, string ocrLang)
        {
            _inputPath = inputPath;
            _outputPath = outputPath;
            _extractor = new ExtractorDataOCR(tessDataPath, ocrLang);
        }

        public void ProcessAllImages()
        {
            // Buscar todas las imágenes guardadas en la carpeta input
            string[] imageFiles = Directory.GetFiles(_inputPath, "*.*")
                                           .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                                    || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                                                    || f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                                           .ToArray();

            if (imageFiles.Length == 0)
            {
                Console.WriteLine("No se encontraron imágenes en la carpeta input.");
                return;
            }

            foreach (var imagePath in imageFiles)
            {
                Console.WriteLine("Procesando: " + Path.GetFileName(imagePath));

                string text = _extractor.ExtractText(imagePath);

                // Crear archivo de salida con el mismo nombre que la imagen
                string outputFile = Path.Combine(_outputPath, Path.GetFileNameWithoutExtension(imagePath) + ".txt");
                File.WriteAllText(outputFile, text);

                Console.WriteLine("Texto extraído guardado en: " + outputFile);
            }
        }
    }
}

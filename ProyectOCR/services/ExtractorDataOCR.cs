using System;
using Tesseract;

namespace ProyectOCR.services
{
    public class ExtractorDataOCR
    {
        private readonly string _tessDataPath;
        private readonly string _ocrLang;

        public ExtractorDataOCR(string tessDataPath, string ocrLang)
        {
            _tessDataPath = tessDataPath;
            _ocrLang = ocrLang;
        }

        public string ExtractText(string imagePath)
        {
            try
            {
                // Inicia el motor OCR con la carpeta tessdata y el idioma
                using (var engine = new TesseractEngine(_tessDataPath, _ocrLang, EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            string text = page.GetText();
                            float confidence = page.GetMeanConfidence();

                            Console.WriteLine($"OCR completado para: {imagePath}");
                            Console.WriteLine($"Precisión estimada: {confidence:P}");

                            return text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en OCR: " + ex.Message);
                return string.Empty;
            }
        }
    }
}

# ProyectOCR

**ProyectOCR** es una aplicación de consola desarrollada en C# (.NET Framework 4.7.2) que permite realizar el reconocimiento óptico de caracteres (OCR) sobre imágenes en formato PNG u otros... Utiliza la librería Tesseract para extraer texto de imágenes y guardar los resultados en archivos de texto y/o CSV.

## Características

- Procesa automáticamente todas las imágenes PNG ubicadas en la carpeta `input`.
- Utiliza Tesseract OCR, permitiendo seleccionar el idioma de reconocimiento (por defecto español: `spa` o ingles `eng`).
- Guarda los resultados en la carpeta `output`.
- Estructura de carpetas automática: crea las carpetas necesarias si no existen.
- Manejo de errores y mensajes informativos en consola.
- Fácil de extender para otros formatos de imagen o idiomas.

## Estructura de Carpetas

Al ejecutar el programa, se crean las siguientes carpetas en el directorio base del proyecto:

- `input`: Coloca aquí las imágenes PNG que deseas procesar.
- `output`: Aquí se guardarán los resultados del OCR.
- `tessdata`: Carpeta donde deben estar los archivos de datos de idioma de Tesseract (por ejemplo, `spa.traineddata` para español).

## Instalación

1. **Clona el repositorio:** git clone https://github.com/CarlosGomez29/ProyectOCR.git

2. **Abre el proyecto en Visual Studio 2022.**

3. **Restaura los paquetes NuGet necesarios:**
- Asegúrate de tener instalada la librería Tesseract (puedes buscar `Tesseract` en NuGet).
- Si usas otro servicio OCR, revisa la documentación correspondiente.

4. **Descarga los archivos de idioma para Tesseract:**
- Ve a [tesseract-ocr/tessdata](https://github.com/tesseract-ocr/tessdata).
- Descarga el archivo de idioma que necesites (por ejemplo, `spa.traineddata` para español).
- Colócalo en la carpeta `tessdata` dentro del directorio base del proyecto.

## Uso

1. **Coloca las imágenes PNG que deseas procesar en la carpeta `input`.**

2. **Ejecuta el programa:**
- Desde Visual Studio, presiona F5 o ejecuta el proyecto.
- Desde consola, navega al directorio del ejecutable y ejecuta el archivo `.exe`.

3. **Resultados:**
- El texto extraído de cada imagen se guardará en la carpeta `output`.
- Los mensajes de progreso y posibles errores se mostrarán en la consola.


## Personalización

- **Idioma OCR:** Puedes cambiar el idioma modificando la variable `ocrLang` en `Program.cs` (por ejemplo, `"eng"` para inglés).
- **Formatos de imagen:** Actualmente procesa archivos `.png`, pero puedes modificar el filtro en el método `ProcessAllImages()` para aceptar otros formatos.
- **Extensión:** Puedes adaptar el servicio para extraer datos específicos y guardarlos en otros formatos (CSV, JSON, etc.).

## Requisitos

- Windows 10/11
- .NET Framework 4.7.2
- Visual Studio 2022
- Paquete NuGet: Tesseract (o el que uses para OCR)
- Archivos de idioma de Tesseract en la carpeta `tessdata`

## Estructura del Código

- `Program.cs`: Punto de entrada principal. Configura rutas, idioma y ejecuta el servicio OCR.
- `services/ServicesOCR.cs`: Lógica para procesar imágenes y extraer texto usando Tesseract.
- Otros archivos y clases pueden estar presentes para la extracción de datos, manejo de resultados, etc.

---

**Autor:** Carlos Gómez  
**Repositorio:** [ProyectOCR](https://github.com/CarlosGomez29/ProyectOCR)

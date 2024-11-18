
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Drawing;
//Mainly targeting Windows
using System.IO;
using System.Linq;
using ZXing;
using PdfiumViewer;
using PDFiumSharp;
using ZXing.QrCode;
using OpenCvSharp;
using ZXing.Rendering;

namespace QRCodeSquad1
{
    public static class QRService1
    {

        public static List<string> QRDecodePDF1(string filePath)// This method accepts only one PDF file
        {

            byte[] bytes = File.ReadAllBytes(filePath);
            // Load the PDF document and get its pages
            var pages = new PDFiumSharp.PdfDocument(bytes).Pages;
            List<string> results = new List<string>();

            foreach (var page in pages)
            {
                // Render the PDF page into a bitmap image
                //when it was ((int)page.Width * 4, (int)page.Height * 4, false)), the result could not be recognized
                using (var bmp = new PDFiumSharp.PDFiumBitmap((int)page.Width * 4, (int)page.Height * 4, false))
                {
                    page.Render(bmp);

                    // Save the rendered page as a PNG file for debugging purposes
                    using (var fs = new FileStream($"RenderedPage_{page.Index}.png", FileMode.Create))
                    {
                        bmp.Save(fs);
                        FileInfo fileInfo = new FileInfo($"RenderedPage_{page.Index}.png");
                        Console.WriteLine($"File Size: {fileInfo.Length} bytes");
                    }
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms);
                    // Use ImageSharp to load the image from the MemoryStream
                    ms.Position = 0;
                    using (var image = SixLabors.ImageSharp.Image.Load<Rgb24>(ms))
                    {
                        // Attempt to decode the QR code from the image
                        // Try decoding QR code from each page
                        var res = QRDecode1(image);
                        // Add the decoded result to the `res` list
                        if (res != null)
                        {
                            results.AddRange(res);
                        }
                    }
                }
            }
            return results;
        }

        // Decode the QR code from an ImageSharp image
        public static List<string> QRDecode1(Image<Rgb24> image)
        //Image<Rgba32> doesn't work, cause qrcode doesn't read image with alpha
        {

            List<string> res = new List<string>();

            Console.WriteLine($"width: {image.Width}, height: {image.Height}");

            // Convert the image to grayscale
            image.Mutate(x => x.Grayscale());
            Console.WriteLine("Gray done");
            // Increase the contrast of the image
            image.Mutate(x => x.Contrast(1.5f));

            var graypixelData = new byte[image.Width * image.Height * 3];
            image.CopyPixelDataTo(graypixelData);


            //to check the number of non-white pixels for debug
            int nonWhitePixelCount = 0;
            for (int i = 0; i < graypixelData.Length; i += 3) // Each pixel has 3 bytes
            {
                byte red = graypixelData[i];
                byte green = graypixelData[i + 1];
                byte blue = graypixelData[i + 2];

                // Check if the pixel is not completely white (255, 255, 255)
                if (red != 255 || green != 255 || blue != 255)
                {
                    nonWhitePixelCount++;
                }
            }
            Console.WriteLine($"Number of non-white pixels: {nonWhitePixelCount}");


            // Print first 10 values for debug
            for (int i = 0; i < 10; i++)  
            {
                Console.WriteLine($"Pixel {i}: {graypixelData[i]}");
            }

            // Set up the QR code reader
            var reader = new BarcodeReaderGeneric
            {
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true,
                    PureBarcode = false
                }
            };

            // Convert image data to a grayscale image that ZXing can process
            var luminanceSource = new RGBLuminanceSource(graypixelData, image.Width, image.Height);
            Console.WriteLine($"LuminanceSource width: {luminanceSource.Width}, height: {luminanceSource.Height}");
            var results = reader.DecodeMultiple(luminanceSource);

            if (results != null)
            {
                res.AddRange(results.Select(r => r.Text));
                Console.WriteLine($"results: {results}");
            }
            else
            { Console.WriteLine("Results: No results found"); }

            return res;
        }

    }
}

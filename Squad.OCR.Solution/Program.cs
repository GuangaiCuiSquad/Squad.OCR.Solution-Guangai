// See https://aka.ms/new-console-template for more information
using QRCodeSquad1;
using SixLabors.ImageSharp.PixelFormats;
using Squad.OCR.Solution;
using SixLabors.ImageSharp;
using System.Drawing;
using OpenCvSharp;



class Program
{
    static void Main()
    {

        Console.WriteLine("A ler...");
        new OCR().ReadQR_PDF();

        Console.WriteLine("Lido!");
        Console.ReadLine();
        //TestQRDecode1();
    }
    //to test QRDecode1() function in QRCodeSquad1 of MyCode.cs file
    static void TestQRDecode1()
    {
        Console.WriteLine("reading...");

        string imagePath = "C:\\Users\\GuangaiCui\\Downloads\\Squad.OCR.Solution Guangai\\toread\\QR.png";//valid QRcode.png
        string imagePath1 = "C:\\Users\\GuangaiCui\\Downloads\\Squad.OCR.Solution Guangai\\toread\\QR1.png"; //not valid QRcode
        string imagePath2 = "C:\\Users\\GuangaiCui\\Downloads\\Squad.OCR.Solution Guangai\\toread\\QR2.png";//valid QRcode.png
        string imagePath3 = "C:\\Users\\GuangaiCui\\Downloads\\Squad.OCR.Solution Guangai\\toread\\QR3.png";//valid QRcode.png
        string Capture = "C:\\Users\\GuangaiCui\\Downloads\\Squad.OCR.Solution Guangai\\toread\\Capture.png";//valid capture of a invoice.png
        string jpg = "C:\\Users\\GuangaiCui\\Downloads\\Squad.OCR.Solution Guangai\\toread\\jpg.JPG";//valid capture of a invoice.jpg

        using (var image = SixLabors.ImageSharp.Image.Load<Rgb24>(jpg))
        {
            var qrCodes = QRService1.QRDecode1(image);

            //check and print content of qrCode
            if (qrCodes != null && qrCodes.Count > 0)
            {
                Console.WriteLine("content:");
                foreach (var code in qrCodes)
                {
                    Console.WriteLine(code);
                }
            }
        }

        Console.WriteLine("finish");
        Console.ReadLine();
    }

}

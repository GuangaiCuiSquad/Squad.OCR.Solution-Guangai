using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using QRCodeSquad1;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;

namespace Squad.OCR.Solution
{
    internal class OCR
    //定义了名为OCR的类，用于从指定文件夹中的pdf文件读取二维码信息，并将解析的数据写入csv文件
    {
        //设置了存储待处理pdf文件的文件夹
        
        public string ocrFolder = "C:\\Users\\GuangaiCui\\Downloads\\Squad.OCR.Solution Guangai\\toread";  // Folder with PDFs to process
        public string failedFolder = "C:\\Users\\GuangaiCui\\Downloads\\Squad.OCR.Solution Guangai\\Failed_Files";  // Folder for failed files
        public string processedFolder = "C:\\Users\\GuangaiCui\\Downloads\\Squad.OCR.Solution Guangai\\Processed_Files";  // Folder for successfully processed files
        public string outputCsvPath = "C:\\Users\\GuangaiCui\\Downloads\\Squad.OCR.Solution Guangai\\dados.csv";// Output CSV file


        public void ReadQR_PDF()
        //该方法负责读取 PDF 文件中的二维码，解析并处理数据，然后将信息保存到 CSV 文件中。
        {
            string[] files = Directory.GetFiles(ocrFolder,"*.pdf");

            Console.WriteLine($"No. of files: {files.Length}");
            //使用 Directory.GetFiles() 方法获取 ocrFolder 文件夹中的所有文件路径（假设文件夹中仅存放 PDF 文件）。

            // Configuração para o CsvHelper (opcional)
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",", // Define o delimitador como vírgula
                HasHeaderRecord = false // Indica que não há cabeçalho
            };
            //配置 CsvHelper 用于 CSV 写入，设置分隔符为逗号，并指明文件中没有标题行

            // Create a CSV writer for output
            //if (!Directory.Exists(Path.GetDirectoryName(outputCsvPath)))
            //{
            //    Directory.CreateDirectory(Path.GetDirectoryName(outputCsvPath));
            //    Console.WriteLine("Created the output CSV directory.");
            //}
            using (var writer = new StreamWriter(outputCsvPath, true))  // Open in append mode to add rows
            using (var csv = new CsvWriter(writer, config))

                foreach (var file in files)
                {

                    //byte[] fileBytes = File.ReadAllBytes(file);
                    var resultFromPdf = QRService1.QRDecodePDF1(file);
                    //var resultFromPdf = BarcodeReader.ReadPdf(file); // From PDF use ReadPdf
                    Console.WriteLine($"No. of qrCodes:{resultFromPdf.Count}");                                //遍历文件夹中的每个文件。
                                                                                    //对于每个文件，使用 BarcodeReader.ReadPdf(file) 方法来读取其中的二维码信息，结果保存在 resultFromPdf 中。
                    bool fileProcessed = false;

                    foreach (var qrCode in resultFromPdf)
                    {
                        if (!string.IsNullOrEmpty(qrCode))
                        {
                            string[] fields = qrCode.Split('*');
                            //遍历 resultFromPdf 中的每个二维码信息，检查 j.Text 是否为空。
                            //若不为空，则将二维码内容按 '*' 分割成多个字段，保存在 fields 数组中

                            // Dicionário para armazenar os dados
                            Dictionary<string, string> dadosDoQRCode = new Dictionary<string, string>();
                            QrCodeInfo qrCodeDataObj = new QrCodeInfo();
                            //创建一个字典 dadosDoQRCode 存储二维码的键值对。
                            //初始化一个 QrCodeInfo 对象 qrCodeDataObj，用于保存解析后的数据。

                            //Processa cada campo
                            foreach (string field in fields)
                            {
                                string[] partes = field.Split(':');
                                if (partes.Length == 2)
                                {
                                    dadosDoQRCode[partes[0]] = partes[1];
                                    //遍历 fields 数组中的每个字段，将其按 ':' 分割成键值对。
                                    //将键值对存入字典 dadosDoQRCode 中

                                    switch (partes[0])
                                    {
                                        case "A": qrCodeDataObj.A = partes[1]; break;
                                        case "B": qrCodeDataObj.B = partes[1]; break;
                                        case "C": qrCodeDataObj.C = partes[1]; break;
                                        case "D": qrCodeDataObj.D = partes[1]; break;
                                        case "E": qrCodeDataObj.E = partes[1]; break;
                                        case "F": qrCodeDataObj.F = partes[1]; break;
                                        case "G": qrCodeDataObj.G = partes[1]; break;
                                        case "H": qrCodeDataObj.H = partes[1]; break;
                                        case "I1": qrCodeDataObj.I1 = partes[1]; break;
                                        case "I2": qrCodeDataObj.I2 = partes[1]; break;
                                        case "I3": qrCodeDataObj.I3 = partes[1]; break;
                                        case "I4": qrCodeDataObj.I4 = partes[1]; break;
                                        case "I5": qrCodeDataObj.I5 = partes[1]; break;
                                        case "I6": qrCodeDataObj.I6 = partes[1]; break;
                                        case "I7": qrCodeDataObj.I7 = partes[1]; break;
                                        case "I8": qrCodeDataObj.I8 = partes[1]; break;
                                        case "I9": qrCodeDataObj.I9 = partes[1]; break;
                                        case "I10": qrCodeDataObj.I10 = partes[1]; break;
                                        case "I11": qrCodeDataObj.I11 = partes[1]; break;
                                        case "I12": qrCodeDataObj.I12 = partes[1]; break;
                                        case "J1": qrCodeDataObj.J1 = partes[1]; break;
                                        case "J2": qrCodeDataObj.J2 = partes[1]; break;
                                        case "J3": qrCodeDataObj.J3 = partes[1]; break;
                                        case "J4": qrCodeDataObj.J4 = partes[1]; break;
                                        case "J5": qrCodeDataObj.J5 = partes[1]; break;
                                        case "J6": qrCodeDataObj.J6 = partes[1]; break;
                                        case "J7": qrCodeDataObj.J7 = partes[1]; break;
                                        case "J8": qrCodeDataObj.J8 = partes[1]; break;
                                        case "K1": qrCodeDataObj.K1 = partes[1]; break;
                                        case "K2": qrCodeDataObj.K2 = partes[1]; break;
                                        case "K3": qrCodeDataObj.K3 = partes[1]; break;
                                        case "K4": qrCodeDataObj.K4 = partes[1]; break;
                                        case "K5": qrCodeDataObj.K5 = partes[1]; break;
                                        case "K6": qrCodeDataObj.K6 = partes[1]; break;
                                        case "K7": qrCodeDataObj.K7 = partes[1]; break;
                                        case "K8": qrCodeDataObj.K8 = partes[1]; break;
                                        case "L": qrCodeDataObj.L = partes[1]; break;
                                        case "M": qrCodeDataObj.M = partes[1]; break;
                                        case "N": qrCodeDataObj.N = partes[1]; break;
                                        case "O": qrCodeDataObj.O = partes[1]; break;
                                        case "P": qrCodeDataObj.P = partes[1]; break;
                                        case "Q": qrCodeDataObj.Q = partes[1]; break;
                                        case "R": qrCodeDataObj.R = partes[1]; break;
                                        case "S": qrCodeDataObj.S = partes[1]; break;
                                    }
                                }
                            }
                            //将解析的数据填充到 QrCodeInfo 对象
                            //使用 switch 语句，将每个字段的值赋给 qrCodeDataObj 对象对应的属性（如 qrCodeDataObj.A、qrCodeDataObj.B 等）。

                            //Coloca os dados no excel.
                            // Cria um escritor CSV
                            //using (var writer = new StreamWriter("dados.csv"))
                            //using (var csv = new CsvWriter(writer, config))
                            {
                                // Escreve cada propriedade do objeto QrCodeData como uma coluna
                                csv.WriteField(qrCodeDataObj.A);
                                csv.WriteField(qrCodeDataObj.B);
                                csv.WriteField(qrCodeDataObj.C);
                                csv.WriteField(qrCodeDataObj.D);
                                csv.WriteField(qrCodeDataObj.E);
                                csv.WriteField(qrCodeDataObj.F);
                                csv.WriteField(qrCodeDataObj.G);
                                csv.WriteField(qrCodeDataObj.H);
                                csv.WriteField(qrCodeDataObj.I1);
                                csv.WriteField(qrCodeDataObj.I2);
                                csv.WriteField(qrCodeDataObj.I3);
                                csv.WriteField(qrCodeDataObj.I4);
                                csv.WriteField(qrCodeDataObj.I5);
                                csv.WriteField(qrCodeDataObj.I6);
                                csv.WriteField(qrCodeDataObj.I7);
                                csv.WriteField(qrCodeDataObj.I8);
                                csv.WriteField(qrCodeDataObj.I9);
                                csv.WriteField(qrCodeDataObj.I10);
                                csv.WriteField(qrCodeDataObj.I11);
                                csv.WriteField(qrCodeDataObj.I12);
                                csv.WriteField(qrCodeDataObj.J1);
                                csv.WriteField(qrCodeDataObj.J2);
                                csv.WriteField(qrCodeDataObj.J3);
                                csv.WriteField(qrCodeDataObj.J4);
                                csv.WriteField(qrCodeDataObj.J5);
                                csv.WriteField(qrCodeDataObj.J6);
                                csv.WriteField(qrCodeDataObj.J7);
                                csv.WriteField(qrCodeDataObj.J8);
                                csv.WriteField(qrCodeDataObj.K1);
                                csv.WriteField(qrCodeDataObj.K2);
                                csv.WriteField(qrCodeDataObj.K3);
                                csv.WriteField(qrCodeDataObj.K4);
                                csv.WriteField(qrCodeDataObj.K5);
                                csv.WriteField(qrCodeDataObj.K6);
                                csv.WriteField(qrCodeDataObj.K7);
                                csv.WriteField(qrCodeDataObj.K8);
                                csv.WriteField(qrCodeDataObj.L);
                                csv.WriteField(qrCodeDataObj.M);
                                csv.WriteField(qrCodeDataObj.N);
                                csv.WriteField(qrCodeDataObj.O);
                                csv.WriteField(qrCodeDataObj.P);
                                csv.WriteField(qrCodeDataObj.Q);
                                csv.WriteField(qrCodeDataObj.R);
                                csv.WriteField(qrCodeDataObj.S);

                                // Conclui a linha
                                csv.NextRecord();
                                Console.WriteLine(qrCodeDataObj.A);
                                fileProcessed = true;
                                //break;
                                //如果只要一个有效的二维码的话，需要break

                            }

                            //使用 StreamWriter 创建一个名为 dados.csv 的文件。
                            //用 CsvWriter 逐字段写入 qrCodeDataObj 中的各属性，分别对应 CSV 文件中的一列。
                            //最后用 csv.NextRecord() 结束该行记录。
                            //Manda o documento para a pasta certa.
                        }
                        
                    }
                    string currentDate = DateTime.Now.ToString("yyyyMMdd");
                    if (fileProcessed)
                    {
                        string? processedPath = Path.Combine(processedFolder, currentDate, Path.GetFileName(file));
                        if (!Directory.Exists(processedFolder))
                        {
                            //Directory.CreateDirectory(Path.GetDirectoryName(processedPath));
                            Directory.CreateDirectory(processedFolder);
                            Console.WriteLine("Created the 'processedPath' folder.");
                        }
                        //Directory.CreateDirectory(Path.GetDirectoryName(processedPath));
                        Directory.CreateDirectory(Path.GetDirectoryName(processedPath) ?? string.Empty);
                        File.Move(file, processedPath);
                        Console.WriteLine($"Moved the {file} to Processed folder.");
                    }
                    else
                    {
                        string failedPath = Path.Combine(failedFolder, currentDate, Path.GetFileName(file));
                        if (!Directory.Exists(failedFolder))
                        {
                            Directory.CreateDirectory(failedFolder);
                            Console.WriteLine("Created the 'failed Path' folder.");
                        }
                        //Directory.CreateDirectory(Path.GetDirectoryName(failedPath));
                        Directory.CreateDirectory(Path.GetDirectoryName(failedPath) ?? string.Empty);
                        File.Move(file, failedPath);
                        Console.WriteLine($"Moved the {file} to Failed folder.");
                    }

                }
        }
    }
}

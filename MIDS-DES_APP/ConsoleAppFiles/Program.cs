using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"C:\Julio\Maestría CPDS\2do Semestre\MIDS105 DESARROLLO DE APLICACIONES Y XAMARIN\";
            //string path = @"C:\Julio\Maestría CPDS\2do Semestre\MIDS105 DESARROLLO DE APLICACIONES Y XAMARIN\test";
            //Writefile();
            //ReadFile();
            //ValidateDirectoryExists(path);
            //AppenText();
            GetInfo();
            Console.WriteLine("Transacción finalizada");
            Console.ReadKey();
        }

        private static void GetInfo()
        {
            string filePath = @"C:\Julio\Maestría CPDS\2do Semestre\MIDS105 DESARROLLO DE APLICACIONES Y XAMARIN\Testfile.txt";
            Console.WriteLine($"El último acceso ala rchivo fue: {File.GetLastAccessTime(filePath)}");
            Console.WriteLine($"La última sobreecritura en el archivo fue: {File.GetLastWriteTime(filePath)}");            
                
            Console.WriteLine("Operación GetInfo finalizada...");
        }
        private static void AppenText()
        {
            string filePath = @"C:\Julio\Maestría CPDS\2do Semestre\MIDS105 DESARROLLO DE APLICACIONES Y XAMARIN\Testfile.txt";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.AppendLine($"Línea {i} agregada...");
            }
            File.AppendAllText(filePath, sb.ToString());
            Console.WriteLine("Operación AppenText finalizada correctamente");
        }
        private static void ValidateDirectoryExists(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine($"El directorio {path} si existe");
            }
            else
            {
                Console.WriteLine($"El directorio {path} no existe");
                Directory.CreateDirectory(path);
                Console.WriteLine($"El directorio {path} se creo correctamente");
            }
        }

        private static async void ReadFile()
        {
            try
            {
                string filePath = @"C:\Julio\Maestría CPDS\2do Semestre\MIDS105 DESARROLLO DE APLICACIONES Y XAMARIN\Testfile.txt";
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        var readerFile = await sr.ReadToEndAsync();

                        Console.WriteLine($"El contenido del archivo es \n{readerFile}");
                    }
                }
                else
                {
                    Console.WriteLine("el archivo no existe");
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async void Writefile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Julio\Maestría CPDS\2do Semestre\MIDS105 DESARROLLO DE APLICACIONES Y XAMARIN\Testfile.txt"))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        await sw.WriteLineAsync($"Esta es la linea {i}");
                    }

                    Console.WriteLine("Operación finalizada correctamente...");
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            //Longrunning();
            GetData();

            Console.WriteLine("Fin de la ejecución");
            Console.ReadKey();
        }

        private static async Task<string> GetData()
        {
            var result = await Task.Run<string>(() =>
            {
                Thread.Sleep(5000);
                return "Estos son los datos";
            });
            return result;
        }

        private static async void Longrunning()
        {
            Task<string> task = Task.Run<string>(() =>
            {
                Thread.Sleep(5000);
                return "La tarea ha finalizado";
            });

            string result =await task;
            Console.WriteLine(result);
        }
    }
}

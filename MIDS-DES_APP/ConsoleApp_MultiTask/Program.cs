using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_MultiTask
{
    class Program
    {
        private static string TheTime = $"La fecha actual es: {DateTime.Now:yyyy/MM/dd HH:mm:ss}";
        static void Main(string[] args)
        {
            Task task1 = new Task(new Action(GetTheTime));
            Task task2 = new Task(delegate
            {
                Console.WriteLine($"Task 2 - La fecha actual es: {DateTime.Now:yyyy/MM/dd HH:mm:ss}");
            });
            Task task3 = new Task(() =>
            {
                Console.WriteLine($"Task 3 - La fecha actual es: {DateTime.Now:yyyy/MM/dd HH:mm:ss}");
            });

            Task.Run(() =>
            {
                Console.WriteLine($"Task 4 - La fecha actual es: {DateTime.Now:yyyy/MM/dd HH:mm:ss}");
            });

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Task 5 - La fecha actual es: {DateTime.Now:yyyy/MM/dd HH:mm:ss}");
            });


            task1.Start();
            task2.Start();
            task3.Start();
            Console.WriteLine("Finalizo tareas");
            Console.WriteLine("Presiones una tecla...");
            Console.ReadKey();
            Console.Clear();

            Task longRunning = new Task(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine($"{i}");
                    Thread.Sleep(100);
                }
            });

            longRunning.Start();
            longRunning.Wait();

            Task[] tasks = new Task[3] {
            Task.Run(()=> LongRunning(1, 10)),
            Task.Run(()=> LongRunning(2,20)),
            Task.Run(()=> LongRunning(3,30))

            };
            //Task.WaitAny(tasks);
            Task.WaitAll(tasks);
            
            Console.WriteLine("Finalizo 2das Tareas");
            Console.ReadKey();

            Parallel.Invoke(() => LongRunning(1, 10),
                () => LongRunning(2, 100),
                () => LongRunning(3, 20),
                () => LongRunning(4, 300));

            Console.WriteLine("Finalizo 3das Tareas");
            
            Console.ReadKey();

        }

        private static void LongRunning(int nameTask, int sleep)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{i}- tarea:{nameTask}");
                Thread.Sleep(sleep);
            }
        }

        private static void GetTheTime()
        {
            Console.WriteLine($"Task 1 - La fecha actual es: {DateTime.Now:yyyy/MM/dd HH:mm:ss}");
        }
    }
}

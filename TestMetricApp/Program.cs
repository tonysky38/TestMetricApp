using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ConsoleTables;

namespace TestMetricApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.Start();
        }
    }

    public class Manager
    {
        List<Product> product = new List<Product>();
        ConsoleTable table = new ConsoleTable();

        public void Start()
        {
            string cmd = string.Empty;
            
            Console.WriteLine("Для получения справки введите 'help'\n");

            while (true)
            {
                Console.Write("> ");
                cmd = Console.ReadLine().ToUpper();

                if (cmd == "HELP")
                {
                    Console.WriteLine();
                    Console.WriteLine("new note     - Новая запись");
                    Console.WriteLine("print table  - Вывести таблицу");
                    Console.WriteLine("clear        - Очистить экран");
                    Console.WriteLine("exit         - Выход");
                    Console.WriteLine();
                }
                else if (cmd == "EXIT")
                {
                    Environment.Exit(0);
                    
                }
                else if (cmd == "NEW NOTE")
                {
                    InputData();
                }
                else if (cmd == "PRINT TABLE")
                {
                    WriteTable();
                }
                else if (cmd == "CLEAR")
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Неизвесная комманда");
                    Console.WriteLine();
                }
            }
        }

        private void InputData()
        {
            while (true)
            {
                Product new_note = new Product();

                Console.WriteLine();
                Console.Write("Название - ");
                new_note.Name = Console.ReadLine();
                Console.Write("Категория - ");
                new_note.Category = Console.ReadLine();
                Console.Write("Артикул - ");
                new_note.Article = Console.ReadLine();
                Console.Write("Цена - ");
                new_note.Price = Console.ReadLine();
                Console.WriteLine();

                product.Add(new_note);

                Console.WriteLine("Продолжить? (y/n)");
                Console.Write("> ");
                string isContinue = Console.ReadLine();

                if (isContinue == "n")
                {
                    EndInputData();
					break;
                }
                else if (isContinue != "y")
                {
                    Console.WriteLine("Ошибка ввода, выход в меню.");
                    break;
                }
            }
        }

        private void EndInputData()
        {
            Console.Clear();
            Start();
        }

        private void WriteTable()
        {
            ConsoleTable.From<Product>(product).Write();
        }
    }

    public class Something
    {
        public Something()
        {
            Id = Guid.NewGuid().ToString("N");
            Name = "Khalid Abuhkameh";
            Date = DateTime.Now;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfChildren { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Article { get; set; }
        public string Price { get; set; }
    }
}

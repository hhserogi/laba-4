using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using static AnimalLogger;

namespace laba
{
   
    class Program
    {
        public static void Main()
        {
            bool flag = true;
            Console.WriteLine($"Добро пожаловать в журнал домашнего животного!");
            List<AnimalLogger> listLoggers = new List<AnimalLogger>();

            Console.WriteLine($"Введите количество животных:");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.WriteLine("Неверный ввод!");
            }
            for (int i = 0; i <= count-1; i++)
            {
                Console.WriteLine($"Введите имя {i+1}го животного:");
                string input = Console.ReadLine().Trim();
                AnimalLogger animalLogger = new AnimalLogger(input);
                listLoggers.Add( animalLogger );
            }
            while (flag)
            {
                Console.WriteLine($"\nВведите имя журнала животного");
                string name = Console.ReadLine().Trim();
                
                    for (int i = 0; i < listLoggers.Count; i++)
                    {
                        if (listLoggers[i].Name == name)
                        {
                            listLoggers[i].PrintNapomin();
                            Console.WriteLine($"Введите команду:\n [покормить] [погулять] [поход к ветеринару]\n" +
                                $"[история] [напоминание]");
                            string input = Console.ReadLine();
                            switch (input)
                            {
                                case "погулять":
                                    Console.WriteLine("Введите комментарий:");
                                    string comm = Console.ReadLine();
                                    listLoggers[i].Walk(comm);
                                    break;
                                case "покормить":
                                    Console.WriteLine("Введите комментарий:");
                                    comm = Console.ReadLine();
                                    listLoggers[i].Eat(comm);
                                    break;
                                case "поход к ветеринару":
                                    Console.WriteLine("Введите комментарий:");
                                    comm = Console.ReadLine();
                                    listLoggers[i].Health(comm);
                                    break;
                                case "история":
                                    listLoggers[i].History();
                                    Console.WriteLine($"Команды: " +
                                        $"[фильтр] [выйти] [удалить]");
                                    switch (Console.ReadLine())
                                    {
                                        case "фильтр":
                                            Console.WriteLine($"Введите категорию: [прогулен] [покормлен] [сходил к ветеринару]");
                                            string filtr = Console.ReadLine();
                                            listLoggers[i].History(filtr);
                                            break;
                                        case "выйти":
                                            break;
                                        case "удалить":
                                            Console.WriteLine("Введите номер удаляемой строки:");
                                            int del = Convert.ToInt32(Console.ReadLine());
                                            listLoggers[i].DeleteStroke(del);
                                            Console.WriteLine($"Строка {del} удалена");
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "напоминание":
                                    Console.WriteLine("Введите напоминание:");
                                    string nap = Console.ReadLine();
                                    Console.WriteLine("Введите дату(день.месяц.год час:минута:секунда):");
                                DateTime time;
                                if (!DateTime.TryParse(Console.ReadLine(), out time))
                                {
                                    Console.WriteLine("Неверный формат даты!");
                                    break;
                                }
                                    listLoggers[i].SetNapomin(nap, time);
                                    break;
                                default:
                                    break;
                            }
                        }

                    }
                }
                
            }
        }
    }


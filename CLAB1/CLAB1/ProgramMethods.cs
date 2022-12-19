using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAB1
{
    partial class Program
    {
        public static bool IsNumber(string str)
        {
            if (!str.All(char.IsNumber))
            {
                Console.WriteLine("\nВвод символов или букв запрещён!");
                return false;
            }
            else
                return true;
        }

        public static void PickTarif(ref MobileOperator moboperator)
        {
            Console.WriteLine("\nВведите новый тариф в виде цифры:");
            int tarifnumber = 0;
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine(i + ". " + (Title)i);
            }
            try
            {
                tarifnumber = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка!");
            }
            switch (tarifnumber)
            {
                case 1:
                    {
                        NewTarif(ref moboperator, Title.Birthday);
                        break;
                    }
                case 2:
                    {
                        NewTarif(ref moboperator, Title.Love);
                        break;
                    }
                case 3:
                    {
                        NewTarif(ref moboperator, Title.PlusThree);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ошибка");
                        break;
                    }
            }
        }

        public static void NewTarif(ref MobileOperator moboperator, Title title)
        {
            moboperator.title = Convert.ToString(title);
            Console.WriteLine("Ваш новый тариф: " + moboperator.title + "\n");
        }

        public static void PickCallNumber(ref MobileOperator moboperator)
        {
            string call_number;
            Console.WriteLine("Введите номер телефона, на который будем звонить: ");
            call_number = Console.ReadLine();
            if (string.IsNullOrEmpty(call_number) || string.IsNullOrWhiteSpace(call_number))
            {
                Console.WriteLine("Внимание: номер телефона не может быть пустым или хранить в себе пробелы.\n");
            }
            if (call_number.Length != 10)
            {
                Console.WriteLine("Внимание: номер должен состоять из 10 цифр.\n");
            }
            else if (IsNumber(call_number))
                {
                    int minutes = 0;
                    Console.WriteLine("Введите количество минут, на протяжении которых будет длится звонок:");
                    try
                    {
                        minutes = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка!\n");
                    }
                moboperator.balance -= MakeACall(moboperator, minutes, call_number);
                }
                
        }


        public static double MakeACall(MobileOperator moboperator, int minutes, string phonenumber)
        {
            double sum = 0;
            sum = minutes * moboperator.cost;
            if (moboperator.balance >= sum)
            {
                Console.WriteLine("\nЗвоним на номер " + phonenumber + "...");
                Console.WriteLine("Звонок завершён! Длительность звонка: " + minutes + "!");
                Console.WriteLine("Стоимость звонка: " + sum + "!\n");
                for (int i = moboperator.history.Length - 1; i < moboperator.history.Length; i++)
                {
                    moboperator.history[i] += "номер: " + phonenumber + " | длительность звонка: " + minutes;
                }
                Array.Resize(ref moboperator.history, moboperator.history.Length + 1);
                return sum;
            }
            else
                Console.WriteLine("Недостаточного средств для звонка!\n");
                return 0;
        }

        public static void AddBalance(ref MobileOperator moboperator)
        {
            double sum = 0;
            Console.WriteLine("Введите сумму, на которую хотите пополнить баланс: ");
            try
            {
                sum = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка!");
            }
            if (sum < 0)
            {
                Console.WriteLine("\nВнимание: сумма не может быть меньше нуля!");
                return;
            }
            moboperator.balance += sum;
            Console.WriteLine("Ваш текущий баланс: " + moboperator.balance);
        }

        public static void GetHistory(ref MobileOperator moboperator)
        {
            for (int i = 0; i < moboperator.history.Length - 1; i++)
            {
                Console.WriteLine(i + 1 + " звонок: " + moboperator.history[i]);
            }
        }

        public static void AddService(ref MobileOperator.Services[] mobservices, ref MobileOperator.Services[] availableservices, ref MobileOperator moboperator)
        {
            Console.WriteLine("\nВаши подключенные услуги:");
            for (int i = 0; i < mobservices.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + mobservices[i].service_title + ", цена: " + mobservices[i].service_cost);
            }
            Console.WriteLine("Выберите действие: \n1. Подключить новую услугу \n2. Отключить подключенную услугу");
            int service_choose = 0;
            try
            {
                service_choose = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка!");
            }
            switch (service_choose)
            {
                case 1:
                    {
                        Console.WriteLine("\nДоступные услуги: ");
                        for (int i = 0; i < availableservices.Length; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + availableservices[i].service_title + ", цена: " + availableservices[i].service_cost);
                        }
                        Console.WriteLine("Введите номер услуги, которую хотите подключить: ");
                        int number = 0;
                        try
                        {
                            number = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка!");
                        }
                        for (int i = 0; i < availableservices.Length; i++)
                        {
                            if (number - 1 == i)
                            {
                                double cont = moboperator.balance;
                                if (cont - availableservices[i].service_cost < 0)
                                {
                                    Console.WriteLine("Недостаточно средств для подключения услуги!");
                                    return;
                                }
                                
                                for (int m = 0; m < mobservices.Length; m++)
                                {
                                    if (mobservices[m].service_title == availableservices[i].service_title)
                                    {
                                        Console.WriteLine("У вас уже подключена данная услуга!");
                                        return;
                                    }
                                }

                                MobileOperator.Services[] newservices = new MobileOperator.Services[mobservices.Length + 1];
                                newservices[mobservices.Length] = new MobileOperator.Services
                                {
                                    service_title = availableservices[i].service_title,
                                    service_cost = availableservices[i].service_cost
                                };
                                
                                for (int k = 0; k < mobservices.Length; k++)
                                    newservices[k] = mobservices[k];

                                for (int j = mobservices.Length; j < mobservices.Length; j++)
                                    newservices[j] = mobservices[j];

                                mobservices = newservices;
                                moboperator.balance -= availableservices[i].service_cost;
                                Console.WriteLine("Услуга добавлена!");
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("\nВведите номер услуги, которую хотите отключить:");
                        int delnumber = 0;
                        try
                        {
                            delnumber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка!");
                        }
                        for (int i = 0; i < mobservices.Length; i++)
                        {
                            if (delnumber - 1 == i)
                            {
                                MobileOperator.Services[] newservices = new MobileOperator.Services[mobservices.Length - 1];

                                for (int k = 0; k < mobservices.Length - 1; k++)
                                    newservices[k] = mobservices[k];

                                for (int j = delnumber; j < mobservices.Length; j++)
                                    newservices[j - 1] = mobservices[j];

                                mobservices = newservices;
                                Console.WriteLine("Услуга отключена!");
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}

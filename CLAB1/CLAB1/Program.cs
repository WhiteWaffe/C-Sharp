namespace CLAB1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            MobileOperator moboperator = new MobileOperator(title: Convert.ToString(Title.Birthday), "1023456789", 3, 6000);
            moboperator.history = new string[1];
            MobileOperator.Services[] mobservices =
            {
                new MobileOperator.Services(Service.Internet, 200),
                new MobileOperator.Services(Service.TV, 150),
                new MobileOperator.Services(Service.Free_Traffic, 500)
            };

            MobileOperator.Services[] availableservices =
            {
                new MobileOperator.Services(Service.Internet, 200),
                new MobileOperator.Services(Service.TV, 150),
                new MobileOperator.Services(Service.Connection, 500),
                new MobileOperator.Services(Service.Free_Traffic, 500),
                new MobileOperator.Services(Service.Roaming, 800),
                new MobileOperator.Services(Service.Free_Apps, 1000),
            };

            string str;
            int number = 0;
            bool flag;
            do
            {
                for (int i = 1; i < 4; i++)
                {
                    Console.WriteLine(i + ". " + (Title)i);
                }
                Console.WriteLine("\nВведите название тарифа в виде цифры: ");
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка!");
                }
                switch (number)
                {
                    case 1:
                        {
                            flag = true;
                            moboperator.title = Convert.ToString(Title.Birthday);
                            break;
                        }
                    case 2:
                        {
                            flag = true;
                            moboperator.title = Convert.ToString(Title.Love);
                            break;
                        }
                    case 3:
                        {
                            flag = true;
                            moboperator.title = Convert.ToString(Title.PlusThree);
                            break;
                        }
                    default:
                        {
                            flag = false;
                            Console.WriteLine("Ошибка");
                            break;
                        }
                }    
            } while (flag != true);

            do
            {
                Console.WriteLine("Введите номер телефона: ");
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Внимание: номер телефона не может быть пустым или хранить в себе пробелы.");
                    flag = false;
                }
                if (str.Length != 10)
                {
                    Console.WriteLine("Внимание: номер должен состоять из 10 цифр.");
                    flag = false;
                }
                else
                {
                    flag = IsNumber(str);
                    if (flag)
                    {
                        moboperator.number = str;
                    }
                }
            } while (flag != true);

            do
            {
                Console.WriteLine("\nНазвание тарифа: " + moboperator.title + "\nСтоимось минуты разговора: " + moboperator.cost + "\nTекущий баланс: " + moboperator.balance + "\nНомер телефона: " + moboperator.number);
                Console.WriteLine("Введите номер действия: \n1. Перейти на новый тариф   2. Совершить звонок \n3. Подключить/отключить услуги   4. Пополнить баланс \n5. Получить историю звонков   6. Выход");
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка!");
                }
                switch (number)
                {
                    case 1:
                        {
                            
                            PickTarif(ref moboperator);
                            break;
                        }
                    case 2:
                        {
                            PickCallNumber(ref moboperator);
                            break;
                        }
                    case 3:
                        {
                            AddService(ref mobservices, ref availableservices, ref moboperator);
                            break;
                        }
                    case 4:
                        {
                            AddBalance(ref moboperator);
                            break;
                        }
                    case 5:
                        {
                            GetHistory(ref moboperator);
                            break;
                        }
                    default:
                        break;
                }
            } while (number != 6);
        }
    }
}
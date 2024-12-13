using System;
using System.Collections.Generic;

class Program
{
    public class Problem
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public Problem(int number, string description)
        {
            Number = number;
            Description = description;
        }
    }
    public class Resident
    {
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public Problem Problem { get; set; }
        public int Scandalousness { get; set; }
        public int Intelligence { get; set; }
        public Resident(string name, string passportNumber, Problem problem, int scandalousness, int intelligence)
        {
            Name = name;
            PassportNumber = passportNumber;
            Problem = problem;
            Scandalousness = scandalousness;
            Intelligence = intelligence;
        }
    }
    public class QueueManager
    {
        private Stack<Resident> residents = new Stack<Resident>();
        public void AddResident(Resident resident)
        {
            residents.Push(resident);
            Console.WriteLine($"{resident.Name} с проблемой '{resident.Problem.Description}' добавлен в очередь.");
        }

        public void ProcessQueue()
        {
            while (residents.Count > 0)
            {
                Resident current = residents.Pop(); 
                AssignToWindow(current);
            }
        }
        private void AssignToWindow(Resident resident)
        {
            Console.WriteLine($"Сегодня к Зине подошел {resident.Name} с проблемой: {resident.Problem.Description}");
            if (resident.Intelligence == 0)
            {
                int randomWindow = new Random().Next(1, 4);
                Console.WriteLine($"{resident.Name} идет в окно {randomWindow} (тупой и не слушает Зину).");
            }
            else
            {
                if (resident.Problem.Number == 1)
                {
                    Console.WriteLine($"{resident.Name} идет в окно 1 (проблемы с отоплением).");
                }
                else if (resident.Problem.Number == 2)
                {
                    Console.WriteLine($"{resident.Name} идет в окно 2 (проблемы с оплатой).");
                }
                else
                {
                    Console.WriteLine($"{resident.Name} идет в окно 3 (остальные проблемы).");
                }
                if (resident.Scandalousness >= 5)
                {
                    Console.Write("Сколько человек обгонит скандалист? ");
                    int skipCount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"{resident.Name} скандалист, обгоняет {skipCount} человек(а/ов)!");
                }
            }
        }
    }
    static void Main()
    {
        QueueManager queueManager = new QueueManager();
        queueManager.AddResident(new Resident("Иван", "123456", new Problem(1, "Подключение отопления"), 6, 1));
        queueManager.AddResident(new Resident("Петр", "789012", new Problem(2, "Оплата за отопление"), 3, 1));
        queueManager.AddResident(new Resident("Сергей", "345678", new Problem(3, "Не работают батареи"), 8, 0)); // Скандалист
        queueManager.AddResident(new Resident("Анна", "901234", new Problem(1, "Греет кота"), 2, 1));
        queueManager.AddResident(new Resident("Ольга", "567890", new Problem(2, "Квитанция потеряна"), 4, 0)); // Тупая
        queueManager.ProcessQueue();
    }
}

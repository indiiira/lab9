using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskManagment
{
    class Program
    {
        static void Shuffle(ref List<Employee> list)
        {
            Random r = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int swapIndex = r.Next(list.Count - 1);
                var temp = list[swapIndex];
                list[swapIndex] = list[i];
                list[i] = temp;
            }
        }
        static void Main(string[] args)
        {


            Employer teamLead = new Employer("Индира");
            Console.WriteLine("Сколько дней можно решать задачу?");
            int deadLine;
            while (!int.TryParse(Console.ReadLine(), out deadLine) || deadLine < 0)
            {
                Console.WriteLine("Неверный ввод!Повторите");
            }
            DateTime date = DateTime.Now.AddDays(deadLine);
            Console.Clear();
            int countEmployees = 10;
            List<Employee> employees = new List<Employee>(countEmployees);
         
            employees.Add(new Employee("Азалия", "Валиева"));
            employees.Add(new Employee("Алина", "Калмыкова"));
            employees.Add(new Employee("Михаил", "Тимленко"));
            employees.Add(new Employee("Елизавета", "Конасова"));
            employees.Add(new Employee("Денис", "Лучанкин"));
            employees.Add(new Employee("Шамиль", "Салахов"));
            employees.Add(new Employee("Регина", "Зиннатуллина"));
            employees.Add(new Employee("Ислам", "Гиззатулин"));
            employees.Add(new Employee("Камиль", "Хамитов"));
            employees.Add(new Employee("Ильшат", "Закиров"));
           

       
            Shuffle(ref employees);
            int countTasks = countEmployees;
            List<Task> tasks = new List<Task>(countTasks);

            tasks.Add(new Task("Нарисовать спрайты", "Нарисовать спрайты персонажей", teamLead));
            tasks.Add(new Task("Скрипты C#", "Реализовать основные скрипты объектов", teamLead));
            tasks.Add(new Task("Озвучка", "Записать аудио-дорожки для персонажей", teamLead));
            tasks.Add(new Task("Нарисовать спрайты", "Нарисовать спрайты окружения", teamLead));
            tasks.Add(new Task("Озвучка", "Записать аудио-дорожки окружения и эффектов", teamLead));
            tasks.Add(new Task("Нарисовать спрайты", "Нарисовать спрайты окружения,персонажей", teamLead));
            tasks.Add(new Task("Скрипты C#", "Реализовать скрипты компонентов (RigitBody,Transform и тд)", teamLead));
            tasks.Add(new Task("Продюссер", "Расписать сценарий игры", teamLead));
            tasks.Add(new Task("Тест", "Найти все баги,протестировать готовый или предготовый продукт", teamLead));
            tasks.Add(new Task("GameDev unity", "С помощью готовых шаблонов(спрайты,озвучка,скрипты,опираясь на сценарий) склеить полученную игру", teamLead));
         
            Project project = new Project("Игра", "Игра на unity к новому году", teamLead, tasks, date);
            if (project.Status.Equals(StatusOfProject.Assigned))
            {
                project.GiveProgect(employees);
                Employee.GiveTask(tasks, employees, deadLine);
                {
                    string letter = "Все задачи переданы";
                 
                    foreach (var ch in letter)
                    {
                        Console.Write(ch);
                        
                    }
                   
                    Console.WriteLine();
                }
            }


            while (employees.Count > 0)
            {
                Console.WriteLine("Выберите номер сотрудника,который сдает отчет:");

                for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {employees[i].Name} {employees[i].Surname}");
                }
                int index;
                while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > employees.Count)
                {
                    Console.WriteLine("Неверный ввод,повторите ввод!");
                }
                Report report = Report.TakeReport(employees[index - 1]);
                Employee.SendTask(employees[index - 1]);

                Console.WriteLine("Проверка прошла успешна?да/нет");
                bool input = Console.ReadLine().ToLower().Equals("да");
                if (input)
                {
                    Console.WriteLine("Работник сдал эту задачу!");
                    employees.Remove(employees[index - 1]);
                    report = null;
                }
                else
                {
                    Console.WriteLine("Задача отправлена на доработку!");
                    report = null;
                }
            }
            project.CloseProject();



        }
    }
}

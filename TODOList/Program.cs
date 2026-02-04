using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TODOList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var todoList = new List<string>();
            string todoTask = string.Empty;
            var inputsAviable = new List<string> { "s", "a", "r", "e" };
            string inputTask = string.Empty;
            Console.Title = "TODO List";

            while (!inputTask.Equals("e"))
            {
                Console.WriteLine("Hello!\r\nWhat do you want to do?\r\n[S]ee all TODOs\r\n[A]dd a TODO\r\n[R]emove a TODO\r\n[E]xit\r\n");
                if (!inputsAviable.Contains(inputTask = Console.ReadLine().ToLower()))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    switch (inputTask)
                    {
                        case "s":
                            SeeAllTODOs(todoList);
                            Console.WriteLine();
                            break;
                        case "a":
                            AddTODO(todoList);
                            Console.WriteLine();
                            break;
                        case "r":
                            RemoveTODO(todoList);
                            Console.WriteLine();
                            break;

                    }

                }
            }
        }

        static void SeeAllTODOs(List<string> todoList)
        {
            if (todoList.Count == 0)
            {
                Console.WriteLine("You don't have any task. YOU ARE FREE!");
            }
            else
            {
                for (int i = 0; i < todoList.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {todoList[i]};");
                }
            }
        }

        static void AddTODO(List<string> todoList)
        {
            string todoTask = string.Empty;
            do
            {
                Console.WriteLine("Enter the TODO description:");
                todoTask = Console.ReadLine();
                if (todoList.Contains(todoTask))
                {
                    Console.WriteLine("The description must be unique.");
                }
                if (string.IsNullOrEmpty(todoTask))
                {
                    Console.WriteLine("The description cannot be empty.");
                }
            }
            while (todoList.Contains(todoTask) || string.IsNullOrEmpty(todoTask));
            todoList.Add(todoTask);
            Console.WriteLine($"TODO successfully added: {todoList[todoList.Count - 1]}");
        }

        static void RemoveTODO(List<string> todoList)
        {
            string todoTask = string.Empty;
            bool weGoAgain = false;
            int todoRemovalIndex = 0;
            do
            {
                weGoAgain = false;
                Console.WriteLine("Select the index of the TODO you want to remove:");
                SeeAllTODOs(todoList);
                if (todoList.Count == 0)
                {
                    break;
                }
                todoTask = Console.ReadLine();

                if (string.IsNullOrEmpty(todoTask))
                {
                    Console.WriteLine("Selected index cannot be empty.");
                    weGoAgain = true;
                }
                else if (!int.TryParse(todoTask, out todoRemovalIndex) || todoList.Count < todoRemovalIndex || todoRemovalIndex < 1)
                {
                    Console.WriteLine("The given index is not valid.");
                    weGoAgain = true;
                }
            }
            while (weGoAgain);
            if (!string.IsNullOrEmpty(todoTask))
            {
                string temp = todoList[todoRemovalIndex - 1];
                todoList.RemoveAt(todoRemovalIndex - 1);
                Console.WriteLine($"TODO removed: {temp}");
            }
        }
    }
}

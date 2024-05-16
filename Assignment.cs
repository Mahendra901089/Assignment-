using System;
using System.Collections.Generic;
namespace Assignment1
{
   

    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    class Program
    {
        static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Task List Application");
                Console.WriteLine("1. Create a task");
                Console.WriteLine("2. Read tasks");
                Console.WriteLine("3. Update a task");
                Console.WriteLine("4. Delete a task");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateTask();
                        break;
                    case 2:
                        ReadTasks();
                        break;
                    case 3:
                        UpdateTask();
                        break;
                    case 4:
                        DeleteTask();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateTask()
        {
            Task newTask = new Task();
            Console.Write("Enter task title: ");
            newTask.Title = Console.ReadLine();
            Console.Write("Enter task description: ");
            newTask.Description = Console.ReadLine();
            tasks.Add(newTask);
            Console.WriteLine("Task created successfully!");
        }

        static void ReadTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
            }
            else
            {
                Console.WriteLine("Task List:");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"Title: {task.Title}, Description: {task.Description}");
                }
            }
        }

        static void UpdateTask()
        {
            Console.Write("Enter the title of the task to update: ");
            string titleToUpdate = Console.ReadLine();
            Task taskToUpdate = tasks.Find(task => task.Title == titleToUpdate);

            if (taskToUpdate == null)
            {
                Console.WriteLine("Task not found.");
            }
            else
            {
                Console.Write("Enter new title (press enter to keep current): ");
                string newTitle = Console.ReadLine();
                if (!string.IsNullOrEmpty(newTitle))
                {
                    taskToUpdate.Title = newTitle;
                }

                Console.Write("Enter new description (press enter to keep current): ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDescription))
                {
                    taskToUpdate.Description = newDescription;
                }

                Console.WriteLine("Task updated successfully!");
            }
        }

        static void DeleteTask()
        {
            Console.Write("Enter the title of the task to delete: ");
            string titleToDelete = Console.ReadLine();
            Task taskToDelete = tasks.Find(task => task.Title == titleToDelete);

            if (taskToDelete == null)
            {
                Console.WriteLine("Task not found.");
            }
            else
            {
                tasks.Remove(taskToDelete);
                Console.WriteLine("Task deleted successfully!");
            }
        }
    }
}

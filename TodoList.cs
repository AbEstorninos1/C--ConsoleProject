using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoListApp;

namespace TodoListApp;

class Program
{
    public static async Task Main()
    {
        await Task.Run(() => ToDoList.main());
    }
}
public class CompletedTask
{
    public string completeTask { get; set; }

    public static List<CompletedTask> CompleteTask = new List<CompletedTask>();

    public override string ToString()
    {
        return $"{completeTask}";
    }

    public static void displayCompletedTask()
    {
        var completeTasks = CompletedTask.CompleteTask.Select
            (
                (x, allTasks) => $"{allTasks + 1}.{x}"
            );

        Console.WriteLine("Complete Task:");
        var IsTaskIsNull = CompletedTask.CompleteTask.Count();

        if (IsTaskIsNull != 0)
        {
            foreach (var CompleteTasks in completeTasks)
                Console.WriteLine(CompleteTasks.ToString());

        }
        else
        {
            Console.Write("Complete Task is Empty.");
            Console.WriteLine();
        }


    }

}
public class ToDoList
{
    CompletedTask c = new CompletedTask();
    private string completeTask { get; set; }

    private string task { get; set; }
    private static List<ToDoList> listOfTask = new List<ToDoList>()


    {
        new ToDoList{
            task = "Do your homework."
        }
    };

    public override string ToString()
    {
        return $"{task}.";
    }


    public static async Task main()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---Todo List App---");
                Console.WriteLine("1.Add task");
                Console.WriteLine("2.Add Complete Task");
                Console.WriteLine("3.Remove Task");
                Console.WriteLine("4.Display Task");
                Console.WriteLine("5.Exit");
                Console.Write("Enter choices(1-5):");
                int choices = Convert.ToInt16(Console.ReadLine());

                if (choices >= 1 && choices <= 5)
                {
                    switch (choices)
                    {
                        case 1:
                            await AddTask();
                            break;
                        case 2:
                            await AddCompleteTask();
                            break;
                        case 3:
                            await RemoveTask();
                            break;
                        case 4:
                            await DisplayTask();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }

                }
                else
                {

                    Console.WriteLine("1 - 5 only.");
                    await Task.Delay(500);
                    Console.Clear();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input");
                await Task.Delay(500);
                Console.Clear();

            }
        }
    }
    private static async Task AddTask()
    {
        Console.Clear();
        while (true)
        {
        begin:
            Console.WriteLine("---Add Task---");
            Console.WriteLine();
            Console.WriteLine("Type 'Back' to go back.");
            Console.Write("task:");
            string addTask = Console.ReadLine();

            if (addTask.ToLower() == "back")
                await Task.Run(() => main());

            listOfTask.Add(
                new ToDoList()
                {
                    task = addTask
                }
            );
            var isAdded = listOfTask.Find(findtask => findtask.task == addTask);

            if (isAdded != null)
                Console.WriteLine("Add task successfully.");
            else
                Console.WriteLine("Add task unsuccessfully.");

            response:
            Console.WriteLine();
            Console.Write("Would you want to add task again?(yes/no):");
            string response = Console.ReadLine();

            if (response.ToLower() != "yes" && response.ToLower() == "no")
                await Task.Run(() => main());
            else if (response.ToLower() == "yes")
            {
                Console.Clear();
                goto begin;
            }

            else
            {
                Console.WriteLine("Yes or no only..");
                await Task.Delay(500);
                Console.Clear();
                goto response;

            }


        }
    }
    private static async Task AddCompleteTask()
    {

        while (true)
        {

            Console.Clear();

            var isTaskIsNull = listOfTask.Count();

            try
            {

                var completeTask = listOfTask.Select
                (
                    (x, allTask) => $"{allTask + 1}.{x}"
                );

                if (isTaskIsNull != 0)
                {

                    Console.Clear();
                    Console.WriteLine("---Add Complete Task---");
                    foreach (var CompleteTask in completeTask)
                        Console.WriteLine($"{CompleteTask.ToString()}");

                    begin:
                    Console.WriteLine("\nType '0' to go back.\n");
                    Console.Write("What number you complete:");

                    int numberTask = Convert.ToInt16(Console.ReadLine());

                    if (numberTask == 0)
                        await Task.Run(() => main());

                    CompletedTask.CompleteTask.Add(
                        new CompletedTask
                        {
                            completeTask = listOfTask[numberTask - 1].ToString()
                        }
                    );
                    CompletedTask.CompleteTask.Append(new CompletedTask
                    {
                        completeTask = listOfTask[numberTask - 1].ToString()
                    });


                    listOfTask.RemoveAt(numberTask - 1);

                    Console.Write("Complete task added successfully.");
                    Console.Clear();

                    Console.Write("Would you want to add complete task again?(yes/no):");
                    string response = Console.ReadLine();

                    if (response.ToLower() != "yes" && response.ToLower() == "no")
                        await Task.Run(() => main());
                    else if (response.ToLower() == "yes")
                    {
                        Console.Clear();

                    }
                    else
                    {
                        Console.WriteLine("Yes or no only..");
                        await Task.Delay(500);
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Write("Task is empty.");
                    Console.WriteLine();
                    Console.Write("Would you want to add task again?(yes/no):");
                    string response = Console.ReadLine();

                    if (response.ToLower() != "yes")
                        await Task.Run(() => main());

                    else if (response.ToLower() == "yes")
                        await Task.Run(() => AddTask());
                }

            }
            catch (FormatException)
            {
                Console.Write($"Invalid Input(1 - {isTaskIsNull} only)");
                await Task.Delay(500);
                Console.Clear();

            }
        }
    }
    private static async Task RemoveTask()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---Remove Task---");

            var pendingTask = listOfTask.Select
                (
                    (x, allTask) => $"{allTask + 1}.{x}"
                );
            var isTaskIsNull = listOfTask.Count();

            if (isTaskIsNull != 0)
            {


                foreach (var PendingTask in pendingTask)
                    Console.WriteLine(PendingTask.ToString());
                Console.WriteLine("\nType '0' to go back.\n");
                Console.Write("What task number you want to remove:");
                int removeTaskNumber = int.Parse(Console.ReadLine());

                if (removeTaskNumber == 0)
                    await Task.Run(() => main());


                listOfTask.RemoveAt(removeTaskNumber - 1);

                Console.WriteLine();

                Console.Write("Would you want to remove again?");
                string response = Console.ReadLine();
                if (response.ToLower() != "yes" && response.ToLower() == "no")
                    await Task.Run(() => main());
                else if (response.ToLower() == "yes")
                {
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("Yes or no only..");
                    await Task.Delay(500);
                    Console.Clear();
                }

            }
            else
            {
                Console.Write("Task is empty.");
                Console.WriteLine();
                Console.Write("Would you want to add task again?(yes/no):");
                string response = Console.ReadLine();

                if (response.ToLower() != "yes")
                    await Task.Run(() => main());

                else if (response.ToLower() == "yes")
                    await Task.Run(() => AddTask());

            }




        }
    }
    private static async Task DisplayTask()
    {
        Console.Clear();
        while (true)
        {
            var pendingTaskIsNull = listOfTask.Count();

            Console.WriteLine("---Display Task---");
            Console.WriteLine();
            Console.WriteLine("Pending Task:");
            if (pendingTaskIsNull != 0)
            {
                var pendingTask = listOfTask.Select
                    (
                        (x, allTask) => $"{allTask + 1}.{x}"
                    );


                foreach (var PendingTask in pendingTask)
                {
                    Console.WriteLine(PendingTask.ToString());
                }
            }
            else
                Console.WriteLine("Pending Task is Empty.");
            Console.WriteLine();
            CompletedTask.displayCompletedTask();
            Console.WriteLine();
            Console.Write("Type 'yes' if you want to go back:");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
                await Task.Run(() => main());
            else
                Environment.Exit(0);
            Console.Clear();
        }
    }
}

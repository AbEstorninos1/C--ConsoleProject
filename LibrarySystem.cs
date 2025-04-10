using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryBook;


namespace LibraryBook
{

    public static class Program
    {
        public static async Task Main()
        {
            await Library.Menu();
        }
    }
    public class Library
    {
        private string _authorName { get; set; }
        private string _bookTitle { get; set; }

        private int _publicationYear { get; set; }

        private static List<Library> bookList = new List<Library>(){
            new Library(){
                _authorName = "Ab",
                _bookTitle = "harrypotter",
                _publicationYear = 1996
            }
        };

        public static async Task Menu()
        {

            bool menuChoices = true;
            while (menuChoices)
            {
                Console.WriteLine("Librarian Admin\n");
                Console.WriteLine("1.Add book");
                Console.WriteLine("2.Search Book");
                Console.WriteLine("3.Remove Book");
                Console.WriteLine("4.Display Book");
                Console.WriteLine("5.Exit");

                Console.Write("Choose(1-4):");
                try
                {
                    int option = int.Parse(Console.ReadLine());

                    if (option < 1 && option > 4)
                        Console.Write("Invalid Input");
                    Console.Clear();



                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            menuChoices = false;
                            await AddBooks();
                            break;
                        case 2:
                            Console.Clear();
                            menuChoices = false;
                            await SearchBooks();
                            break;
                        case 3:
                            Console.Clear();
                            menuChoices = false;
                            await RemoveBooks();
                            break;
                        case 4:
                            Console.Clear();
                            menuChoices = false;
                            await DisplayBook();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;

                    }
                    if (option < 1 && option > 5)
                    {
                        Console.Write("Invalid Input!");
                        await Task.Delay(500);
                        Console.Clear();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input!");
                    await Task.Delay(500);

                    Console.Clear();
                }
            }

        }
        private static async Task AddBooks()
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("------Add Book-----");
                    Console.Write("Enter author name:");
                    string authorName = Console.ReadLine();

                    Console.Write("Enter Book Title:");
                    string bookTitle = Console.ReadLine();

                    Console.Write("Enter publication year:");
                    int publicationYear = int.Parse(Console.ReadLine());

                    Console.Write("Invalid Input!");
                    Task.Delay(200);
                    Console.Clear();

                    bookList.Add(new Library()
                    {
                        _authorName = authorName,
                        _bookTitle = bookTitle,
                        _publicationYear = publicationYear
                    });

                    var ifBookAdded = bookList.Find(b => b._authorName == authorName);
                    if (ifBookAdded != null)
                        Console.WriteLine("\nNew book added succesfully!\n");
                    else
                        Console.WriteLine("Book added unsuccesfully");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid Input!");
                    await Task.Delay(1000);
                    Console.Clear();
                }

                Console.Write("\nWould you want to add book again?(yes/no): ");
                string response = Console.ReadLine();

                if (response.ToLower() != "yes")
                {
                    Console.Clear();
                    Task.Delay(200);
                    await Menu();
                }
                Console.Clear();

            }
        }
        private static async Task SearchBooks()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("-----Search Book-----");
                    Console.Write("Enter author name:");
                    string authorName = Console.ReadLine();

                    Console.Write("Enter Book Title:");
                    string bookTitle = Console.ReadLine();

                    Console.Write("Enter publication year:");
                    int publicationYear = int.Parse(Console.ReadLine());

                    Console.Write("Invalid Input!");
                    Task.Delay(200);
                    Console.Clear();

                    var isBookContain = bookList.Find(b =>
                    (b._authorName == authorName &&
                    b._bookTitle == bookTitle &&
                    b._publicationYear == publicationYear)

                    );
                    if (isBookContain != null)
                    {
                        Console.WriteLine("Book Found:");
                        Console.WriteLine($"\nAuthor name :{isBookContain._authorName}\nBook Title :{isBookContain._bookTitle}\nPublication Year :{isBookContain._publicationYear}\n");
                    }
                    else
                        Console.WriteLine("book not found!");

                    Console.Write("Would you want to search another book?(yes/no): ");
                    string response = Console.ReadLine();

                    if (response.ToLower() != "yes")
                    {
                        Console.Clear();
                        await Menu();
                    }

                    Console.Clear();

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid Input!");
                    await Task.Delay(1000);
                    Console.Clear();
                }



            }
        }

        private static async Task RemoveBooks()
        {
            while (true)
            {
                Console.WriteLine("-----Remove Book-----");
                Console.Write("Enter Book Title:");
                string bookTitle = Console.ReadLine();

                Console.Clear();

                var RemoveBook = bookList.Find(b => b._bookTitle == bookTitle);
                var BookCount = bookList.Count(b => b._bookTitle == bookTitle);

                if (RemoveBook != null)
                {
                    Console.WriteLine($"Book Count: {BookCount}");
                    Console.Write($"Are u sure u remove {RemoveBook._bookTitle} book ?(yes/no): ");
                    string removeResponse = Console.ReadLine();

                    if (removeResponse.ToLower() == "yes")
                    {
                        bookList.Remove(RemoveBook);
                        Console.WriteLine("\nBook Successfully remove.");
                        Console.Write("\nWould you want to remove another book?(yes/no)");
                        string response = Console.ReadLine();

                        if (response.ToLower() != "yes")
                        {
                            Console.Clear();
                            await Menu();
                        }

                        Console.Clear();
                    }
                    else
                    {
                        Console.Write("Would you want to go back to menu?(yes/no): ");
                        string response = Console.ReadLine();

                        if (response.ToLower() != "yes")
                        {
                            Console.Clear();
                            await Menu();
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Book title not found.");
                    Console.Write("Would you want to go back to menu?(yes/no): ");
                    string response = Console.ReadLine();

                    if (response.ToLower() == "yes")
                    {
                        Console.Clear();
                        await Menu();
                    }
                    Console.Clear();
                }

            }
        }

        private static async Task DisplayBook()
        {
            Console.WriteLine("-----Display Book-----");
            if (bookList.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                Console.WriteLine("\nBook List\n");
                foreach (var book in bookList)
                {
                    Console.WriteLine($"Author: {book._authorName}");
                    Console.WriteLine($"Book Title: {book._bookTitle}");
                    Console.WriteLine($"Publication Year: {book._publicationYear}");
                    Console.WriteLine("------------------------");
                }
            }

            Console.Write("\nWould you like to go back to the menu?(yes): ");
            string response = Console.ReadLine();

            if (response.ToLower() == "yes")
            {
                Console.Clear();
                await Menu();
            }
        }

    }

}

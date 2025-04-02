using System;
using System.Collections.Generic;

class LibraryManager
{
    static void Main()
    {
        List<string> libraryBooks = new List<string>();
        const int maxCapacity = 5;

        while (true)
        {
            Console.WriteLine("Would you like to add or remove a book? (add/remove/exit)");
            string userAction = Console.ReadLine().ToLower();

            if (userAction == "add")
            {
                AddBook(libraryBooks, maxCapacity);
            }
            else if (userAction == "remove")
            {
                RemoveBook(libraryBooks);
            }
            else if (userAction == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', or 'exit'.");
            }

            DisplayBooks(libraryBooks);
        }
    }

    // Helper method to add a book to the library
    static void AddBook(List<string> books, int maxCapacity)
    {
        if (books.Count >= maxCapacity)
        {
            Console.WriteLine("The library is full. No more books can be added.");
        }
        else
        {
            Console.WriteLine("Enter the title of the book to add:");
            string newBook = Console.ReadLine();
            books.Add(newBook);
            Console.WriteLine($"'{newBook}' has been added to the library.");
        }
    }

    // Helper method to remove a book from the library
    static void RemoveBook(List<string> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("The library is empty. No books to remove.");
        }
        else
        {
            Console.WriteLine("Enter the title of the book to remove:");
            string bookToRemove = Console.ReadLine();
            if (books.Remove(bookToRemove))
            {
                Console.WriteLine($"'{bookToRemove}' has been removed from the library.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    // Helper method to display the list of books in the library
    static void DisplayBooks(List<string> books)
    {
        Console.WriteLine("Available books:");
        if (books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
        }
        else
        {
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
        }
    }
}
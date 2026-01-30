using System;

class LibraryManager
{
    const int BorrowLimit = 3;

    static void Main()
    {
        string[] books = new string[5];
        bool[] borrowed = new bool[5];

        while (true)
        {
            Console.WriteLine("Choose an action: add/remove/search/borrow/checkin/exit");
            string? actionInput = ReadTrimmedNullable();
            if (actionInput == null)
            {
                break;
            }

            string action = actionInput.ToLowerInvariant();

            if (action == "add")
            {
                if (IsLibraryFull(books))
                {
                    Console.WriteLine("The library is full. No more books can be added.");
                    continue;
                }

                Console.WriteLine("Enter the title of the book to add:");
                string? newBook = ReadTrimmedNullable();
                if (newBook == null)
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(newBook))
                {
                    Console.WriteLine("Book title cannot be empty.");
                    continue;
                }

                AddBook(books, borrowed, newBook);
            }
            else if (action == "remove")
            {
                if (IsLibraryEmpty(books))
                {
                    Console.WriteLine("The library is empty. No books to remove.");
                    continue;
                }

                Console.WriteLine("Enter the title of the book to remove:");
                string? removeBook = ReadTrimmedNullable();
                if (removeBook == null)
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(removeBook))
                {
                    Console.WriteLine("Book title cannot be empty.");
                    continue;
                }

                if (!RemoveBook(books, borrowed, removeBook))
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else if (action == "search")
            {
                Console.WriteLine("Enter the title of the book to search for:");
                string? searchTitle = ReadTrimmedNullable();
                if (searchTitle == null)
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(searchTitle))
                {
                    Console.WriteLine("Book title cannot be empty.");
                    continue;
                }

                int index = FindBookIndex(books, searchTitle);
                if (index >= 0)
                {
                    Console.WriteLine($"'{books[index]}' is available in the library.");
                }
                else
                {
                    Console.WriteLine("That book is not in the collection.");
                }
            }
            else if (action == "borrow")
            {
                if (IsLibraryEmpty(books))
                {
                    Console.WriteLine("The library is empty. No books to borrow.");
                    continue;
                }

                if (CountBorrowed(borrowed) >= BorrowLimit)
                {
                    Console.WriteLine($"You can only borrow up to {BorrowLimit} books at a time.");
                    continue;
                }

                Console.WriteLine("Enter the title of the book to borrow:");
                string? borrowTitle = ReadTrimmedNullable();
                if (borrowTitle == null)
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(borrowTitle))
                {
                    Console.WriteLine("Book title cannot be empty.");
                    continue;
                }

                int index = FindBookIndex(books, borrowTitle);
                if (index < 0)
                {
                    Console.WriteLine("That book is not in the collection.");
                }
                else if (borrowed[index])
                {
                    Console.WriteLine("That book is already checked out.");
                }
                else
                {
                    borrowed[index] = true;
                    Console.WriteLine($"You borrowed '{books[index]}'.");
                }
            }
            else if (action == "checkin")
            {
                if (CountBorrowed(borrowed) == 0)
                {
                    Console.WriteLine("You have no books checked out.");
                    continue;
                }

                Console.WriteLine("Enter the title of the book to check in:");
                string? checkInTitle = ReadTrimmedNullable();
                if (checkInTitle == null)
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(checkInTitle))
                {
                    Console.WriteLine("Book title cannot be empty.");
                    continue;
                }

                int index = FindBookIndex(books, checkInTitle);
                if (index < 0)
                {
                    Console.WriteLine("That book is not in the collection.");
                }
                else if (!borrowed[index])
                {
                    Console.WriteLine("That book is not checked out.");
                }
                else
                {
                    borrowed[index] = false;
                    Console.WriteLine($"You checked in '{books[index]}'.");
                }
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type add, remove, search, borrow, checkin, or exit.");
            }

            DisplayBooks(books, borrowed);
        }
    }

    static void AddBook(string[] books, bool[] borrowed, string title)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(books[i]))
            {
                books[i] = title;
                borrowed[i] = false;
                return;
            }
        }
    }

    static bool RemoveBook(string[] books, bool[] borrowed, string title)
    {
        int index = FindBookIndex(books, title);
        if (index >= 0)
        {
            books[index] = string.Empty;
            borrowed[index] = false;
            return true;
        }

        return false;
    }

    static int FindBookIndex(string[] books, string title)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(books[i]) &&
                string.Equals(books[i], title, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }

        return -1;
    }

    static void DisplayBooks(string[] books, bool[] borrowed)
    {
        Console.WriteLine("Available books:");
        bool any = false;

        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(books[i]))
            {
                string status = borrowed[i] ? " (checked out)" : string.Empty;
                Console.WriteLine($"{books[i]}{status}");
                any = true;
            }
        }

        if (!any)
        {
            Console.WriteLine("(none)");
        }
    }

    static int CountBorrowed(bool[] borrowed)
    {
        int count = 0;
        for (int i = 0; i < borrowed.Length; i++)
        {
            if (borrowed[i])
            {
                count++;
            }
        }

        return count;
    }

    static bool IsLibraryFull(string[] books)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(books[i]))
            {
                return false;
            }
        }

        return true;
    }

    static bool IsLibraryEmpty(string[] books)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(books[i]))
            {
                return false;
            }
        }

        return true;
    }

    static string? ReadTrimmedNullable()
    {
        string? line = Console.ReadLine();
        return line?.Trim();
    }
}

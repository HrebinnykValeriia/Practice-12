using practice12.models;
using practice12.utis;
using System.Collections.Generic;
using static System.Console;

namespace practice12.Services;

public class ServicesListBook
{
    public LinkedList<Book> Books { get; set; } = new LinkedList<Book>();

    public ServicesListBook(LinkedList<Book> books)
    {
        Books = books;
    }

    public void AddBook(int index, Book book)
    {
        index--;
        LinkedListNode<Book>? node = GetNodeAt(index);
        if (node != null)
        {
            Books.AddAfter(node, book);
        }
        else if (index == Books.Count - 1)
        {
            Books.AddLast(book);
        }
        else
        {
            WriteLine($"Invalid index: {index + 1}");
        }
    }

    public void AddBookBegin(Book book)
    {
        if (!Books.Contains(book))
        {
            Books.AddFirst(book);
        }
    }

    public void AddBookEnd(Book book)
    {
        if (!Books.Contains(book))
        {
            Books.AddLast(book);
        }
    }

    public string RemoveBook(int number)
    {
        number--;
        LinkedListNode<Book>? node = GetNodeAt(number);
        if (node == null)
        {
            return $"Error: {number} was not found";
        }

        Books.Remove(node);
        return $"Book was removed";
    }

    public string RemoveBookBegin()
    {
        if(Books.First == null) return $"Error: library is empty";
        Books.Remove(Books.First);
        return $"First book was removed";
    }

    public string RemoveBookEnd()
    {
        if (Books.Last == null) return $"Error: library is empty";
        Books.Remove(Books.Last);
        return $"Last book was removed";
    }
    public void ShowBooks()
    {
        int i = 1;
        foreach (Book book in Books)
        {
            WriteLine($"\n{i++} - {book}");
            
        }
    }

    public string EditBook(int num)
    {
        num--;
        LinkedListNode<Book>? node = GetNodeAt(num);
        if (node == null)
        {
            return $"Error: {num} was not found";
        }
        WriteLine("Enter new title: ");
        string title = ReadLine() ?? "";
        WriteLine("Enter new author: ");
        string author =  ReadLine() ?? "";
        WriteLine("""
                   Available Genres:
                   1) Romance
                   2) Fantasy
                   3) Science Fiction
                   4) Thriller
                   5) Mystery
                   6) Detective
                   7) Adventure
                   8) Drama
                   9) Classic Literature
                   10) Children's Literature
                   11) Horror
                   12) Poetry

                   Enter your choice:
                   """);
        int choice = Convert.ToInt32(ReadLine() ?? "");
        Genre genre = Genre.Adventure;
        switch (choice)
        {
            case 1: genre = Genre.Romance; break;
            case 2: genre = Genre.Fantasy; break;
            case 3: genre = Genre.ScienceFiction; break;
            case 4: genre = Genre.Thriller; break;
            case 5: genre = Genre.Mystery; break;
            case 6: genre = Genre.Detective; break;
            case 7: genre = Genre.Adventure; break;
            case 8: genre = Genre.Drama; break;
            case 9: genre = Genre.ClassicLiterature; break;
            case 10: genre = Genre.ChildrensLiterature; break;
            case 11: genre = Genre.Horror; break;
            case 12: genre = Genre.Poetry; break;
            default:
                return "Invalid genre choice";
        }
        WriteLine("Enter new year: ");
        if (!int.TryParse(ReadLine(), out int year))
        {
            return "Error: invalid year";
        }
        node.Value = node.Value with
        {
            Title = title,
            Author = author,
            Genre = genre,
            Year = year
        };
        return $"Edited book {num}";
    }

    public void SearchByTitle()
    {
        WriteLine("Enter title: ");
        string inputTitle = ReadLine() ?? "";
        bool found = false;
        foreach (Book book in Books)
        {
            if (book.Title.Contains(inputTitle, StringComparison.OrdinalIgnoreCase))
            {
                WriteLine($"{book.Author}\n{book.Genre} ({book.Year})");
                found = true;
            }
        }
        if (!found) WriteLine($"{inputTitle} was not found");
    }

    public void SearchByAuthor()
    {
        WriteLine("Enter author: ");
        string inputAuthor = ReadLine() ?? "";
        bool found = false;
        foreach (Book book in Books)
        {
            if (book.Author.Contains(inputAuthor, StringComparison.OrdinalIgnoreCase))
            {
                WriteLine($"<<{book.Title}>> - {book.Genre} ({book.Year})");
                found = true;
            }
        }
        if (!found)
        {
            WriteLine($"<<{inputAuthor}>> was not found");
        }
        
    }

    public void SearchByGenre()
    {
        WriteLine("Enter genre: ");
        string input = ReadLine() ?? "";

        if (!Enum.TryParse(input, true, out Genre genre))
        {
            WriteLine("Invalid genre");
            return;
        }

        bool founnd = false;
        foreach (Book book in Books)
        {
            if (book.Genre == genre)
            {
                WriteLine($"<<{book.Title}>> - {book.Author}");
                founnd = true;
            }
        }
        if (!founnd)
        {
            WriteLine($"<<{input}>> was not found");
        }
    }

    public void SearchByYear()
    {
        WriteLine("Enter year: ");
        if (!int.TryParse(ReadLine(), out int inputYear))
        {
            WriteLine("Invalid year");
            return;
        }
        bool found = false;
        foreach (Book book in Books)
        {
            if (book.Year == inputYear)
            {
                WriteLine($"<<{book.Title}>> - {book.Author} ({book.Genre})");
                found = true;
            }
        }

        if (!found)
        {
            WriteLine($"<<{inputYear}>> was not found");
        }
    }
    private LinkedListNode<Book>? GetNodeAt(int index)
    {
        if (index < 0 || index >= Books.Count)
        {
            return null;
        }

        LinkedListNode<Book>? current = Books.First;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current;
    }
}
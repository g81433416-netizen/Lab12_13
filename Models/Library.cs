using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Models;

public class Library
{
    private List<Book> books;
    private int nextId;

    public string Name { get; set; }

    public Library(string name)
    {
        Name = name;
        books = new List<Book>();
        nextId = 1;
    }

    public void AddBook(string title, string author, int year)
    {
        Book newBook = new Book(nextId++, title, author, year);
        books.Add(newBook);
        Console.WriteLine($"Книга добавлена: {newBook}");
    }

    public Book? FindBookById(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }

    public List<Book> FindBooksByAuthor(string author)
    {
        return books
            .Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Book> GetAvailableBooks()
    {
        return books.Where(b => b.IsAvailable).ToList();
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine($"\nБиблиотека: {Name}");
        Console.WriteLine($"Всего книг: {books.Count}");

        if (books.Count == 0)
        {
            Console.WriteLine("Библиотека пуста.");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    public int GetBookCount()
    {
        return books.Count;
    }
}
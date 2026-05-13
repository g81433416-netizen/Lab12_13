using LibraryApp.Models;

namespace LibraryApp.Services;

public class LibraryService
{
    private Library library;

    public LibraryService(Library library)
    {
        this.library = library;
    }

    public void CheckOutBook(int bookId)
    {
        Book? book = library.FindBookById(bookId);

        if (book == null)
        {
            Console.WriteLine($"Книга с ID {bookId} не найдена.");
            return;
        }

        book.CheckOut();
    }

    public void ReturnBook(int bookId)
    {
        Book? book = library.FindBookById(bookId);

        if (book == null)
        {
            Console.WriteLine($"Книга с ID {bookId} не найдена.");
            return;
        }

        book.Return();
    }

    public void SearchByAuthor(string author)
    {
        var books = library.FindBooksByAuthor(author);

        Console.WriteLine($"\nПоиск книг автора: {author}");

        if (books.Count == 0)
        {
            Console.WriteLine("Книги не найдены.");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    public void ShowAvailableBooks()
    {
        var availableBooks = library.GetAvailableBooks();

        Console.WriteLine("\nДоступные книги:");

        if (availableBooks.Count == 0)
        {
            Console.WriteLine("Нет доступных книг.");
            return;
        }

        foreach (var book in availableBooks)
        {
            Console.WriteLine(book);
        }
    }

    public void ShowStatistics()
    {
        int total = library.GetBookCount();
        int available = library.GetAvailableBooks().Count;
        int checkedOut = total - available;

        Console.WriteLine("\nСтатистика:");
        Console.WriteLine($"Всего книг: {total}");
        Console.WriteLine($"Доступно: {available}");
        Console.WriteLine($"Выдано: {checkedOut}");
    }
}
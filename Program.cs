using LibraryApp.Models;
using LibraryApp.Services;

namespace LibraryApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Система управления библиотекой");

        Library library = new Library("Городская библиотека №1");
        LibraryService service = new LibraryService(library);

        Console.WriteLine("\nДобавление книг:");

        library.AddBook("Война и мир", "Л.Н. Толстой", 1869);
        library.AddBook("Преступление и наказание", "Ф.М. Достоевский", 1866);
        library.AddBook("Мастер и Маргарита", "М.А. Булгаков", 1967);
        library.AddBook("Анна Каренина", "Л.Н. Толстой", 1877);
        library.AddBook("Идиот", "Ф.М. Достоевский", 1869);

        Console.WriteLine("\nВсе книги:");
        library.DisplayAllBooks();

        Console.WriteLine("\nВыдача книг:");
        service.CheckOutBook(1);
        service.CheckOutBook(3);

        service.ShowAvailableBooks();

        service.SearchByAuthor("Толстой");

        Console.WriteLine("\nВозврат книги:");
        service.ReturnBook(1);

        service.ShowStatistics();

        Console.WriteLine("\nПроверка повторной выдачи:");
        service.CheckOutBook(3);

        Console.WriteLine("\nПрограмма завершена. Нажмите Enter...");
        Console.ReadLine();
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Visma
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] books;
            books = new Book[100];
            baseJson(books);
            int n = 3;
            bool testi = true;
            while (testi)
            {
                Console.WriteLine("Type actions, that you want to perform, add a book 'a', take a book 't', return a book 'r', sort books 's', delete book 'd', end program 'e'");
                char info = Convert.ToChar(Console.ReadLine());
                switch (info)
                {
                    case 'a':
                        addBook(ref n, books);
                        break;
                    case 't':
                        takeBook(n, books);
                        break;
                    case 'r':
                        returnBook(n, books);
                        break;
                    case 's':
                        sortBy(n, books);
                        break;
                    case 'd':
                        deleteBook();
                        break;
                    case 'e':
                        testi = false;
                        break;
                    default:
                        Console.WriteLine("Error, you misstyped something");
                        break;

                }
            }
        }
        static void baseJson(Book[] books)
        {
            books[0] = JsonConvert.DeserializeObject<Book>(File.ReadAllText(@"C:\Visma\Json\Harry_Potter.json"));
            books[1] = JsonConvert.DeserializeObject<Book>(File.ReadAllText(@"C:\Visma\Json\1984.json"));
            books[2] = JsonConvert.DeserializeObject<Book>(File.ReadAllText(@"C:\Visma\Json\Mockingbird.json"));
        }
        static void addBook(ref int n, Book[] books)
        {
            Console.WriteLine("Type the name of the book!");
            string name = Console.ReadLine();
            Console.WriteLine("Type the author of the book!");
            string author = Console.ReadLine();
            Console.WriteLine("Type the category of the book!");
            string category = Console.ReadLine();
            Console.WriteLine("Type the language of the book!");
            string language = Console.ReadLine();
            Console.WriteLine("Type the publication date of the book!");
            string publication_date = Console.ReadLine();
            Console.WriteLine("Type the ISBN of the book!");
            string isbn = Console.ReadLine();

            books[3] = new Book(name, author, category, language, publication_date, isbn);
            List<Book> _book = new List<Book>();
            _book.Add(new Book()
            {
                Name = name,
                Author = author,
                Category = category,
                Language = language,
                Publication_date = publication_date,
                ISBN = isbn

            });

            string json = JsonConvert.SerializeObject(_book.ToArray());
            System.IO.File.WriteAllText(@"C:\Visma\Json\newBook.json", json);
            n++;
        }
        static void takeBook(int n, Book[] books)
        {
            Console.WriteLine("How many books would you like?");
            int numberBooks = Convert.ToInt32(Console.ReadLine());
            if (numberBooks > 3) Console.WriteLine("Maximum amount of books is 3");
            else if (numberBooks <= 0) Console.WriteLine("Please enter valid number");
            else if (numberBooks == 1)
            {
                Console.WriteLine("List of books available, type the number of the book that you want to borrow");

                for (int i = 0; i <= n; i++)
                {
                    if (books[i].BookNotTaken == true)
                        Console.WriteLine(i + ". " + books[i].Name);
                }
                int bookNr = Convert.ToInt32(Console.ReadLine());
                books[bookNr].BookNotTaken = false;
            }
            else if (numberBooks == 2)
            {
                Console.WriteLine("List of books available, type the numbers of the books that you want to borrow");

                for (int i = 0; i <= n; i++)
                {
                    if (books[i].BookNotTaken == true)
                        Console.WriteLine(i + ". " + books[i].Name);
                }
                int bookNr = Convert.ToInt32(Console.ReadLine());
                books[bookNr].BookNotTaken = false;
                bookNr = Convert.ToInt32(Console.ReadLine());
                books[bookNr].BookNotTaken = false;
            }
            else if (numberBooks == 3)
            {
                Console.WriteLine("List of books available, type the numbers of the books that you want to borrow");

                for (int i = 0; i <= n; i++)
                {
                    if (books[i].BookNotTaken == true)
                        Console.WriteLine(i + ". " + books[i].Name);
                }
                int bookNr = Convert.ToInt32(Console.ReadLine());
                books[bookNr].BookNotTaken = false;
                bookNr = Convert.ToInt32(Console.ReadLine());
                books[bookNr].BookNotTaken = false;
                bookNr = Convert.ToInt32(Console.ReadLine());
                books[bookNr].BookNotTaken = false;
            }
            else Console.WriteLine("error 404");
            Console.WriteLine("What is your name?");
            string namePerson = Console.ReadLine();
            Console.WriteLine("For How long are you taking the book/s?(typer number in days)");
            int lenghtDay = Convert.ToInt32(Console.ReadLine());
            if (lenghtDay > 60) Console.WriteLine("Your shouldnt exceed 2 months");
            else Console.WriteLine("[0], have a good day, will see you in [1] days", lenghtDay, namePerson);
        }
        static void returnBook(int n, Book []books)
        {
            Console.WriteLine("Which book would you like to return, type the number next to the book");
            for (int i = 0; i <= n; i++)
            {
                if (books[i].BookNotTaken == false)
                    Console.WriteLine(i + ". " + books[i].Name);
            }

            int giveBackBook = Convert.ToInt32(Console.ReadLine());
            books[giveBackBook].BookNotTaken = true;
            Console.WriteLine("Is return late? true/false");
            bool Late = Convert.ToBoolean(Console.ReadLine());
            if (Late) Console.WriteLine("Next time please be a little faster");
        }
        public static void sortBy(int n, Book[] books)
        {        
            Console.WriteLine("Sort by Author type a, sort by category type c, sort by language type l, sort by ISBN type i, sort by name type n");
            char key = Convert.ToChar(Console.ReadLine());
            if (key == 'a')
            {
                //Author
                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - i - 1; j++)
                        if (Convert.ToInt32(books[j].Author) > Convert.ToInt32(books[j + 1].Author))
                        {
                            // swap temp and arr[i]
                            Book temp = books[j];
                            books[j] = books[j + 1];
                            books[j + 1] = temp;
                        }
            }
            else if (key == 'c')
            {
                //category
                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - i - 1; j++)
                        if (Convert.ToInt32(books[j].Category) > Convert.ToInt32(books[j + 1].Category))
                        {
                            // swap temp and arr[i]
                            Book temp = books[j];
                            books[j] = books[j + 1];
                            books[j + 1] = temp;
                        }
            }
            else if (key == 'l')
            {
                //language

                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - i - 1; j++)
                        if (Convert.ToInt32(books[j].Language) > Convert.ToInt32(books[j + 1].Language))
                        {
                            // swap temp and arr[i]
                            Book temp = books[j];
                            books[j] = books[j + 1];
                            books[j + 1] = temp;
                        }
            }
            else if (key == 'i')
            {
                //ISBN
                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - i - 1; j++)
                        if (Convert.ToInt32(books[j].ISBN) > Convert.ToInt32(books[j + 1].ISBN))
                        {
                            // swap temp and arr[i]
                            Book temp = books[j];
                            books[j] = books[j + 1];
                            books[j + 1] = temp;
                        }
            }
            else if (key == 'n')
            {
                //name
                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - i - 1; j++)
                        if (Convert.ToInt32(books[j].Name) > Convert.ToInt32(books[j + 1].Name))
                        {
                            // swap temp and arr[i]
                            Book temp = books[j];
                            books[j] = books[j + 1];
                            books[j + 1] = temp;
                        }
            }
            
        }
        static void deleteBook()
        {
            Console.WriteLine("Type the name of the book that you want to delete");
            string delete = Console.ReadLine();
            string myPath = @"C:\Visma\Json\newBook" + delete + ".json";
            File.Delete(myPath);
        }
    }
}

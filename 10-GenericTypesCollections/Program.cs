using _10_GenericTypesCollections.Models;

namespace _10_GenericTypesCollections
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 1. Kitablarin Yaradilmasi ===");
            Book book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
            Book book2 = new Book(2, "1984", "George Orwell", 1949, 328);
            Book book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
            Book book4 = new Book(4, "Ag Gemi", "Cingiz Aytmatov", 1970, 200);
            Book book5 = new Book(5, "Qiriq Budaq", "Elcin", 1998, 350);

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
            book4.DisplayInfo();
            book5.DisplayInfo();


            Console.WriteLine("\n=== 2. Generic Library Testi ===");
            Library<Book> milliKitabxana = new Library<Book>("Milli Kitabxana");
            milliKitabxana.Add(book1);
            milliKitabxana.Add(book2);
            milliKitabxana.Add(book3);
            milliKitabxana.Add(book4);
            milliKitabxana.Add(book5);

            Console.WriteLine($"Kitab sayi: {milliKitabxana.Count()}");

            Console.Write("Indeks 0: ");
            milliKitabxana.FindByIndex(0)?.DisplayInfo();

            Console.Write("Indeks 2: ");
            milliKitabxana.FindByIndex(2)?.DisplayInfo();

            Console.WriteLine("Butun kitablar (GetAll):");
            foreach (var b in milliKitabxana.GetAll())
            {
                b.DisplayInfo();
            }


            Console.WriteLine("\n=== 3. Uzvler ve Borc Prosesi ===");
            List<Member> members = new List<Member>();
            Member m1 = new Member(1, "Ali Mammadov", "ali@mail.com");
            Member m2 = new Member(2, "Leyla Hasanova", "leyla@mail.com");
            Member m3 = new Member(3, "Vuqar Aliyev", "vuqar@mail.com");
            members.Add(m1); members.Add(m2); members.Add(m3);

            m1.BorrowBook(book1);
            m1.BorrowBook(book2);
            m1.DisplayBorrowedBooks();

            m1.ReturnBook(1);
            m1.DisplayBorrowedBooks();

            m1.BorrowBook(book3);
            m1.BorrowBook(book4);
            m1.BorrowBook(book5);
            m1.BorrowBook(new Book(6, "Limit Test", "Author", 2024, 100));


            Console.WriteLine("\n=== 4. Dictionary Testi (Muellif) ===");
            BookManager manager = new BookManager();
            manager.AddBook(book1);
            manager.AddBook(book2);
            manager.AddBook(book3);
            manager.AddBook(book4);
            manager.AddBook(book5);

            Console.WriteLine("George Orwell kitablari:");
            foreach (var b in manager.GetBooksByAuthor("George Orwell"))
            {
                b.DisplayInfo();
            }

            Console.WriteLine($"Cingiz Aytmatov kitablari sayi: {manager.GetBooksByAuthor("Cingiz Aytmatov").Count}");
            Console.WriteLine($"Jack London kitablari sayi: {manager.GetBooksByAuthor("Jack London").Count}");
            Console.WriteLine($"Dostoyevski kitablari sayi: {manager.GetBooksByAuthor("Dostoyevski").Count}");


            Console.WriteLine("\n=== 5. Queue Testi (Novbe) ===");
            manager.AddToWaitingQueue("Nigar");
            manager.AddToWaitingQueue("Resad");
            manager.AddToWaitingQueue("Sabina");
            Console.WriteLine($"Novbede nece nefer var? {manager.WaitingQueue.Count}");

            Console.WriteLine($"Xidmet edilir: {manager.ServeNextInQueue()}");
            Console.WriteLine($"Indi novbede nece nefer qalib? {manager.WaitingQueue.Count}");

            manager.ServeNextInQueue();
            Console.WriteLine($"Daha 1 nefer xidmet olundu. Qalan say: {manager.WaitingQueue.Count}");

            manager.ServeNextInQueue();
            Console.WriteLine($"Novbe yoxlanisi: {manager.WaitingQueue.Count}");


            Console.WriteLine("\n=== 6. Stack Testi (Son Qaytarilanlar) ===");
            manager.ReturnBook(book1);
            manager.ReturnBook(book2);
            manager.ReturnBook(book3);
            Console.WriteLine($"Stack-de nece kitab var? {manager.RecentlyReturned.Count}");

            Console.Write("Son qaytarilan kitab: ");
            manager.GetLastReturnedBook()?.DisplayInfo();

            manager.RecentlyReturned.Pop();
            Console.WriteLine("Stack-den 1 kitab cixarildi (Pop)");
            Console.WriteLine($"Indi stack-de nece kitab var? {manager.RecentlyReturned.Count}");

            Console.Write("Yeniden son qaytarilana baxiş: ");
            manager.GetLastReturnedBook()?.DisplayInfo();


            Console.WriteLine("\n=== 7. Basliga Gore Axtaris ===");
            Book search1 = manager.SearchByTitle("1984");
            if (search1 != null)
            {
                Console.Write("Tapildi: ");
                search1.DisplayInfo();
            }

            Book search2 = manager.SearchByTitle("Harry Potter");
            if (search2 == null)
            {
                Console.WriteLine("Harry Potter tapilmadi.");
            }


            Console.WriteLine("\n=== 8. Statistika ===");
            Console.WriteLine($"Umumi kitab sayi: {manager.Books.Count}");
            Console.WriteLine($"Umumi uzv sayi: {members.Count}");
            Console.WriteLine($"Novbede nefer sayi: {manager.WaitingQueue.Count}");
            Console.WriteLine($"Stack-de kitab sayi: {manager.RecentlyReturned.Count}");

            int oldestYear = manager.Books[0].Year;
            int newestYear = manager.Books[0].Year;

            foreach (var b in manager.Books)
            {
                if (b.Year < oldestYear) oldestYear = b.Year;
                if (b.Year > newestYear) newestYear = b.Year;
            }

            Console.WriteLine($"En kohne kitabin ili: {oldestYear}");
            Console.WriteLine($"En yeni kitabin ili: {newestYear}");

            Console.ReadLine();
        }
    }
}

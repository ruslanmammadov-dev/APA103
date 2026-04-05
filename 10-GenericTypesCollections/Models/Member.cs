using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_GenericTypesCollections.Models
{
    using System;
    using System.Collections.Generic;

    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Member(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            if (BorrowedBooks.Count < 3)
            {
                BorrowedBooks.Add(book);
                Console.WriteLine($"Kitab goturuldu: {book.Title}");
            }
            else
            {
                Console.WriteLine("Maksimum 3 kitab goture bilersiniz!");
            }
        }

        public void ReturnBook(int bookId)
        {
            Book bookToRemove = null;
            foreach (var book in BorrowedBooks)
            {
                if (book.Id == bookId)
                {
                    bookToRemove = book;
                    break;
                }
            }

            if (bookToRemove != null)
            {
                BorrowedBooks.Remove(bookToRemove);
                Console.WriteLine($"Kitab qaytarildi: {bookToRemove.Title}");
            }
        }

        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Borc kitab yoxdur");
            }
            else
            {
                Console.WriteLine($"{Name} terefinden goturulmuş kitablar");
                foreach (var book in BorrowedBooks)
                {
                    book.DisplayInfo();
                }
            }
        }
    }
}

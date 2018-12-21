using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);

            Console.Read();
        }
    }

    class Reader
    {
        public void SeeBooks(Library library)
        {
            IBookIterator iterator = library.CreateNumerator();
            while (iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }

    interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }

    interface IBookNumerable
    {
        IBookIterator CreateNumerator();
        int Count { get; }
        Book this[int index] { get; }
    }

    class Book
    {
        public string Name { get; set; }
    }

    class Library : IBookNumerable
    {
        private Book[] books;

        public Library()
        {
            books = new Book[] {new Book {Name="Война и мир"}, new Book {Name="Отцы и дети"}, new Book {Name="Вишневый сад"} };
        }

        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }

        public int Count
        {
            get { return books.Length; }
        }

        public Book this[int index]
        {
            get { return books[index]; }
        }
    }

    class LibraryNumerator : IBookIterator
    {
        private IBookNumerable aggregate;
        private int index = 0;

        public LibraryNumerator(IBookNumerable a)
        {
            aggregate = a;
        }
        
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Book Next()
        {
            return aggregate[index++];
        }
    }
}
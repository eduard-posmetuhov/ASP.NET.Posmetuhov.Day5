using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
     [Serializable()]
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        private string author;
        public Book(string Author, string Title, string Publisher, int Year, int Page)
        {
            this.Author = Author;
            this.Title = Title;
            this.Publisher = Publisher;
            this.Year = Year;
            this.Page = Page;
        }
        public string Author 
        {
            get
            {
                return author;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    this.author = value;
                else throw new ArgumentException("Имя автора не может быть пустым");
            }
        }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Page { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}",Author,Title,Publisher,Page,Year);
        }

        public bool Equals(Book other)
        {
            if (other == null)
                return false;

            if (this.Author != other.Author)
                return false;
            if (this.Title != other.Title)
                return false;
            if (this.Publisher != other.Publisher)
                return false;
            if (this.Page != other.Page)
                return false;
            if (this.Page != other.Page)
                return false;
            return true;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Book bookObj = obj as Book;
            if (bookObj == null)
                return false;
            else
                return Equals(bookObj); 
        }

        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return Title.CompareTo(other.Title);
        }
        public static int CompareBookByAuthor(Book x, Book y)
        {
            return x.Author.CompareTo(y.Author);
        }

        public static int CompareBookByYear(Book x, Book y)
        {
            return x.Year.CompareTo(y.Year);
        }
        public static int CompareBookByPage(Book x, Book y)
        {
            return x.Page.CompareTo(y.Page);
        }
        public static int CompareBookByPublisher(Book x, Book y)
        {
            return x.Publisher.CompareTo(y.Publisher);
        }
    }
}

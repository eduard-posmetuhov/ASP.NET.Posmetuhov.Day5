using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BookLibrary
{
    public enum EnumTag
    {
        Author,
        Title,
        Publisher,
        Year,
        Page
    }
    [Serializable()]	
    public class BookListService
    {
       
        private List<Book> storage;
        public BookListService()
        {
            storage=new List<Book>();
        }

        public void AddBook(Book addBook)
        {
            if (addBook == null)
                throw new NullReferenceException();
            if (storage.Contains(addBook))
                throw new ArgumentException("Добавляемая книга уже есть в списке");
            storage.Add(addBook);
        }

        public void RemoveBook(Book removeBook)
        {
            if (removeBook == null)
                throw new NullReferenceException();
            if (!storage.Contains(removeBook))
                throw new ArgumentException("Удаляемой книги нет в списке");
            storage.Remove(removeBook);
        }

        public Book[] FindByTag(string TagValue, EnumTag Tag)
        {
           List<Book> lb=new List<Book>(); 
            switch(Tag)
            {
                case EnumTag.Author:
                    foreach(Book b in storage)
                    {
                        if (b.Author==TagValue)
                            lb.Add(b);
                    }
                    break;
                case EnumTag.Title:
                    foreach(Book b in storage)
                    {
                        if (b.Title == TagValue)
                            lb.Add(b);
                    }
                    break;
                case EnumTag.Publisher:
                    foreach (Book b in storage)
                    {
                        if (b.Publisher == TagValue)
                            lb.Add(b);
                    }
                    break;
                case EnumTag.Year:
                    foreach (Book b in storage)
                    {
                        if (b.Year.ToString() == TagValue)
                            lb.Add(b);
                    }
                    break;
                case EnumTag.Page:
                    foreach (Book b in storage)
                    {
                        if (b.Year.ToString() == TagValue)
                            lb.Add(b);
                    }
                    break;
            }
            return lb.ToArray();
        }
        public Book[] SortBooksByTag(EnumTag Tag)
        {
            switch (Tag)
            {
                case EnumTag.Author:
                    storage.Sort(Book.CompareBookByAuthor);
                    break;
                case EnumTag.Title:
                    storage.Sort();
                    break;
                case EnumTag.Publisher:
                    storage.Sort(Book.CompareBookByPublisher);
                     break;
                case EnumTag.Year:
                    storage.Sort(Book.CompareBookByYear);
                    break;
                    case EnumTag.Page:
                    storage.Sort(Book.CompareBookByPage);
                    break;
            }            
            return storage.ToArray();
        }
        
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using NLog;

namespace TestConsole
{
    
    class Program
    {
        private const string fileName = "BookLib.dat";
        public static Logger log;
        static void Main(string[] args)
        {
            try
            {
                log = LogManager.GetCurrentClassLogger();
                BookListService bls = new BookListService();
                log.Debug("Старт записи в двоичный файл");
                    WriteDefaultValues(fileName);
                log.Debug("Окончание записи в двоичный файл");
                log.Debug("Старт чтения данных из двоичног файла");
                bls = ReadDefaultValues(fileName);
                log.Debug("Окончание чтения данных из двоичног файла");
                Book[] find = bls.FindByTag("1999", EnumTag.Year); //Поиск
                foreach (Book b in find)
                Console.WriteLine(b);
                Console.WriteLine("-------------------------");
                Book[] sort = bls.SortBooksByTag(EnumTag.Page);//Сортировка
                foreach (Book b in sort)
                    Console.WriteLine(b);
                //log.Warn("Попытка добавить уже существующую книгу");
                //bls.AddBook(sort[0]); 
                bls.RemoveBook(sort[0]);//Удаление книги
                log.Warn("Попытка удаления книги отсутствующей в каталоге");
                bls.RemoveBook(sort[0]);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            
        }

        private static void WriteDefaultValues(string fileName)
        {
            Book first = new Book("Author1", "Title1", "Pub1", 1990, 200);
            Book second = new Book("Author2", "Title2", "Pub1", 1999, 250);
            Book third = new Book("Author3", "Title3", "Pub1", 1998, 205);
            BookListService bls = new BookListService();
            bls.AddBook(first);
            bls.AddBook(second);
            bls.AddBook(third);
            
            FileStream fs = new FileStream(fileName, FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, bls);                

            }
            catch (SerializationException e)
            {
                log.Error("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public static BookListService ReadDefaultValues(string fileName)
        {
            BookListService bls = new BookListService();
            FileStream fs = new FileStream(fileName, FileMode.Open);
        try 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            bls = (BookListService)formatter.Deserialize(fs);
            return bls;
        }
        catch (SerializationException e) 
        {
            log.Error("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally 
        {
            fs.Close();
        }

        }
    }
}

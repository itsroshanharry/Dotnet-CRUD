using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Repository
{
    public class Repository:IBookRepo
    {
        private BookContext context;

        public Repository()
        {
            context = new BookContext();
        }

        public bool AddBook(Book b)
        {
            if (b == null)
            {
                return false;
            }

            try
            {
                context.Books.Add(b);
                context.SaveChanges();
            }catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateBook(Book b)
        {
            if (b == null)
            {
                return false;
            }
            try
            {
                Book temp = context.Books.Find(b.id);
                temp.BookName = b.BookName;
                temp.Price = b.Price;
            } catch
            {
                return false;

            }
            return true;
        }

        public bool DeleteBook(int id)
        {
            Book temp = null;
            try
            {
                temp = context.Books.Find(id);
                context.Books.Remove(temp);
                context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Book> getAllBooks()
        {
            return context.Books.ToList();
        }

        public Book getBookById(int id)
        {
            Book b = null;
            try
            {
                b = context.Books.Find(id);
            } catch
            {
                return null;
            }
            return b;
        }
    }
}

using ClassLibrary2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Repository
{
    public interface IBookRepo
    {
        public IEnumerable<Book> getAllBooks();
        public bool AddBook(Book b);
        public bool UpdateBook(Book b);
        public bool DeleteBook(int id);
        public Book getBookById(int id);
    }
}

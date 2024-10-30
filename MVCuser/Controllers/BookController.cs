using ClassLibrary2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MVCuser.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepo repo;

        public BookController(IBookRepo repo) {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<ClassLibrary2.Models.Book> libblist = repo.getAllBooks().ToList();
            List<MVCuser.Models.Book> mvcblist = new List<Models.Book>();

            foreach(ClassLibrary2.Models.Book libb in libblist)
            {
                MVCuser.Models.Book mvcb = new MVCuser.Models.Book();

                mvcb.id = libb.id;
                mvcb.BookName = libb.BookName;
                mvcb.Price = libb.Price;

                mvcblist.Add(mvcb);
            }

            return View(mvcblist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MVCuser.Models.Book mvcb)
        {
            if (ModelState.IsValid)
            {
                ClassLibrary2.Models.Book libb = new ClassLibrary2.Models.Book();

                libb.id = mvcb.id;
                libb.BookName = mvcb.BookName;
                libb.Price = mvcb.Price;

                bool result = repo.AddBook(libb);
            }
            return RedirectToAction("Index", "Book");
        }

        [HttpGet] 
        public IActionResult Edit(int id)
        {
            ClassLibrary2.Models.Book libb = repo.getBookById(id);
            MVCuser.Models.Book mvcb = new Models.Book();

            mvcb.id = libb.id;
            mvcb.BookName=libb.BookName;
            mvcb.Price = libb.Price;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(MVCuser.Models.Book mvcb)
        {
            if (ModelState.IsValid)
            {
                ClassLibrary2.Models.Book libb = new ClassLibrary2.Models.Book();

                libb.id = mvcb.id;
                libb.BookName = mvcb.BookName;
                libb.Price = mvcb.Price;

                bool result = repo.UpdateBook(libb);
            }

            return RedirectToAction("Index", "Book");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ClassLibrary2.Models.Book libb = repo.getBookById(id);
            MVCuser.Models.Book mvcb = new Models.Book();

            mvcb.id = libb.id;
            mvcb.BookName = libb.BookName;
            mvcb.Price = libb.Price;

            return View();
        }

        [HttpPost]
        [ActionName(name:"Delete")]
        public IActionResult DeleteConfiremed(int id)
        {
            bool result = repo.DeleteBook(id);

            return RedirectToAction("Index", "Book");
        }
    }
}

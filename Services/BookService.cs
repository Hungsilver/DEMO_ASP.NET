using CRUD_ASP.NET_CORE.Models;

namespace CRUD_ASP.NET_CORE.Services
{
    public static class BookService
    {
        static List<Book> Books { get; }
        static int nextId = 3;

        static BookService()
        {
            Books = new List<Book> {
                new Book { Id = Guid.NewGuid(),Title="40 vạn lợn",Image="1.png",TheLoaiId=Guid.NewGuid()},
                new Book { Id = Guid.NewGuid(),Title="50 vạn lợn",Image="2.png",TheLoaiId=Guid.NewGuid()},
                new Book { Id = Guid.NewGuid(),Title="60 vạn lợn",Image="3.png",TheLoaiId=Guid.NewGuid()}
            };

        }
        public static List<Book> GetAll() => Books;

        public static  Book Get(Guid id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }
        

        public static void Add(Book book)
        {
            Books.Add(book);
        }

        public static void Delete(Guid id)
        {
            var book = Get(id);
            if (book == null) return;

            Books.Remove(book);
        }

        public static void Update(Guid id,Book book)
        {
            int index = Books.FindIndex(b => b.Id == id);
            if(index == -1) return;
            Books[index] = book;
        }
    }
}

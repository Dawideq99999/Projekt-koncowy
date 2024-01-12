namespace Bookstore.Models;

    public class BookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public string Isbn { get; set; }
        public int Id { get; set; }
}


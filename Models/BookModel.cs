namespace bookshelf_web_app.Models
{

    public class BookResultModel
    {
        public string error { get; set; }
        public string total { get; set; }
        public string page { get; set; }
        public BookModel[] books { get; set; }
    }

    public class BookModel
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string isbn13 { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string url { get; set; }
    }

}

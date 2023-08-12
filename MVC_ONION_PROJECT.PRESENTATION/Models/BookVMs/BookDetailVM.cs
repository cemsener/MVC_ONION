namespace MVC_ONION_PROJECT.PRESENTATION.Models.BookVMs
{
    public class BookDetailVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}

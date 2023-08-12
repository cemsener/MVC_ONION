using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_ONION_PROJECT.PRESENTATION.Models.BookVMs
{
    public class BookUpdateVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }
        public SelectList AuthorList { get; set; }
        public Guid AuthorId { get; set; }
    }
}

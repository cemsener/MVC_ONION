using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_ONION_PROJECT.PRESENTATION.Models.BookVMs
{
    public class BookCreateVM
    {
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid AuthorId { get; set; }
        public SelectList AuthorList { get; set; }
    }
}

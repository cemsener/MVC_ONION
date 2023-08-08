using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_ONION_PROJECT.PRESENTATION.Models.AuthorVMs
{
    public class AuthorCreateVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
    }
}

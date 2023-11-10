using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Publisher
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PubId { get; set; }

        public string? PublisherName { get; set; } = string.Empty;

        public string? City { get; set; } = string.Empty;

        public string? State { get; set; }

        public string? Country { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}

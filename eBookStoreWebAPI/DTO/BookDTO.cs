using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }

        public string Title { get; set; }

       public int PubId { get; set; }

        public decimal Price { get; set; }

        public string Notes { get; set; }

        public DateTime PublishedDate { get; set; } = DateTime.Now;

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Book
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Type { get; set; }
        public int PubId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance {  get; set; }
        public decimal? Royality { get; set; }
        public int? Ytd_sale { get; set; }
        public string? Notes {  get; set; }
        public DateTime? PublisherDate { get; set; }
        public ICollection<BookAuthor>? BookAuthors { get; set; }
        public Publisher? Publisher { get; set; }

    }
}

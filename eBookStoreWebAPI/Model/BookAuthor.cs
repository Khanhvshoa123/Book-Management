﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public int AuthorOrder {  get; set; }
        public decimal RoyalityPercentage { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }

    }
}

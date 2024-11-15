﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Siciu_Alina_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public int? AuthorID { get; set; }
        public Author? Author { get; set; }
        public ICollection<Borrowing>? Borrowings { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }

    }
}

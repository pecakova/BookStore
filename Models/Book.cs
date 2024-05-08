﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }
        public int? YearPublished { get; set; }
        public int? NumPages { get; set; }
        [StringLength(int.MaxValue)]
        public string? Description { get; set; }
        [StringLength(50)]
        public string? Publisher { get; set;  }
        [StringLength(int.MaxValue)]
        public string? FrontPage { get; set;  }
        [StringLength(int.MaxValue)]
        public string? DownloadUrl { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public ICollection<BookGenre>? Genre { get; set; }
        
        public ICollection<Review>? Review { get; set; } //One-to-many relationship with Review
        public ICollection<UserBooks>? UserBooks { get; set; }


    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.ViewModels
{
    public class BooksAuthorsEditViewModel
    {
        public Book? Books { get; set; }
        public IEnumerable<int>? SelectedAuthors { get; set; }
        public IEnumerable<SelectListItem>? AuthorList { get; set; }
    }
}
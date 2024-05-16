using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.ViewModels
{
    public class BooksAuthorViewModel
    {
        public IList<Author> Authors { get; set; }

        public string SearchName { get; set; }
        public string SearchSurname { get; set; }

    }
}
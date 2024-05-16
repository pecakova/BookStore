using BookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.ViewModel
{
    public class BookGenresCreateViewModel
    {
        public Book? Book { get; set; }
        public IEnumerable<int>? SelectedGenres { get; set; }
        public IEnumerable<SelectListItem>? GenreList { get; set; }
        public IEnumerable<SelectListItem>? AuthorsList { get; set; }
    }
}
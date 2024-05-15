using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.Models;

namespace BookStore.ViewModels
{
    public class BookGenresEditViewModel
    {
        public Book? Book { get; set; }
        public IEnumerable<int>? SelectedGenres { get; set; }
        public IEnumerable<SelectListItem>? GenreList { get; set; }
    }
}
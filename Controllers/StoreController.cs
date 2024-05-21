using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using BookStore.Areas.Identity.Data;
using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModel;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly BookStoreContext _context;
        private readonly UserManager<BookStoreUser> _userManager;
        public StoreController(BookStoreContext context, UserManager<BookStoreUser> userManager)
        {

            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Book.ToListAsync());
        }

        public async Task<IActionResult> IndexById(int id)
        {
            //knigata shto treba da se dodade
            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.BookGenres).ThenInclude(bg => bg.Genre)
                .Include(books => books.Reviews)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var name = user.Email;
            var userBooks = await _context.UserBooks
                .Include(u => u.Book)
                    .ThenInclude(b => b.BookGenres)
                        .ThenInclude(bg => bg.Genre)
                .Include(u => u.Book)
                    .ThenInclude(b => b.Author)
                .Where(ub => ub.AppUser == name)
                .ToListAsync();

            var exist = userBooks.Any(b => b.Book.Id == id);

            if (exist)
            {
                return RedirectToAction(nameof(Index));
            }

            var newMyBook = new UserBooks
            {
                BookId = id,
                AppUser = name
            };

            _context.UserBooks.Add(newMyBook);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}

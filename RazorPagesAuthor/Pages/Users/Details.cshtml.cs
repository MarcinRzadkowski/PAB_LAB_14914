using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAuthor.Data;
using RazorPagesAuthor.Model;

namespace RazorPagesAuthor.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesAuthor.Data.RazorPagesAuthorContext _context;

        public DetailsModel(RazorPagesAuthor.Data.RazorPagesAuthorContext context)
        {
            _context = context;
        }

        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.Username == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }
    }
}

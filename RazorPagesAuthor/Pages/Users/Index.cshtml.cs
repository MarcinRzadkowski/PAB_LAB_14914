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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAuthor.Data.RazorPagesAuthorContext _context;

        public IndexModel(RazorPagesAuthor.Data.RazorPagesAuthorContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}

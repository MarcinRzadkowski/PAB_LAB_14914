using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesAuthor.Model;

namespace RazorPagesAuthor.Data
{
    public class RazorPagesAuthorContext : DbContext
    {
        public RazorPagesAuthorContext (DbContextOptions<RazorPagesAuthorContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesAuthor.Model.User> User { get; set; } = default!;
    }
}

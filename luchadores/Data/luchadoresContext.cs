using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace luchadores.Models
{
    public class luchadoresContext : DbContext
    {
        public luchadoresContext (DbContextOptions<luchadoresContext> options)
            : base(options)
        {
        }

        public DbSet<luchadores.Models.Verb> Verb { get; set; }
    }
}

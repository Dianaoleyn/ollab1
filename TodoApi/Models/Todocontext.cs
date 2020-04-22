using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class Todocontext : DbContext
    {
        public Todocontext(DbContextOptions<Todocontext> options)
            : base(options)
        {
        }

        public DbSet<Todoitem> TodoItems { get; set; }
    }
}
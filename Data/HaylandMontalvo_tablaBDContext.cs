using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HaylandMontalvo_tablaBD.Models;

namespace HaylandMontalvo_tablaBD.Data
{
    public class HaylandMontalvo_tablaBDContext : DbContext
    {
        public HaylandMontalvo_tablaBDContext (DbContextOptions<HaylandMontalvo_tablaBDContext> options)
            : base(options)
        {
        }

        public DbSet<HaylandMontalvo_tablaBD.Models.Burger> Burger { get; set; } = default!;
    }
}

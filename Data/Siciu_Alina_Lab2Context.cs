﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Siciu_Alina_Lab2.Models;

namespace Siciu_Alina_Lab2.Data
{
    public class Siciu_Alina_Lab2Context : DbContext
    {
        public Siciu_Alina_Lab2Context (DbContextOptions<Siciu_Alina_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Siciu_Alina_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Siciu_Alina_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Siciu_Alina_Lab2.Models.Author> Author { get; set; } = default!;
    }
}

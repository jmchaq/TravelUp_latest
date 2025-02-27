﻿using Microsoft.EntityFrameworkCore;
using TravelUp.Models;

namespace TravelUp.Data
    {
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; } // Items table
    }
}



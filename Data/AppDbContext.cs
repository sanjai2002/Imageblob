﻿
using Imagestore.Models;
using Microsoft.EntityFrameworkCore;

namespace Imagestore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ImageEntity> Images { get; set; }
    }
}

using EmployeeDirectoryProcessor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDirectoryProcessor.Data
{
    public class DirectoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DirectoryContext(DbContextOptions<DirectoryContext> options)
      : base(options)
        { }
    }
}

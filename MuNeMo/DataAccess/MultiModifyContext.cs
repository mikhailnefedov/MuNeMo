using System.ComponentModel.DataAnnotations;

namespace MuNeMo.DataAccess;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class MultiModifyContext : DbContext
{
    public DbSet<Configuration> Configurations { get; set; }

    public string DbPath { get; }

    public MultiModifyContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "munemo.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Configuration
{
    [Key] 
    public int Id { get; set; }

    public string AuthorEmail { get; set; }
    public string AuthorName { get; set; }
    public string Token { get; set; }
    public string Platform { get; set; }
}
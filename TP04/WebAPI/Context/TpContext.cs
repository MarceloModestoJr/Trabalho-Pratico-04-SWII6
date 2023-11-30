using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebAPI.Models;

namespace TP02.Context;

public class TpContext : DbContext
{
    public TpContext(DbContextOptions<TpContext> options) : base(options)
    {
    }
    public DbSet<Atividade> Atividades { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Atividade>().HasKey(m => m.Id);

        base.OnModelCreating(builder);
    }
}

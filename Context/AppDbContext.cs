using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consumindo_API_com_React.Models;
using Microsoft.EntityFrameworkCore;

namespace Consumindo_API_com_React.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
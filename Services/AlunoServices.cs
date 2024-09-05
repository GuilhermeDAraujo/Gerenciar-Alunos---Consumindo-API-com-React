using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consumindo_API_com_React.Context;
using Consumindo_API_com_React.Models;
using Microsoft.EntityFrameworkCore;

namespace Consumindo_API_com_React.Services
{
    public class AlunoServices : IAlunoServices
    {
        private readonly AppDbContext _context;

        public AlunoServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            return await _context.Alunos.OrderBy(a => a.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByNome(string nome)
        {
            var query = _context.Alunos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(nome))
            {
                query = query.Where(a => a.Nome.Contains(nome));
            }

            return await query
                .OrderBy(a => a.Nome)
                .ToListAsync();
        }

        public async Task<Aluno> GetAluno(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task CreateAluno(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAluno(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
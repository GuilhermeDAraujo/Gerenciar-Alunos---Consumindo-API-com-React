using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consumindo_API_com_React.Models;

namespace Consumindo_API_com_React.Services
{
    public interface IAlunoServices
    {
        Task<IEnumerable<Aluno>> GetAlunos(); //Busca lista de Alunos
        Task<Aluno> GetAluno(int id); //Busca aluno por id
        Task<IEnumerable<Aluno>> GetAlunosByNome(string nome); //Busca lista de alunos por nome
        Task CreateAluno(Aluno aluno);
        Task UpdateAluno(Aluno aluno);
        Task DeleteAluno(Aluno aluno);
    }
}
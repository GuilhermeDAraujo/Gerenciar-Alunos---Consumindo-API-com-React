using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consumindo_API_com_React.Models;
using Consumindo_API_com_React.Services;
using Microsoft.AspNetCore.Mvc;

namespace Consumindo_API_com_React.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private IAlunoServices _alunoServices;

        public AlunosController(IAlunoServices alunoServices)
        {
            _alunoServices = alunoServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            var alunos = await _alunoServices.GetAlunos();
            if (!alunos.Any())
                return NotFound($"Não existem alunos cadastados");

            return Ok(alunos);
        }

        [HttpGet("AlunosPorNome")]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunosByNome(string nome)
        {
            if(string.IsNullOrWhiteSpace(nome))
                return BadRequest("O critério de busca não pode ser vazio");

            var alunos = await _alunoServices.GetAlunosByNome(nome);
            if (!alunos.Any())
                return NotFound($"Não existem alunos com o critério {nome}");

            return Ok(alunos);
        }

        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _alunoServices.GetAluno(id);
            if (aluno == null)
                return NotFound($"Não exite aluno com o critério = {id}");

            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Os atributos do aluno tem que ser válidos");

            await _alunoServices.CreateAluno(aluno);
            return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAluno(int id, Aluno aluno)
        {
            if (aluno.Id == id)
            {
                await _alunoServices.UpdateAluno(aluno);
                return Ok($"Aluno com id={id} foi atualizado com sucesso");
            }

            return NotFound("ID do aluno não corresponde ao ID da URL.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            var aluno = await _alunoServices.GetAluno(id);
            if (aluno == null)
            {
                return NotFound($"Aluno com id={id} não encontrado.");
            }

            await _alunoServices.DeleteAluno(aluno);
            return Ok($"Aluno com id={id} foi excluido com sucesso");
        }
    }
}
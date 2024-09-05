using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consumindo_API_com_React.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o {0} do aluno.")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "O tamanho de {0} deve conter entre {2} e {1} caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um {0} válido!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O {0} deve conter entre {2} e {1} caracteres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a {0} do aluno.")]
        [Range(1, 150, ErrorMessage = "A {0} deve estar entre {1} e {2} anos!")]
        [DisplayFormat(DataFormatString = "{0:F0}", ApplyFormatInEditMode = true)]
        public int Idade { get; set; }
    }
}
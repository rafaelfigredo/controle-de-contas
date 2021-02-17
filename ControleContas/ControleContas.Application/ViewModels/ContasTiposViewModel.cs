using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleContas.Application.ViewModels
{
    public class ContasTiposViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do tipo de conta é obrigatório")]
        [MinLength(1, ErrorMessage = "O nome do tipo precisa ter ao menos 2 caracteres")]
        [MaxLength(50, ErrorMessage = "O nome do tipo precisa ter no máximo 50 caracteres")]
        [DisplayName("Nome do tipo")]
        public string Nome { get; set; }
    }
}

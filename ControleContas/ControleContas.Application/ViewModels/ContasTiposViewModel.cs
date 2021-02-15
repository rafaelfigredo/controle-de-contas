using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleContas.Application.ViewModels
{
    public class ContasTiposViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do tipo de conta é obrigatório")]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}

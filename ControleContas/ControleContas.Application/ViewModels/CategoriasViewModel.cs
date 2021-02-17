using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleContas.Application.ViewModels
{
    public class CategoriasViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        [MinLength(1, ErrorMessage = "O nome da categoria deve ter ao menos 2 caracteres")]
        [MaxLength(50, ErrorMessage = "O nome da categoria deve ter no máximo 50 caracteres")]
        [DisplayName("Nome da categoria")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Cor da categoria é obrigatório")]
        [MinLength(7, ErrorMessage = "Selecione uma cor válida")]
        [MaxLength(7, ErrorMessage = "Selecione uma cor válida")]
        [DisplayName("Cor")]
        public string Cor { get; set; }
    }
}

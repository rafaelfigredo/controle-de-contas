using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleContas.Application.ViewModels
{
    public class CategoriasViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Nome")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Cor da categoria é obrigatório")]
        [MinLength(6)]
        [MaxLength(6)]
        [DisplayName("Cor")]
        public string Cor { get; set; }
    }
}

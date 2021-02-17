using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleContas.Application.ViewModels
{
    public class ContasViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da conta é obrigatório")]
        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Nome da conta")]
        public string Nome { get; set; }

        [DisplayName("Tipo de conta")]
        [Required(ErrorMessage = "Tipo de Conta é obrigatório")]
        public int ContasTiposId { get; set; }

        [Required(ErrorMessage = "Cor da conta é obrigatório")]
        [MinLength(6)]
        [MaxLength(6)]
        [DisplayName("Cor")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Dia do vencimento da conta é obrigatório")]
        [DisplayName("Dia do Vencimento")]
        public int VencimentoDia { get; set; }

        public ContasTiposViewModel ContasTipos { get; set; }
        public List<LancamentosViewModel> Lancamentos { get; set; }
    }
}

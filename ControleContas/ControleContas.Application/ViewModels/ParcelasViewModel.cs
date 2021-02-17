using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleContas.Application.ViewModels
{
    public class ParcelasViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Número da parcela")]
        [Required(ErrorMessage = "Número da parcela é obrigatório")]
        public int ParcelaNumero { get; set; }

        [DisplayName("Valor da parcela")]
        [Required(ErrorMessage = "Valor da parcela é obrigatório")]
        public decimal ParcelaValor { get; set; }

        [DisplayName("Ano cobrança")]
        [Required(ErrorMessage = "Ano cobrança é obrigatório")]
        public int AnoCobranca { get; set; }

        [DisplayName("Mês cobrança")]
        [Required(ErrorMessage = "Mês cobrança é obrigatório")]
        public int MesCobranca { get; set; }

        [DisplayName("Lançamento")]
        [Required(ErrorMessage = "Lançamento é obrigatório")]
        public int LancamentosId { get; set; }

        public LancamentosViewModel Lancamentos { get; set; }
    }
}

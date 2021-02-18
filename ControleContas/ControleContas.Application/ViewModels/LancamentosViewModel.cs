using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleContas.Application.ViewModels
{
    public class LancamentosViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Descrição do lançamento")]
        [Required(ErrorMessage = "Descrição do lançamento é obrigatório")]
        [MinLength(1, ErrorMessage = "A descição do lançamneto precisa ter no mínimo 2 caracteres")]
        [MaxLength(100, ErrorMessage = "A descrição do lançamento precisa ter no máximo 100 caracteres")]
        public string Descricao { get; set; }

        [DisplayName("Valor Total")]
        [Required(ErrorMessage = "Valor é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ValorTotal { get; set; }

        [DisplayName("Qtde. de Parcelas")]
        [Required(ErrorMessage = "Quantidade de parcelas é obrigatório")]
        public int ParcelasTotal { get; set; }

        [DisplayName("Conta")]
        [Required(ErrorMessage = "Conta é obrigatório")]
        public int ContasId { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Categoria é obrigatório")]
        public int CategoriasId { get; set; }

        [Display(Name = "Data da compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCompra { get; set; }

        [Display(Name = "Data 1ª parcela")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPrimeiraParcela { get; set; }

        public CategoriasViewModel Categorias { get; set; }
        public virtual ContasViewModel Contas { get; set; }
        public virtual List<ParcelasViewModel> Parcelas { get; set; }
    }
}

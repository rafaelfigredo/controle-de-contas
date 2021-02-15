using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleContas.Application.ViewModels
{
    public class LancamentosViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Descrição do lançamento")]
        [Required(ErrorMessage = "Descrição do lançamento é obrigatório")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [DisplayName("Valor Total")]
        [Required(ErrorMessage = "Valor é obrigatório")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal ValorTotal { get; set; }

        [DisplayName("Quantidade de Parcelas")]
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

        public CategoriasViewModel Categorias { get; set; }
        public virtual ContasViewModel Contas { get; set; }
        public virtual ICollection<ParcelasViewModel> Parcelas { get; set; }
    }
}

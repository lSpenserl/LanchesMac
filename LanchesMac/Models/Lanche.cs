using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {       
        [Key]
        public int LancheId { get; set; }

        [Required (ErrorMessage ="O Nome do lanche deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80,MinimumLength =10,ErrorMessage ="O {0} deve ter no mínimo {1} e no máximo{2} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A Descrição do lanche deve ser informado")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no maximo {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A Descrição detalhada do lanche deve ser informado")]
        [Display(Name = "Descrição detalhada do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada deve ter no maximo {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage ="Informe o preço do lanche")]
        [Display(Name ="preço")]
        [Column(TypeName = "decimal(20,2)")]
        [Range(1,199.9,ErrorMessage ="O valor deve estar entre R$1,00 e R$999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho imagem normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho imagem miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name ="Categoria")]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

    }
}

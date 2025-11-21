using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("ProdutoInvestimento", Schema = "dbo")]
    public class ProdutoInvestimento
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Required]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required]
        [Column("IdTipoProdutoInvestimento")]
        public long TipoId { get; set; }

        public TipoProdutoInvestimento Tipo { get; set; } = null!;

        [Required]
        [Column("PrazoMinimoMeses")]
        public int PrazoMinimoMeses { get; set; }

        [Required]
        [Column("PrazoMaximoMeses")]
        public int PrazoMaximoMeses { get; set; }

        [Required]
        [Column("ValorMinimoInvestimento")]
        public decimal ValorMinimoInvestimento { get; set; }

        [Required]
        [Column("ValorMaximoInvestimento")]
        public decimal ValorMaximoInvestimento { get; set; }

        [Required]
        [Column("Rentabilidade")]
        public decimal Rentabilidade { get; set; }

        [Required]
        [Column("Risco")]
        public string Risco { get; set; }

        [Required]
        [Column("DataCadastro")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset DataCadastro { get; set; }
    }
}

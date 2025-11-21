using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Entities
{
    [Table("SimulacaoInvestimento", Schema = "dbo")]
    public class SimulacaoInvestimento
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Required]
        [Column("ClienteId")]
        public long ClienteId { get; set; }

        public Cliente Cliente { get; set; } = null!;

        [Required]
        [Column("ProdutoId")]
        public long ProdutoId { get; set; }

        public ProdutoInvestimento Produto { get; set; } = null!;

        [Required]
        [Column("ValorInvestido")]
        public decimal ValorInvestido { get; set; }

        [Required]
        [Column("ValorFinal")]
        public decimal ValorFinal { get; set; }

        [Required]
        [Column("PrazoMeses")]
        public int PrazoMeses { get; set; }

        [Required]
        [Column("DataSimulacao")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset DataSimulacao { get; set; }
    }
}

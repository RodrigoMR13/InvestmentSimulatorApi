using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Cliente", Schema = "dbo")]
    public class Cliente
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("Nome")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [Column("Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(11)]
        [Column("Cpf")]
        public string Cpf { get; set; } = string.Empty;

        [Required]
        [Column("DataCadastro")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset DataCadastro { get; set; }

        public ICollection<SimulacaoInvestimento> Simulacoes { get; set; } = new List<SimulacaoInvestimento>();
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TipoProdutoInvestimento
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }
        [Required]
        [Column("Nome")]
        public string Nome { get; set; }
    }
}

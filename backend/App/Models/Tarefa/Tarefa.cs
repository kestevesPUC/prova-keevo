using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Tarefa")]
public class Tarefa
{
    [Key]
    public int id { get; set; }

    [Column("titulo")]
    public string titulo { get; set; }

    [Column("descricao_breve")]
    public string descBreve { get; set; }

    [Column("descricao_detalhada")]
    public string descDetalhada { get; set; }

    [Column("status_id")]
    public int status_id { get; set; }
    
    [Column("data_cad")]
    public DateTime? dataCriacao { get; set; }

    [Column("data_upd")]
    public DateTime? dataAtualizacao { get; set; }
}
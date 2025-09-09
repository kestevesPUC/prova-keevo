using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

[Table("tarefa")]
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
    public int statusId { get; set; }

    public Status? Status { get; set; }
    
    [Column("data_cad")]
    public DateTime? dataCriacao { get; set; }

    [Column("data_upd")]
    public DateTime? dataAtualizacao { get; set; }
}
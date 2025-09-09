using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Tarefa")]
public class Tarefa
{
    [Key]
    int id { get; set; }

    [Column("titulo")]
    string titulo { get; set; }

    [Column("descricao_breve")]
    string descBreve { get; set; }

    [Column("descricao_detalhada")]
    string descDetalhada { get; set; }

    [Column("status_id")]
    int status_id { get; set; }
    
    [Column("data_cad")]
    DateTime dataCriacao { get; set; }

    [Column("data_upd")]
    DateTime dataAtualizacao { get; set; }
}
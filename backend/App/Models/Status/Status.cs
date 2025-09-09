using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("status")]
public class Status
{
    [Key]
    public int id { get; set; }

    [Column("descricao")]
    public string descricao { get; set; }
}
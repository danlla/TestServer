using System.ComponentModel.DataAnnotations.Schema;

namespace TestServer.Model;

[Table("number")]
public class Number
{
    [Column("id")]
    public long Id { get; set; }

    [Column("value")]
    public int Value { get; set; }
}

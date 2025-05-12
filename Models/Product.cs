using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNetCrud.Models;

[Table("products")]
public class Product
{
    [Key]
    public int Id { get; set; } // Primary key
    [Column("name")]
    public string Name { get; set; }
    [Column("price", TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
}
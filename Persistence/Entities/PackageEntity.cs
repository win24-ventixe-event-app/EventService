using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class PackageEntity
{
  [Key]
  public int Id { get; set; }
  public string? Name { get; set; }

  public string? Placement { get; set; }
  public string? SeatingInformation { get; set; }

[Column(TypeName = "decimal(18, 2)")]
  public decimal Price { get; set; }
  public string? Currency { get; set; }
}

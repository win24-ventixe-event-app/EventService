using System;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class EventEntity
{
  [Key]
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public string? Name { get; set; }
  public string? Image { get; set; }


  public DateTime EventDate { get; set; }
  public string? Description { get; set; }
  public string? Location { get; set; }

  public ICollection<EventPackageEntity> Packages { get; set; } = [];


}

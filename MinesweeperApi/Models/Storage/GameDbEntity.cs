using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinesweeperApi.Models.Storage;

public class GameDbEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public int mines_count { get; set; }
    [Required]
    public bool completed { get; set; }
    [Required]
    public string field { get; set; }
    [Required]
    public int turn_number { get; set; }
}

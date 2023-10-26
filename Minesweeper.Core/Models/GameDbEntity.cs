using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minesweeper.Core.Models;

/// <summary>
/// DB entity with game information. Some redundant information is not stored in DB.
/// </summary>
public class GameDbEntity
{
    /// <summary>
    /// Game ID, PK
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// Mines quantity on field
    /// </summary>
    [Required]
    public int MinesCount { get; set; }
    /// <summary>
    /// Game is completed
    /// </summary>
    [Required]
    public bool IsCompleted { get; set; }
    /// <summary>
    /// Game field, serialized to JSON
    /// </summary>
    [Required]
    public string Field { get; set; }

    /// <summary>
    /// How many cells are opened
    /// </summary>
    [Required]
    public int TurnNumber { get; set; }
}

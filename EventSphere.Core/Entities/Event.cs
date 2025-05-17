using System.ComponentModel.DataAnnotations;

namespace EventSphere.Core.Entities;

public class Event
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public required string Title { get; set; }

    [Required]
    [StringLength(5000)]
    public required string Description { get; set; }

    [Required]
    [StringLength(500)]
    public required string ThumbnailPath { get; set; }

    public int TotalSlots { get; set; }

    public int AvailableSlots { get; set; }

    public DateTime EventDate { get; set; }

    public DateTime GoLiveDateTime { get; set; }

    public bool IsOnlineEvent { get; set; }

    [StringLength(500)]
    public string? Location { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; }

    [Required]
    public required string CreatedById { get; set; }
}
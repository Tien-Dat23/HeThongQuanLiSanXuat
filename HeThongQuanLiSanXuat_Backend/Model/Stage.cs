using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLiSanXuat_Backend.Model;

[Table("stages")]
public partial class Stage
{
    [Key]
    [Column("stage_id")]
    public int StageId { get; set; }

    [Column("stage_code")]
    [StringLength(50)]
    public string StageCode { get; set; } = null!;

    [Column("stage_name")]
    [StringLength(255)]
    public string StageName { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }
}

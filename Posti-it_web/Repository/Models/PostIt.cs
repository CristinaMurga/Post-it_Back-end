using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Posti_it_web.Repository.Models;


[Table("post_it")]
public partial class PostIt
{
    [Key]
    [Column("id")]
    public int? Id { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("color")]
    [StringLength(10)]
    public string Color { get; set; }

    [Column("username")]
    public string Username{ get; set;}

    [Column("positionLeftX")]
    public int? PositionLeftX { get; set; }

    [Column("positionTopY")]
    public int? PositionTopY { get; set; }
}


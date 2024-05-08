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

    [Column("position")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Position { get; set; }

    [Column("body")]
    [Unicode(false)]
    public string? Body { get; set; }

    [Column("color")]
    [StringLength(10)]
    public string? Color { get; set; }

    [Column("userID")]
    public int UserID { get; set;}
}

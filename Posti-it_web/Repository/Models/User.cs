using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Posti_it_web.Repository.Models;


[Table("users")]
public partial class User
{
    [Key]
    [Column("ID")]
    public int? Id { get; set; }

    [Column("username")]
    [StringLength(10)]
    public string? Username { get; set; }

    [Column("password")]
    [StringLength(10)]
    public string? Password { get; set; }
}

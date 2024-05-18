using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Posti_it_web.Repository.Models
{
    [Table("colors")]
    public class Color
    {

        [Key]
        [Column("id")]
        public int? Id { get; set; }

        [Column("name")]
        [StringLength(15)]
        public string Name { get; set; }

        [Column("hexadecimal")]
        [StringLength(10)]
        public string Hexadecimal { get; set; }
    }
}

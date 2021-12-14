using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    [Table("Категории_индикаторов")]
    public partial class КатегорииИндикаторов
    {
        public КатегорииИндикаторов()
        {
            Индикаторы = new HashSet<Индикаторы>();
        }

        [Key]
        [Column("id_категории")]
        public byte IdКатегории { get; set; }
        [Column("Категория_индикатора")]
        [StringLength(20)]
        public string КатегорияИндикатора { get; set; }

        [InverseProperty("IdКатегорииNavigation")]
        public virtual ICollection<Индикаторы> Индикаторы { get; set; }
    }
}

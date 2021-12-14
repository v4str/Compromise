using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    [Table("Предварительно_собранные_индикаторы")]
    public partial class ПредварительноСобранныеИндикаторы
    {
        [Key]
        [Column("id_предварительно_собранного_индикатора")]
        public int IdПредварительноСобранногоИндикатора { get; set; }
        [Key]
        [Column("id_общего_индикатора")]
        public int IdОбщегоИндикатора { get; set; }
        [Column("Дата_добавления", TypeName = "datetime")]
        public DateTime? ДатаДобавления { get; set; }

        [ForeignKey(nameof(IdОбщегоИндикатора))]
        [InverseProperty(nameof(Индикаторы.ПредварительноСобранныеИндикаторы))]
        public virtual Индикаторы IdОбщегоИндикатораNavigation { get; set; }
    }
}

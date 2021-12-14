using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    [Table("Обогащенные_индикаторы")]
    public partial class ОбогащенныеИндикаторы
    {
        [Key]
        [Column("id_обогащенного_индикатора")]
        public int IdОбогащенногоИндикатора { get; set; }
        [Key]
        [Column("id_общего_индикатора")]
        public int IdОбщегоИндикатора { get; set; }
        [Column("Рейтинг_индикатора")]
        public byte? РейтингИндикатора { get; set; }
        [Column("Дата_изменения", TypeName = "datetime")]
        public DateTime? ДатаИзменения { get; set; }

        [ForeignKey(nameof(IdОбщегоИндикатора))]
        [InverseProperty(nameof(Индикаторы.ОбогащенныеИндикаторы))]
        public virtual Индикаторы IdОбщегоИндикатораNavigation { get; set; }
    }
}

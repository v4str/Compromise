using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    public partial class Отчеты
    {
        [Key]
        [Column("id_отчета")]
        public short IdОтчета { get; set; }
        [Column("Дата_составления_отчета", TypeName = "datetime")]
        public DateTime? ДатаСоставленияОтчета { get; set; }
        [StringLength(40)]
        public string Результат { get; set; }
        [Column("id_сотрудника")]
        public byte? IdСотрудника { get; set; }
        [Column("id_индикатора")]
        public int? IdИндикатора { get; set; }
        [Column("id_общего_индикатора")]
        public int? IdОбщегоИндикатора { get; set; }

        [ForeignKey("IdИндикатора,IdОбщегоИндикатора")]
        [InverseProperty(nameof(БазаИндикаторов.Отчеты))]
        public virtual БазаИндикаторов Id { get; set; }
        [ForeignKey(nameof(IdСотрудника))]
        [InverseProperty(nameof(УполномоченныеСотрудники.Отчеты))]
        public virtual УполномоченныеСотрудники IdСотрудникаNavigation { get; set; }
    }
}

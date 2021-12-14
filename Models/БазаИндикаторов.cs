using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    [Table("База_индикаторов")]
    public partial class БазаИндикаторов
    {
        public БазаИндикаторов()
        {
            ДоверенныеРесурсы = new HashSet<ДоверенныеРесурсы>();
            КонфигурацииСзи = new HashSet<КонфигурацииСзи>();
            Отчеты = new HashSet<Отчеты>();
        }

        [Key]
        [Column("id_индикатора")]
        public int IdИндикатора { get; set; }
        [Key]
        [Column("id_общего_индикатора")]
        public int IdОбщегоИндикатора { get; set; }
        [Column("Дата_первого_появления", TypeName = "datetime")]
        public DateTime? ДатаПервогоПоявления { get; set; }
        [Column("Дата_последнего_появления", TypeName = "datetime")]
        public DateTime? ДатаПоследнегоПоявления { get; set; }

        [ForeignKey(nameof(IdОбщегоИндикатора))]
        [InverseProperty(nameof(Индикаторы.БазаИндикаторов))]
        public virtual Индикаторы IdОбщегоИндикатораNavigation { get; set; }
        [InverseProperty("Id")]
        public virtual ICollection<ДоверенныеРесурсы> ДоверенныеРесурсы { get; set; }
        [InverseProperty("Id")]
        public virtual ICollection<КонфигурацииСзи> КонфигурацииСзи { get; set; }
        [InverseProperty("Id")]
        public virtual ICollection<Отчеты> Отчеты { get; set; }
    }
}

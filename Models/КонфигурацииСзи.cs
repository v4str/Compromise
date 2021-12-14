using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    [Table("Конфигурации_СЗИ")]
    public partial class КонфигурацииСзи
    {
        [Key]
        [Column("id_оповещения")]
        public int IdОповещения { get; set; }
        [Column("Описание_оповещения")]
        [StringLength(30)]
        public string ОписаниеОповещения { get; set; }
        [Column("Уровень_опасности")]
        public byte? УровеньОпасности { get; set; }
        [Column("id_индикатора")]
        public int? IdИндикатора { get; set; }
        [Column("id_общего_индикатора")]
        public int? IdОбщегоИндикатора { get; set; }

        [ForeignKey("IdИндикатора,IdОбщегоИндикатора")]
        [InverseProperty(nameof(БазаИндикаторов.КонфигурацииСзи))]
        public virtual БазаИндикаторов Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    [Table("Доверенные_ресурсы")]
    public partial class ДоверенныеРесурсы
    {
        [Key]
        [Column("Id_ресурса")]
        public byte IdРесурса { get; set; }
        [Column("ip_адрес")]
        [StringLength(18)]
        public string IpАдрес { get; set; }
        [Column("Название_организации")]
        [StringLength(30)]
        public string НазваниеОрганизации { get; set; }
        [Column("id_индикатора")]
        public int? IdИндикатора { get; set; }
        [Column("id_общего_индикатора")]
        public int? IdОбщегоИндикатора { get; set; }

        [ForeignKey("IdИндикатора,IdОбщегоИндикатора")]
        [InverseProperty(nameof(БазаИндикаторов.ДоверенныеРесурсы))]
        public virtual БазаИндикаторов Id { get; set; }
    }
}

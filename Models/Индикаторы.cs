using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    public partial class Индикаторы
    {
        public Индикаторы()
        {
            БазаИндикаторов = new HashSet<БазаИндикаторов>();
            ОбогащенныеИндикаторы = new HashSet<ОбогащенныеИндикаторы>();
            ПредварительноСобранныеИндикаторы = new HashSet<ПредварительноСобранныеИндикаторы>();
        }

        [StringLength(30)]
        public string Тип { get; set; }
        [StringLength(30)]
        public string Значение { get; set; }
        [StringLength(40)]
        public string Контекст { get; set; }
        [Key]
        [Column("id_общего_индикатора")]
        public int IdОбщегоИндикатора { get; set; }
        [Column("id_критерия")]
        public byte? IdКритерия { get; set; }
        [Column("id_категории")]
        public byte? IdКатегории { get; set; }

        [ForeignKey(nameof(IdКатегории))]
        [InverseProperty(nameof(КатегорииИндикаторов.Индикаторы))]
        public virtual КатегорииИндикаторов IdКатегорииNavigation { get; set; }
        [ForeignKey(nameof(IdКритерия))]
        [InverseProperty(nameof(КритерииОценкиПолученныхРезультатов.Индикаторы))]
        public virtual КритерииОценкиПолученныхРезультатов IdКритерияNavigation { get; set; }
        [InverseProperty("IdОбщегоИндикатораNavigation")]
        public virtual ICollection<БазаИндикаторов> БазаИндикаторов { get; set; }
        [InverseProperty("IdОбщегоИндикатораNavigation")]
        public virtual ICollection<ОбогащенныеИндикаторы> ОбогащенныеИндикаторы { get; set; }
        [InverseProperty("IdОбщегоИндикатораNavigation")]
        public virtual ICollection<ПредварительноСобранныеИндикаторы> ПредварительноСобранныеИндикаторы { get; set; }
    }
}

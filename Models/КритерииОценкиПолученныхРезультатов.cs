using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    [Table("Критерии_оценки_полученных_результатов")]
    public partial class КритерииОценкиПолученныхРезультатов
    {
        public КритерииОценкиПолученныхРезультатов()
        {
            Индикаторы = new HashSet<Индикаторы>();
        }

        [Key]
        [Column("id_критерия")]
        public byte IdКритерия { get; set; }
        [Column("Полнота_контекста")]
        [StringLength(18)]
        public string ПолнотаКонтекста { get; set; }
        [Column("id_стандарта")]
        public byte? IdСтандарта { get; set; }
        [Column("id_поставщика")]
        public byte? IdПоставщика { get; set; }

        [ForeignKey(nameof(IdПоставщика))]
        [InverseProperty(nameof(ПоставщикиДанных.КритерииОценкиПолученныхРезультатов))]
        public virtual ПоставщикиДанных IdПоставщикаNavigation { get; set; }
        [ForeignKey(nameof(IdСтандарта))]
        [InverseProperty(nameof(СтандартыОписанияДанных.КритерииОценкиПолученныхРезультатов))]
        public virtual СтандартыОписанияДанных IdСтандартаNavigation { get; set; }
        [InverseProperty("IdКритерияNavigation")]
        public virtual ICollection<Индикаторы> Индикаторы { get; set; }
    }
}

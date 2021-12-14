using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    [Table("Поставщики_данных")]
    public partial class ПоставщикиДанных
    {
        public ПоставщикиДанных()
        {
            КритерииОценкиПолученныхРезультатов = new HashSet<КритерииОценкиПолученныхРезультатов>();
        }

        [Key]
        [Column("id_поставщика")]
        public byte IdПоставщика { get; set; }
        [StringLength(30)]
        public string Поставщик { get; set; }
        [Column("Рейтинг_доверия")]
        public double? РейтингДоверия { get; set; }

        [InverseProperty("IdПоставщикаNavigation")]
        public virtual ICollection<КритерииОценкиПолученныхРезультатов> КритерииОценкиПолученныхРезультатов { get; set; }
    }
}

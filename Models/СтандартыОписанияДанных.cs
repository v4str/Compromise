using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    [Table("Стандарты_описания_данных")]
    public partial class СтандартыОписанияДанных
    {
        public СтандартыОписанияДанных()
        {
            КритерииОценкиПолученныхРезультатов = new HashSet<КритерииОценкиПолученныхРезультатов>();
        }

        [Key]
        [Column("id_стандарта")]
        public byte IdСтандарта { get; set; }
        [Column("Стандарт_описания")]
        [StringLength(20)]
        public string СтандартОписания { get; set; }

        [InverseProperty("IdСтандартаNavigation")]
        public virtual ICollection<КритерииОценкиПолученныхРезультатов> КритерииОценкиПолученныхРезультатов { get; set; }
    }
}

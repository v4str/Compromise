using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compromise.Models
{
    [Table("Уполномоченные_сотрудники")]
    public partial class УполномоченныеСотрудники
    {
        public УполномоченныеСотрудники()
        {
            Отчеты = new HashSet<Отчеты>();
        }

        [Key]
        [Column("id_сотрудника")]
        public byte IdСотрудника { get; set; }
        [StringLength(20)]
        public string Фамилия { get; set; }
        [StringLength(15)]
        public string Имя { get; set; }
        [StringLength(20)]
        public string Отчество { get; set; }
        [StringLength(20)]
        public string Должность { get; set; }

        [InverseProperty("IdСотрудникаNavigation")]
        public virtual ICollection<Отчеты> Отчеты { get; set; }
    }
}

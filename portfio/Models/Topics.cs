using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace portfio.Models
{
    public class Topics
    {
        [Key, Column("Topic_Id")]
        public int Id { get; set; }

        [Column("Topic_Name"), Required, Display(Name = "Наименование")]
        public string Name { get; set; }

        [Column("Topic_Info"), Required, Display(Name = "Инфо")]
        public string Info { get; set; }

        public virtual ICollection<Works> TopicWorks { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfio.Models
{
    public class Works
    {
        [Key, Column("Works_Id")]
        public int Id { get; set; }
        
        [Display(Name = "Группа")]
        public int Topics_Id { get; set; }

        [Column("Works_Title"), Required, Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Column("Works_Info"), Required, Display(Name = "Инфо")]
        public string Info { get; set; }

        [Column("Works_Link"), Required, Display(Name = "Ссылка")]
        public string Link { get; set; }

        [ForeignKey("Topics_Id")]
        public virtual Topics Topic { get; set; }

        public virtual ICollection<Photos> Work_Photos { get; set; }
    }
}
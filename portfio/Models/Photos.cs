using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfio.Models
{
    public class Photos
    {
        [Column("Photos_Id")]
        public int Id { get; set; }
        public int Works_Id { get; set; }

        [Column("Photos_Link"), Required, Display(Name = "Ссылка")]
        public string Link { get; set; }

        [Column("Photos_Info"),  Display(Name = "Инфо")]
        public string Info { get; set; }

        [ForeignKey("Works_Id")]
        public virtual Works work { get; set; }
    }
}
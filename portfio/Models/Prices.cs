using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfio.Models
{
    public class Prices
    {
        [Column("Price_Id")]
        public int Id { get; set; }

        [Column("Price_Name"), Required, Display(Name = "Наименование")]
        public string Name { get; set; }

        [Column("Price_Unit"), Display(Name="Единица измерения")]
        public string Unit { get; set; }

        [Display(Name = "Цена"), Required]
        public double Price { get; set; }
    }
}
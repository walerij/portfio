using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfio.Models
{
    public class Contacts
    {
        [Column("Contact_id")]
        public int Id { get; set; }

        [Column("Contact_Param"), Display(Name ="Параметр"), Required]
        public string Param { get; set; }

        [Column("Contact_Value"), Display(Name ="Значение"), Required]
        public string Value { get; set; }
    }
}
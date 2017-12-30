using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace portfio.Models
{
    public class SocialLinks
    {
        [Column("Social_Id")]
        public int Id { get; set; }

        [Column("Social_Name"), Required, Display(Name = "Изображение")]
        public string Img_name { get; set; }

        [Column("Social_Link"), Required, Display(Name = "Ссылка")]
        public string Link { get; set; }

        [Column("Social_Title"), Required, Display(Name = "Заголовок")]
        public string Title { get; set; }
    }
}
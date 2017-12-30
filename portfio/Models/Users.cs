using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfio.Models
{
    public class Users
    {
        [Key, Column("User_Id"),Required]
        public int Id { get; set; }

        [Column("User_Name"),  Display(Name ="Имя")]
        public string Name { get; set; }

        [Column("User_Login"), Required, Display(Name="Email"), EmailAddress(ErrorMessage ="Поле не соответствует формату Email")]
        public string Login { get; set; }

        [Column("User_Password"), Required, Display(Name="Пароль"), MinLength(8)]
        public string Password { get; set; }
    }
}
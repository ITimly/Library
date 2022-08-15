using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class User
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина имени не более 20 символов")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина email не более 100 символов")]
        public string Email { get; set; }
        [Display(Name = "Пароль")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина пароля не более 25 символов")]
        public string Password { get; set; }
        [Display(Name = "Уровень доступа")]
        [StringLength(1)]
        [Required(ErrorMessage = "Длина уровня доступа не более 1 символов")]
        public string Level { get; set; }
    }
}
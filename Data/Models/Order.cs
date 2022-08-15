using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина имени не более 20 символов")]
        public string Name { get; set; }
        [Display(Name = "Введите фамилию")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина фамилии не более 20 символов")]
        public string Surname { get; set; }
        [Display(Name = "Введите адрес")]
        [StringLength(150)]
        [Required(ErrorMessage = "Длина адреса не более 150 символов")]
        public string Adress { get; set; }
        [Display(Name = "Введите телефон")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина телефона не более 15 символов")]
        public string Phone { get; set; }
        [Display(Name = "Введите email")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина email не более 100 символов")]
        public string Email { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}

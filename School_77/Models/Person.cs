using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_77.Models
{
    public class Person
    {
        
        public int ID { get; set; }
        [Required, StringLength(20, ErrorMessage = "Максимум 20 символов")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required, StringLength(20, ErrorMessage = "Максимум 20 символов")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [StringLength(20, ErrorMessage = "Максимум 20 символов")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "ФИО")]
        public string FullName
        {
            get{return LastName + " " + FirstName + " " + Patronymic;}
        }
        public string Initials
        {
            get { return LastName + " " + FirstName[0] + ". " + Patronymic[0] + "."; }
        }
    }
}
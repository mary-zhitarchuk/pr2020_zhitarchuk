using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealSurfClub.Models.DBModels
{ 
    public class User
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Никнейм
        /// </summary>
        [Display(Name= "Псевдоним*")]
        [Required(ErrorMessage ="Ошибка в псевдониме"), MinLength(3), MaxLength(20)]
        public string Nickname { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        [Display(Name = "Почта*")]
        [Required(ErrorMessage = "Указание электронной почты обязательно")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Неверно указан электронный адрес")]
        ///[EmailAddress(ErrorMessage ="Неверно указан электронный адрес")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Display(Name = "Пароль*")]
        [Required(ErrorMessage = "Ошибка пароля"), MinLength(6), MaxLength(20)]
        public string Password { get; set; }


        [Display(Name = "Подтвердите пароль*")]
        [NotMapped]
        public string PasswordConfirm { get; set; }


        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Контактная информация
        /// </summary>
        [Display(Name = "Контактная информация")]
        public string ContactInfo { get; set; }

        /// <summary>
        /// О себе
        /// </summary>
        [Display(Name = "О себе")]
        public string About { get; set; }

        /// <summary>
        /// Достижения
        /// </summary>
        [Display(Name = "Достижения")]
        public string Achivements { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        [Display(Name = "Выберите фото")]
        public Guid Photo { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RealSurfClub.Models.DBModels
{
    public class Post
    {
        [Key]
        public int Id { get; set; }



        /// <summary>
        /// Текст записи
        /// </summary>
        [Display(Name = "Введите текст"), MaxLength(4095)]
        public string Text { get; set; }


        /// <summary>
        /// Изображение
        /// </summary>
        [Display(Name = "Прикрепить изображение")]
        public Guid Photo { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime PubishDate { get; set; }

        /// <summary>
        /// Автор записи
        /// </summary>
        public virtual User Author { get; set; }
    }
}
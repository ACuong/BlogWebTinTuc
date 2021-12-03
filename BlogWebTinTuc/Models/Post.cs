using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWebTinTuc.Models
{
    public class Post
    {
        [Key]
        [Required(ErrorMessage = "PosID is Required.")]
        public string PostID { get; set; }

        [Required(ErrorMessage = "Thiếu tiêu dề .")]
        [Display(Name ="Tiêu đề")]
        public string Title { get; set; }

        
        [Display(Name = "Ảnh bìa")]
        public string Url_image { get; set; }

        [Display(Name = "Nội dung")]
        [AllowHtml]
        public string Textbody { get; set; }

        [Display(Name = "Danh mục")]
        public string CategoryID { get; set; }
        
        public Category Category { get; set; }
    }
}
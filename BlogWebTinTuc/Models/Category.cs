using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace BlogWebTinTuc.Models
{
    public class Category
    {

        [Key]
        [StringLength(10)]
        public string CategoryID { get; set; }

        [Display(Name = "Tên Danh mục")]
        [StringLength(10)]
        public string CategoryName { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
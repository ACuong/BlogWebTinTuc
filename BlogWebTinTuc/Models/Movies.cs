using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWebTinTuc.Models
{
    public class Movies
    {
        [Key]
        public string MoviesID { get; set; }

        [Display(Name = "Tên")]
        public string MoviesName { get; set; }
    }
}